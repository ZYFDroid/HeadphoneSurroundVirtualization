using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;
using NAudio.Wave;

namespace 耳机虚拟环绕声
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
        }


        private void lnk_click(object sender, EventArgs e)
        {
            Control which = sender as Control;
            if (which.Tag != null)
            {
                string text = which.Tag.ToString();
                System.Diagnostics.Process.Start(text);
            }
        }


        /// <summary>
        /// 没用
        /// 🔈↓↑微软不给开放api
        /// 要么自己写驱动，但是给驱动签名要钱
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void ConfigDevice()
        {
            string VBCABLE_NAME = "VB-Audio Virtual Cable".ToLower();

            MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();
            var devices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render,DeviceState.Active);
            bool found = false;
            bool configuted = false;
            foreach (var device in devices)
            {
                device.GetPropertyInformation(StorageAccessMode.ReadWrite);
                var property = device.Properties;
                bool isCurrentDevice = false;
                for (int i = 0; i < property.Count; i++)
                {

                    var key = property.Get(i);
                    var findingProperty = PropertyKeys.PKEY_DeviceInterface_FriendlyName;
                    if (key.formatId == findingProperty.formatId && key.propertyId == findingProperty.propertyId)
                    {
                        var value = property.GetValue(i);
                        if(value.Value is string && (value.Value.ToString().ToLower()).Contains(VBCABLE_NAME))
                        {
                            isCurrentDevice = true;
                            found = true;
                            break;
                        }
                    }
                }
                
                uint surround_7p1 = 1599;

                PropVariant pv = default(PropVariant);
                pv.vt = (short)VarEnum.VT_UI4;
                pv.uintVal = surround_7p1;
                if (isCurrentDevice)
                {

                    var formatProperty = PropertyKeys.PKEY_AudioEngine_DeviceFormat;
                    byte[] format = (byte[])property[formatProperty].Value;

                    format[0x02] = 0x08; // channel

                    format[0x14] = 0x3f; // speaker mask
                    format[0x15] = 0x06; // speaker mask

                    uint nSampleRate = BitConverter.ToUInt32(format, 0x04);
                    ushort nBitDepth = BitConverter.ToUInt16(format, 0x0e);

                    ushort nBlockAlign = (ushort)(nBitDepth * 8u / 8u);
                    uint nAvgBytesPerSec = (nSampleRate * nBitDepth * 8u / 8u);

                    Array.Copy(BitConverter.GetBytes(nAvgBytesPerSec), 0, format, 0x08, 4);
                    Array.Copy(BitConverter.GetBytes(nBlockAlign), 0, format, 0x0c, 2);

                    var targetProperty = PropertyKeys.PKEY_AudioEndpoint_PhysicalSpeakers;
                    var targetProperty2 = PropertyKeys.PKEY_AudioEndpoint_FullRangeSpeakers;
                    var targetProperty3 = PropertyKeys.PKEY_AudioEngine_DeviceFormat;
                    var targetProperty4 = PropertyKeys.PKEY_AudioEngine_OEMFormat;

                    // 隐藏api，真有你的，微软
                    var win7InternalProperty0  = new PropertyKey(Guid.Parse("e4870e26-3cc5-4cd2-ba46-ca0a9a70ed04"), 0);
                    var win10InternalProperty0 = new PropertyKey(Guid.Parse("3d6e1656-2e50-4c4c-8d85-d0acae3c6c68"), 2);
                    var win10InternalProperty1 = new PropertyKey(Guid.Parse("3d6e1656-2e50-4c4c-8d85-d0acae3c6c68"), 3);
                    var win10InternalProperty2 = new PropertyKey(Guid.Parse("624f56de-fd24-473e-814a-de40aacaed16"), 3);

                    EarTrumpet.Interop.MMDeviceAPI.WaveFormatEx waveFormatEx = default(EarTrumpet.Interop.MMDeviceAPI.WaveFormatEx);
                    // 注释掉了，因为没开/unsafe
                    //unsafe
                    //{
                    //    fixed(byte* byteptr = format)
                    //    {
                    //        waveFormatEx = (EarTrumpet.Interop.MMDeviceAPI.WaveFormatEx)Marshal.PtrToStructure((IntPtr)byteptr, typeof(EarTrumpet.Interop.MMDeviceAPI.WaveFormatEx));
                    //        PropVariant pv2 = new PropVariant();
                    //        pv2.vt = (short)VarEnum.VT_BLOB;
                    //        pv2.blobVal = new Blob();
                    //        pv2.blobVal.Length = format.Length;
                    //        pv2.blobVal.Data = (IntPtr)(byteptr);
                    //        property.SetValue(targetProperty, pv);
                    //        property.SetValue(targetProperty2, pv);
                    //        property.SetValue(targetProperty3, pv2);
                    //        property.SetValue(targetProperty4, pv2);
                    //        property.SetValue(win7InternalProperty0, pv2);
                    //        property.SetValue(win10InternalProperty0, pv2);
                    //        property.SetValue(win10InternalProperty1, pv2);
                    //        property.SetValue(win10InternalProperty2, pv2);
                    //        property.Commit();

                    //    }
                        
                    //}



                    var configurator = new EarTrumpet.Interop.MMDeviceAPI.AutoPolicyConfigClientWin7();
                    configurator.SetDeviceFormat(device.ID,waveFormatEx);
                    configuted = true;
                }
            }
            if (!found)
            {
                throw new Exception("未安装VB Cable");
            }
            if (!configuted)
            {
                throw new Exception("配置VB Cable时发生错误");
            }
        }

        

        public const string PARAM_SETUP_DEVICE = "--setup-device";

        private void btnOnekeyConfig_Click(object sender, EventArgs e)
        {
            // 摆烂了
            Process.Start("mmsys.cpl");
        }

        private void btnConfigByHand_Click(object sender, EventArgs e)
        {
            string VBCABLE_NAME = "VB-Audio Virtual Cable".ToLower();
            bool found = false;
            bool configured = false;
            using(NAudio.CoreAudioApi.MMDeviceEnumerator enumerator = new MMDeviceEnumerator())
            {
                foreach (var item in enumerator.EnumerateAudioEndPoints(DataFlow.Render,DeviceState.Active))
                {
                    if (item.DeviceFriendlyName.ToLower().Contains(VBCABLE_NAME))
                    {
                        found = true;
                    }
                    using (AudioClient ac = item.AudioClient)
                    {
                        if (ac.MixFormat.Channels == 8)
                        {
                            configured = true;
                        }
                    }
                }
            }
            lblConfigStatus.Text = "当前状态：";
            if (found && configured)
            {
                lblConfigStatus.Text += "配置成功";
                return;
            }
            if(!found && !configured)
            {
                lblConfigStatus.Text += "未安装";
            }
            if(found && !configured)
            {
                lblConfigStatus.Text += "未配置，请参考第二步";
            }
            if(!found && configured)
            {
                MessageBox.Show(this,"未找到已安装的VB Cable虚拟设备，但在系统上找到其它支持7.1声道的设备。（仍然建议安装虚拟环绕声设备使用）");
                lblConfigStatus.Text += "找到其它7.1设备";
            }
        }
    }
}
