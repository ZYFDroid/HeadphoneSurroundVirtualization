using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<EqualizerAPO.FilterNode> peakEQParams = new List<EqualizerAPO.FilterNode>();
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

        public WaveFormat WaveFormat => baseProvider.WaveFormat;


        public AudioEnchancementSampleProvider(ISampleProvider baseProvider, AudioEnchancementParameters param)
        {
            if (baseProvider.WaveFormat.Channels != 2)
            {
                throw new ArgumentException("Channels must be stereo(two channel)");
            }
            this.baseProvider = baseProvider;
            graphicEQFilter = new EqualizerAPO.GraphicEQFilter(baseProvider.WaveFormat.SampleRate);
            Apply(param);
        }

        public bool Bypass = false;

        private EqualizerAPO.GraphicEQFilter graphicEQFilter = null;

        private object syncObj = new object();

        private float[] unitp = new float[] { 1, 0, 0, 0, 0, 0, 0, 0 };
        private float[] empty = new float[] { 0, 0, 0, 0, 0, 0, 0, 0 };

        public void Apply(AudioEnchancementParameters param)
        {
            


            if (param == null)
            {
                FFTConvolver.FFTConvolver.set_en_ir(ref unitp[0], ref empty[0], ref empty[0], ref unitp[0], 8);
                return;
            }
            float sampleRate = WaveFormat.SampleRate;
            this.param = param;

            graphicEQFilter.UpdateFreqNodes(param.peakEQParams);

            float[] firLL = graphicEQFilter.GenerateInpulseResponse();
            float[] firLR = new float[firLL.Length];
            float[] firRL = new float[firLL.Length];
            float[] firRR = firLL.Select(l => l).ToArray();

          

            if (param.invertOneSide)
            {
                for (int i = 0; i < firLL.Length; i++)
                {
                    firLL[i] = -firLL[i];
                }
            }

            for (int i = 0; i < firLL.Length; i++)
            {
                firLR[i] = param.antiCrossfeedLevel * firLL[i];
                firRL[i] = param.antiCrossfeedLevel * firRR[i];
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
            for (int i = 0; i < firLL.Length; i++)
            {
                firLR[i] *= rDown;
                firRR[i] *= rDown;
                firRL[i] *= lDown;
                firLL[i] *= lDown;
            }
            if (param.swapChannel)
            {
                var temp = firLL;
                firLL = firLR;
                firLR = temp;

                temp = firRL;
                firRL = firRR;
                firRR = temp;
            }
            
            FFTConvolver.FFTConvolver.set_en_ir(ref firLL[0], ref firLR[0], ref firRL[0], ref firRR[0], firLL.Length);
                

        }

        float lDown = 1;
        float rDown = 1;

        public int Read(float[] buffer, int offset, int count)
        {
            int sampleReaded = baseProvider.Read(buffer, offset, count);
            return sampleReaded;
            
        }
    }

}
