using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

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

        public static void ConfigDevice()
        {
            MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();
            var devices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render,DeviceState.Active);
            foreach (var device in devices)
            {
                var property = device.Properties;
                for (int i = 0; i < property.Count; i++)
                {
                    var key = property.Get(i);
                    if(key.formatId == PropertyKeys.PKEY_AudioEndpoint_PhysicalSpeakers.formatId)
                    {
                        var value = property.GetValue(i);
                        MessageBox.Show("Test: "+value.ToString(),device.DeviceFriendlyName);
                        
                    }
                }
            }

        }

        public const string PARAM_SETUP_DEVICE = "--setup-device";

        private void btnOnekeyConfig_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            ProcessStartInfo psi = new ProcessStartInfo(Application.ExecutablePath,PARAM_SETUP_DEVICE);
            psi.UseShellExecute = true;
            psi.Verb = "runas";
            psi.WorkingDirectory = Environment.CurrentDirectory;
            try
            {
                var process = Process.Start(psi);
                while (!process.WaitForExit(20))
                {
                    Application.DoEvents();
                }
            }catch(Exception ex)
            {
                // Windows的bug，每次弹出窗口都会吧窗口弄到最底下去
                this.TopMost = true;
                this.TopMost = false;
                MessageBox.Show(ex.GetType().FullName+": "+ex.Message,"配置失败");
                this.TopMost = true;
                this.TopMost = false;
            }
            this.TopMost = true;
            this.TopMost = false;
            this.Enabled = true;
        }
    }
}
