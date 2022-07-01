using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 耳机虚拟环绕声.ThirdParties.EqualizerAPO;

namespace AudioCommon
{

    public class AudioEnchancementData
    {
        public List<DeviceParameterMapping> deviceParameterMappings = new List<DeviceParameterMapping>();
        public List<AudioEnchancementParameters> audioEnchancementParameters = new List<AudioEnchancementParameters>();
        /// <summary>
        /// Fail-safe的获取模块
        /// </summary>
        /// <param name="deviceGuid"></param>
        /// <returns></returns>
        public AudioEnchancementParameters getDeviceParam(string deviceGuid)
        {
            DeviceParameterMapping dpm = null;
            foreach (var item in deviceParameterMappings)
            {
                if (item.deviceGuid == deviceGuid)
                {
                    dpm = item;
                }
            }
            if (dpm != null)
            {
                foreach (var item in audioEnchancementParameters)
                {
                    if (item.guid == dpm.parameterGuid)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        public void setDeviceParam(string deviceName, string deviceGuid, AudioEnchancementParameters param)
        {

            deviceParameterMappings.RemoveAll(d => d.deviceGuid == deviceGuid);
            if (param != null)
            {
                deviceParameterMappings.Add(new DeviceParameterMapping() { deviceGuid = deviceGuid, deviceName = deviceName, parameterGuid = param.guid });
            }
        }
    }

    public class DeviceParameterMapping
    {
        public string deviceGuid;
        public string deviceName;
        public string parameterGuid;
    }

    public class AudioEnchancementParameters
    {
        /// <summary>
        /// 显示的名称
        /// </summary>
        public string DisplayName = "Default";
        /// <summary>
        /// 唯一标志
        /// </summary>
        public string guid = Guid.Empty.ToString();
        /// <summary>
        /// 是否交换左右声道
        /// 这对于某些左右声道做反，但又必须区分左右耳的耳机来说有用
        /// </summary>
        public bool swapChannel = false;
        /// <summary>
        /// 抗串扰
        /// 范围是 -1 ~ 1
        /// （但如果是1的时候
        /// 部分奇怪的电脑（例如惠普的暗影精灵）在使用有线耳机的时候，一边声道的声音会有一部分跑到另一边。影响立体声分离度和效果
        /// </summary>
        public float antiCrossfeedLevel = 0;
        /// <summary>
        /// 音量平衡
        /// 范围是-1 ~ 1
        /// 如果你的耳机一边声音大一边声音小，建议用这个
        /// 但是更建议换个新的
        /// </summary>
        public float balanceLevel = 0;
        /// <summary>
        /// 界外立体声
        /// 部分奇怪的耳机（例如淘宝某店买的蓝牙头带耳机），有一边的单元正负极接反了，导致音乐听起来不太好听，可以使用这个开关修复
        /// </summary>
        public bool invertOneSide = false;

        /// <summary>
        /// 用于均衡器的参数列表
        /// </summary>
        public List<PeakEQParam> peakEQParams = new List<PeakEQParam>();
    }

    public class PeakEQParam
    {
        public float centerFrequent;
        public float gain;
        public float Q;
    }

    public class AudioEnchancementSampleProvider : ISampleProvider
    {
        private AudioEnchancementParameters param;
        private ISampleProvider baseProvider;

        public AudioEnchancementParameters AudioEnchancementParameters => param;

        BiQuad[,] biQuadFilters = null;
        public WaveFormat WaveFormat => baseProvider.WaveFormat;


        public AudioEnchancementSampleProvider(ISampleProvider baseProvider, AudioEnchancementParameters param)
        {
            if (baseProvider.WaveFormat.Channels != 2)
            {
                throw new ArgumentException("Channels must be stereo(two channel)");
            }
            this.baseProvider = baseProvider;
            Apply(param);
        }

        public bool Bypass = false;

        private object syncObj = new object();
        public void Apply(AudioEnchancementParameters param)
        {
            lock (syncObj)
            {
                if (param == null)
                {
                    this.param = null;
                    return;
                }
                float sampleRate = WaveFormat.SampleRate;
                this.param = param;
                biQuadFilters = new BiQuad[param.peakEQParams.Count, WaveFormat.Channels];
                peakEqCount = param.peakEQParams.Count;
                for (int i = 0; i < param.peakEQParams.Count; i++)
                {
                    for (int c = 0; c < WaveFormat.Channels; c++)
                    {
                        PeakEQParam eq = param.peakEQParams[i];
                        biQuadFilters[i, c] = BiQuad.PeakEQ(sampleRate, eq.centerFrequent, eq.Q, eq.gain);
                    }
                }
                lDown = 1;
                rDown = 1;
                if (param.balanceLevel < 0)
                {
                    rDown = -(-1 - param.balanceLevel) / (1 - param.balanceLevel);
                }
                else
                {
                    lDown = -(1 - param.balanceLevel) / (-1 - param.balanceLevel);
                }
            }
        }
        private int peakEqCount = 0;
        float lDown = 1;
        float rDown = 1;
        public int Read(float[] buffer, int offset, int count)
        {
            int sampleReaded = baseProvider.Read(buffer, offset, count);
            if (!Bypass && param != null)
            {
                lock (syncObj)
                {
                    int channel = 2;
                    int end = offset + sampleReaded;
                    //for (int i = offset; i < end; i += channel) {

                    //    buffer[i] = 0.1f;
                    //    buffer[i+1] = 0.1f;
                    //}

                    // 均衡器
                    //for (int n = 0; n < peakEqCount; n++)
                    //{
                    //    biQuadFilters[n, 0].processBatch(buffer, offset, count, 2, 0);
                    //    biQuadFilters[n, 1].processBatch(buffer, offset, count, 2, 1);
                    //}
                    for (int i = offset; i < end; i += channel)
                    {
                        // 均衡器
                        // 必须这样一个一个一个处理每个sample
                        // 用上面注释掉的批量处理的方法也是可以的
                        // 但在电脑非常卡顿的时候，例如启动一个装了50多个Mod的Minecraft，有可能会输出NaN
                        // 试了下，别人的电脑上也有这个问题
                        // 有没有大佬能解答一下
                        for (int n = 0; n < peakEqCount; n++)
                        {
                            buffer[i] = biQuadFilters[n, 0].process(buffer[i]);
                            buffer[i + 1] = biQuadFilters[n, 1].process(buffer[i + 1]);
                        }
                        // 交换左右声道
                        if (param.swapChannel)
                        {
                            float t = buffer[i];
                            buffer[i] = buffer[i + 1];
                            buffer[i + 1] = t;
                        }
                        // 反转一边
                        if (param.invertOneSide)
                        {
                            buffer[i] = -buffer[i];
                        }
                        // 抗串扰
                        float l = buffer[i];
                        float r = buffer[i + 1];
                        buffer[i + 1] += l * param.antiCrossfeedLevel;
                        buffer[i] += r * param.antiCrossfeedLevel;

                        // 声道平衡
                        buffer[i] *= lDown;
                        buffer[i + 1] *= rDown;
                    }
                }
            }
            return sampleReaded;
        }
    }

}
