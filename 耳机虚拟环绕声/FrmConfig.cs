using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 耳机虚拟环绕声
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string installdoc = System.IO.Path.Combine(Program.UserDataDir, "install_v0.pdf");
            if (!System.IO.File.Exists(installdoc))
            {
                System.IO.File.WriteAllBytes(installdoc, Properties.Resources.install);
            }
            System.Diagnostics.Process.Start(installdoc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mmsys.cpl");
        }
    }
}
