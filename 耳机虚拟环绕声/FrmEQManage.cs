using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static 耳机虚拟环绕声.Program;

namespace 耳机虚拟环绕声
{
    public partial class FrmEQManage : Form
    {

        private AudioEnchancementSampleProvider processingProvider;
        private string currentGuid = "";
        private DeviceDesc bindToDevice = null;
        public FrmEQManage(AudioEnchancementSampleProvider sampleProvider,string currentGuid,DeviceDesc deviceGuid)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.processingProvider = sampleProvider;
            this.currentGuid = currentGuid;
            this.bindToDevice = deviceGuid;
        }


        private void FrmEQManage_Load(object sender, EventArgs e)
        {
            loadData();
        }


        public void loadData()
        {
            SelectedObject = null;
            tblData.Rows.Clear();
            Program.AudioEnchancementData.audioEnchancementParameters.ForEach(p => {
                tblData.Rows.Add(p.guid,p.guid == currentGuid,p.DisplayName,"导出","删除");
            });
            tblData.ClearSelection();
        }
        private void tblData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tblData.Rows[e.RowIndex].Selected = true;
                string guid = tblData[0, e.RowIndex].Value.ToString();
                AudioEnchancementParameters param = Program.AudioEnchancementData.audioEnchancementParameters.First(a => a.guid == guid);
                SelectedObject = param;
            }
        }
        private AudioEnchancementParameters _selectedObject = null;
        private AudioEnchancementParameters SelectedObject
        {
            get
            {
                return _selectedObject;
            }
            set
            {
                _selectedObject = value;
                tblParam.Enabled = _selectedObject != null;
                if(value != null)
                {
                    showDetailData();
                }

            }
        }

        private bool showingData = false;
        void showDetailData()
        {
            txtName.Text = SelectedObject.DisplayName;
            showingData = true;
            chkInvertChannel.Checked = SelectedObject.invertOneSide;
            chkSwapChannel.Checked = SelectedObject.swapChannel;
            numAntiCrossfeed.Value = (int)(SelectedObject.antiCrossfeedLevel * 1000);
            numBalance.Value = (int)(SelectedObject.balanceLevel * 1000);
            chtEq.PeakEQParams = SelectedObject.peakEQParams;
            showingData = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_selectedObject != null)
            {
                _selectedObject.balanceLevel = numBalance.Value / 1000f;
                _selectedObject.antiCrossfeedLevel = numAntiCrossfeed.Value / 1000f;
                _selectedObject.swapChannel = chkSwapChannel.Checked;
                _selectedObject.DisplayName = txtName.Text;
                _selectedObject.invertOneSide = chkInvertChannel.Checked;
                if (currentGuid == _selectedObject.guid)
                {
                    tryUpdateParam(_selectedObject);
                }
                if (sender == btnSave)
                {
                    Program.save();
                    loadData();
                }
                
            }
        }

        private void tryUpdateParam(AudioEnchancementParameters p)
        {
            try
            {
                processingProvider?.Apply(p);
            }
            catch { }
        }

        private Random rnd = new Random();
        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            if(Program.AudioEnchancementData.audioEnchancementParameters.Count >= 30)
            {
                MessageBox.Show(this,"数量超过上限。");
                return;
            }
            Program.AudioEnchancementData.audioEnchancementParameters.Add(new AudioEnchancementParameters()
            {
                guid = Guid.NewGuid().ToString(),
                DisplayName = "新建配置文件 #" + rnd.Next(10000000, 99999999)
            });
            loadData();
        }

        private void numAntiCrossfeed_ValueChanged(object sender, EventArgs e)
        {
            numAntiCrossfeed.ThumbText = ((float)numAntiCrossfeed.Value / 1000f).ToString("0.000");
        }

        private void numBalance_ValueChanged(object sender, EventArgs e)
        {
            numBalance.ThumbText = (numBalance.Value / 1000f).ToString("0.000");
        }

        private void tblData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string guid = tblData[0, e.RowIndex].Value.ToString();
                AudioEnchancementParameters param = Program.AudioEnchancementData.audioEnchancementParameters.First(a => a.guid == guid);
                if (e.ColumnIndex == 1)//复选框
                {
                    bool selected = (bool)tblData[1, e.RowIndex].Value;
                    if (!selected) {
                        
                        Program.AudioEnchancementData.setDeviceParam(bindToDevice.name, bindToDevice.id, param);
                        currentGuid = guid;
                        for (int i = 0; i < tblData.RowCount; i++)
                        {
                            tblData[1, i].Value = false;
                        }
                        tblData[1, e.RowIndex].Value = true;
                        tryUpdateParam(param);
                    }
                    else
                    {
                        Program.AudioEnchancementData.setDeviceParam(bindToDevice.name,bindToDevice.id, null);
                        tblData[1, e.RowIndex].Value = false;
                        currentGuid = "";
                        tryUpdateParam(null);
                    }
                }
                if(e.ColumnIndex == 3)// 导出
                {
                    if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, JsonConvert.Serialize(param));
                        MessageBox.Show(this,"导出完成");
                    }
                }
                if (e.ColumnIndex == 4)// 删除
                {
                    if (MessageBox.Show(this,"是否删除此配置文件?","",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if(param.guid == currentGuid)
                        {
                            Program.AudioEnchancementData.setDeviceParam(bindToDevice.name, bindToDevice.id, null);
                            currentGuid = "";
                            tryUpdateParam(null);
                        }
                        Program.AudioEnchancementData.audioEnchancementParameters.RemoveAll(r => r.guid == param.guid);
                        loadData();
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (Program.AudioEnchancementData.audioEnchancementParameters.Count >= 30)
            {
                MessageBox.Show(this, "数量超过上限。");
                return;
            }
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    string jsonData = File.ReadAllText(openFileDialog1.FileName);
                    AudioEnchancementParameters param = JsonConvert.Deserialize<AudioEnchancementParameters>(jsonData);
                    Program.AudioEnchancementData.audioEnchancementParameters.RemoveAll(r => r.guid == param.guid);
                    Program.AudioEnchancementData.audioEnchancementParameters.Insert(0, param);
                    if(param.guid == currentGuid)
                    {
                        tryUpdateParam(param);
                    }
                    loadData();
                    MessageBox.Show("导入完成");
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnCreateByGuide_Click(object sender, EventArgs e)
        {
            if (Program.AudioEnchancementData.audioEnchancementParameters.Count >= 30)
            {
                MessageBox.Show(this, "数量超过上限。");
                return;
            }

        }

        private void btnEditEQ_Click(object sender, EventArgs e)
        {
            if (SelectedObject != null) {
                FrmParamEQ frmParamEQ = new FrmParamEQ(SelectedObject.peakEQParams);
                frmParamEQ.RequestUpdate += FrmParamEQ_RequestUpdate;
                frmParamEQ.ShowDialog(this);
                frmParamEQ.RequestUpdate -= FrmParamEQ_RequestUpdate;
                frmParamEQ.Dispose();
            }
        }

        private void FrmParamEQ_RequestUpdate(object sender, EventArgs e)
        {
            if (SelectedObject != null) { 
                if(SelectedObject.guid == currentGuid)
                {
                    tryUpdateParam(SelectedObject);
                }
            }
        }
    }
}
