using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 耳机虚拟环绕声;

namespace TestEQCreator
{
    public partial class FrmEntry : Form
    {
        public FrmEntry()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void btnOpenAutoFit_Click(object sender, EventArgs e)
        {
            SwitchTo(new FrmAutoFit());
        }

        private void btnOpenManualEdit_Click(object sender, EventArgs e)
        {
            SwitchTo(new FrmManualEdit());
        }

        private void SwitchTo(Form frm)
        {
            this.Hide();
            frm.FormClosed += delegate
            {
                Close();
            };
            frm.Show();
        }
    }
}
