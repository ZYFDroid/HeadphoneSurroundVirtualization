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
    public partial class FrmEQManage : Form
    {
        public FrmEQManage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            chtEq.PeakEQParams.Clear();
            chtEq.PeakEQParams.Add(new PeakEQParam() { centerFrequent = 1210,gain = -5f,Q = 0.9f});
            chtEq.PeakEQParams.Add(new PeakEQParam() { centerFrequent = 2773,gain = -3.8f,Q = 1.2848f});
            chtEq.PeakEQParams.Add(new PeakEQParam() { centerFrequent = 13372,gain = 5.3f,Q = 0.24f});
            chtEq.PeakEQParams.Add(new PeakEQParam() { centerFrequent = 48,gain = 2.4f,Q = 0.3333f});
            chtEq.PeakEQParams.Add(new PeakEQParam() { centerFrequent = 3758,gain = 1,Q = 1.03f });
        }

        private void chtEq_Load(object sender, EventArgs e)
        {

        }
    }
}
