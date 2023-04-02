using AudioCommon;
using EqualizerAPO;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toaster;
using 耳机虚拟环绕声;

namespace TestEQCreator
{
    public partial class FrmAutoFit : Form
    {

        public FrmAutoFit()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        SelectionSampleProvider selectionSampleProvider;

        List<ISampleProvider> pageSampleProviders;

        SilenceProvider silenceProvider;

        WasapiOut mainOutput;

        Toast Toast;

        private void Form1_Load(object sender, EventArgs e)
        {
            Toast = new Toast(this,btnBegin.Font);
            PreInitialize();
            InitPage0();
            InitPage1();
            InitPage2();
            InitPage3();
            InitPage4();
            PostInitialize();

        }

        private void PreInitialize()
        {
            pageSampleProviders = new List<ISampleProvider>();

        }

        private void PostInitialize()
        {
            selectionSampleProvider = new SelectionSampleProvider(pageSampleProviders.ToArray());
            this.FormClosing += FrmAutoFit_FormClosing;
        }

        private void FrmAutoFit_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainOutput?.Stop();
            mainOutput?.Dispose();
        }



        #region Page0 - Getting Started

        private void InitPage0()
        {
            btnBegin.Click += BtnBegin_Click;
            pageSampleProviders.Add(new SilenceProvider(WaveFormat.CreateIeeeFloatWaveFormat(48000, 1)).ToSampleProvider());
        }

        private void BtnBegin_Click(object sender, EventArgs e)
        {
            mainOutput = new WasapiOut();
            mainOutput.Init(selectionSampleProvider);
            mainOutput.Volume = MathHelper.db2linear(-96);
            mainOutput.Play();
            GotoPage1();
            
        }

        void GotoPage1()
        {
            tblMain.SelectedPage = page1Prequest;
            selectionSampleProvider.SelectionIndex = 1;
        }

        #endregion

        #region Page1 - Suitable Volume


        SignalGenerator page1WhiteNoiseProvider;
        private void InitPage1()
        {
            page1WhiteNoiseProvider = new SignalGenerator(48000, 1)
            {
                Type = SignalGeneratorType.Pink
            };
            pageSampleProviders.Add(page1WhiteNoiseProvider);
            numInitialVolume.Min = -960;
            numInitialVolume.Max = 0;
            numInitialVolume.Value = -960;
            numInitialVolume.ValueChanged += NumInitialVolume_ValueChanged;
            numInitialVolume.ThumbText = "-96 dB";

            btnPage1Next.Click += BtnPage1Next_Click;
        }

        private void BtnPage1Next_Click(object sender, EventArgs e)
        {
            tblMain.SelectedPage = page2Minium;
            selectionSampleProvider.SelectionIndex = 2;
            
        }

        private void NumInitialVolume_ValueChanged(object sender, EventArgs e)
        {
            mainOutput.Volume = MathHelper.db2linear((float)numInitialVolume.Value / 10f);
            numInitialVolume.ThumbText = (((float)numInitialVolume.Value / 10f)).ToString()+" dB";
        }



        #endregion

        #region Page2 - Mininum Hearing Level


        FrequentTestProvider page2MininumHearingSampleProvider;

        float MininumHearingDB = -96;

        private void InitPage2()
        {
            page2MininumHearingSampleProvider = new FrequentTestProvider(48000) {
                freq0 = 440,
                freq1 = 440,
                Freq1Strength = -96,
                Freq2Strength = -96
            };
            pageSampleProviders.Add(page2MininumHearingSampleProvider);
            numMininumSound.Min = -960;
            numMininumSound.Max = 0;
            numMininumSound.Value = -960;
            numMininumSound.ThumbText = "-96 dB";
            numMininumSound.ValueChanged += NumMininumSound_ValueChanged;
            btnPage2Back.Click += delegate { GotoPage1(); };
            btnPage2Next.Click += BtnPage2Next_Click;
        }

        private void BtnPage2Next_Click(object sender, EventArgs e)
        {
            tblMain.SelectedPage = page3ThinAdjust;
            selectionSampleProvider.SelectionIndex = 3;
            updateGraph();
        }

        private void NumMininumSound_ValueChanged(object sender, EventArgs e)
        {

            MininumHearingDB = ((float)numMininumSound.Value / 10f);
            numMininumSound.ThumbText = MininumHearingDB + " dB";
            page2MininumHearingSampleProvider.Freq1Strength= MininumHearingDB;
            page2MininumHearingSampleProvider.Freq2Strength= MininumHearingDB;
            page3thinAdjustSampleProvider.Freq1Strength= MininumHearingDB;
            
        }
        #endregion

        #region Page3 - Thin Adjust


        FrequentTestProvider page3thinAdjustSampleProvider;

        int currentFreqIndex = 0;

        List<FilterNode> currentAdjustment = new List<FilterNode>();
        List<FilterNode> displayAdjustment = new List<FilterNode>();

        private readonly int[] testFrequents =
        {
            135, 150, 176, 200, 225, 256, 288, 340, 408, 468, 536,
            618, 700,750, 800, 860, 950, 1080, 1200, 1366, 1562, 1790, 2136, 2360, 2580, 
            2954, 3160, 3360, 3770, 4135, 4620, 5140, 5580, 6144, 6740, 7120, 7750, 
            8208, 8800, 9515, 10280, 11451, 12768, 14285, 15739, 118, 100, 88, 72, 54, 36
        };

        int freqHearingUpper = 12288;
        int freqHearingLower = 90;

        private void InitPage3()
        {
            page3thinAdjustSampleProvider = new FrequentTestProvider(48000)
            {
                freq0 = 440,
                freq1 = testFrequents[currentFreqIndex],
                Freq1Strength = -96,
                Freq2Strength = -96
            };
            pageSampleProviders.Add(page3thinAdjustSampleProvider);
            for (int i = 0; i < testFrequents.Length; i++)
            {
                currentAdjustment.Add(new FilterNode() { freq = testFrequents[i], dbGain = -96 });
                displayAdjustment.Add(new FilterNode() { freq = testFrequents[i], dbGain = (-96) - MininumHearingDB });
            }
            ctlEqView.PeakEQParams = displayAdjustment;

            btnPrevFreq.Click += BtnPrevFreq_Click;
            btnNextFreq.Click += BtnNextFreq_Click;

            lblCurrentFreq.Text = testFrequents[currentFreqIndex] + " Hz";
            lblFreqIndex.Text = $"第 {currentFreqIndex+1}/{testFrequents.Length} 个";

            numFreqAdjust.Min = -960;
            numFreqAdjust.Max = 0;
            numFreqAdjust.Value = -960;
            numFreqAdjust.ThumbText = "-96 dB";
            numFreqAdjust.ValueChanged += NumFreqAdjust_ValueChanged;

            btnPage3Back.Click += BtnPage1Next_Click;
            btnPage3Next.Click += BtnPage3Next_Click;
            lblFreqOutOfRangeHint.Visible = false;
        }

        void updateGraph()
        {
            for (int i = 0; i < displayAdjustment.Count; i++)
            {
                displayAdjustment[i].dbGain = currentAdjustment[i].dbGain - MininumHearingDB;
            }
        }

        private void BtnPage3Next_Click(object sender, EventArgs e)
        {
            selectionSampleProvider.SelectionIndex = 0;
            tblMain.SelectedPage = page4ExportData;
        }

        private void NumFreqAdjust_ValueChanged(object sender, EventArgs e)
        {
            currentAdjustment[currentFreqIndex].dbGain = ((float)numFreqAdjust.Value / 10f);
            numFreqAdjust.ThumbText = currentAdjustment[currentFreqIndex].dbGain + " dB";
            displayAdjustment[currentFreqIndex].dbGain = currentAdjustment[currentFreqIndex].dbGain - MininumHearingDB;
            page3thinAdjustSampleProvider.Freq2Strength = currentAdjustment[currentFreqIndex].dbGain;
        }

        private void BtnNextFreq_Click(object sender, EventArgs e)
        {
            
            if (currentFreqIndex < testFrequents.Length - 1)
            {
                currentFreqIndex++;
                FreqChanged();
            }
        }

        private void BtnPrevFreq_Click(object sender, EventArgs e)
        {
            if (currentFreqIndex > 0)
            {
                currentFreqIndex--;
                FreqChanged();
            }
        }

        void FreqChanged()
        {
            numFreqAdjust.Value = (int)(currentAdjustment[currentFreqIndex].dbGain * 10);
            lblCurrentFreq.Text = testFrequents[currentFreqIndex] + " Hz";
            lblFreqIndex.Text = $"第 {currentFreqIndex + 1}/{testFrequents.Length} 个";
            if (testFrequents[currentFreqIndex] < freqHearingLower || testFrequents[currentFreqIndex] > freqHearingUpper)
            {
                lblFreqOutOfRangeHint.Visible = true;
            }
            else
            {
                lblFreqOutOfRangeHint.Visible = false;
            }
            page3thinAdjustSampleProvider.freq1 = testFrequents[currentFreqIndex];
        }


        #endregion

        #region Page4 - Export File
        private void InitPage4()
        {
            btnFinish.Click += delegate { Close(); };
            btnPage4Back.Click += BtnPage2Next_Click;

            btnApplyTarget.Click += BtnApplyTarget_Click;
            btnChangeTarget.Click += BtnChangeTarget_Click;
            btnSaveAsTarget.Click += BtnSaveAsTarget_Click;

            currentTargetProfile = JsonConvert.Deserialize<TurningTargetProfile>(Properties.Resources.buildinHsvt);
            loadHsvtInfo();
        }

        void loadHsvtInfo()
        {
            lblTargetInfo.Text = $"配置文件：{currentTargetProfile.DisplayName}\r\n调音目标：{currentTargetProfile.TargetDevice}\r\n录制设备：{currentTargetProfile.RecordingDevice}";
        }

        TurningTargetProfile currentTargetProfile = null;

        private void BtnSaveAsTarget_Click(object sender, EventArgs e)
        {
            if(dlgHsvtSaver.ShowDialog() == DialogResult.OK)
            {
                float maxDb = currentAdjustment.Select(c => c.dbGain).Max();
                var result = currentAdjustment.Select(c => new FilterNode() { dbGain = c.dbGain + (-maxDb), freq = c.freq }).ToList();
                string displayName = Path.GetFileNameWithoutExtension(dlgHsvtSaver.FileName);
                TurningTargetProfile ttp = new TurningTargetProfile() { 
                    uuid = Guid.NewGuid().ToString(),
                    DisplayName = displayName,
                    TargetDevice = "未设定",
                    RecordingDevice = "未设定",
                    Params = result
                };
                File.WriteAllText(dlgHsvtSaver.FileName, JsonConvert.Serialize(ttp));
                Toast.ShowMessage("保存成功");
            }
        }

        private void BtnChangeTarget_Click(object sender, EventArgs e)
        {
            if(dlgHsvtOpener.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string hsvtStr = File.ReadAllText(dlgHsvtOpener.FileName);
                    TurningTargetProfile turningTargetProfile = JsonConvert.Deserialize<TurningTargetProfile>(hsvtStr);
                    if(turningTargetProfile != null)
                    {
                        this.currentTargetProfile= turningTargetProfile;
                        loadHsvtInfo();
                        Toast.ShowMessage("目标配置载入成功");
                    }
                    else
                    {
                        throw new NullReferenceException("解析文件失败");
                    }
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message,"无法读取调音目标配置");
                }
            }
        }

        private void BtnApplyTarget_Click(object sender, EventArgs e)
        {
            if(dlgHsvxSaver.ShowDialog() == DialogResult.OK)
            {
                List<FilterNode> newList = currentAdjustment.Select(c => new FilterNode() { dbGain = c.dbGain, freq = c.freq }).ToList();
                Dictionary<int, FilterNode> targetMap = currentTargetProfile.Params.ToDictionary(d => (int)d.freq);
                foreach(FilterNode node in newList)
                {
                    FilterNode targetNode = targetMap[(int)node.freq];
                    node.dbGain = node.dbGain - targetNode.dbGain;
                }
                float maxDb = newList.Select(c => c.dbGain).Max();
                var result = newList.Select(c => new FilterNode() { dbGain = c.dbGain + (-maxDb), freq = c.freq }).ToList();

                AudioEnchancementParameters audioEnchancementParameters = new AudioEnchancementParameters();
                string displayName = Path.GetFileNameWithoutExtension(dlgHsvxSaver.FileName);
                audioEnchancementParameters.guid = Guid.NewGuid(). ToString();
                audioEnchancementParameters.DisplayName = displayName;
                audioEnchancementParameters.peakEQParams = result;

                File.WriteAllText(dlgHsvxSaver.FileName, JsonConvert.Serialize(audioEnchancementParameters));
                Toast.ShowMessage("生成成功。请在耳机虚拟环绕声中导入");
            }
        }


        #endregion
    }


    public class TurningTargetProfile
    {
        public string uuid;
        public string DisplayName;
        public string TargetDevice;
        public string RecordingDevice;
        public List<FilterNode> Params;
    }

}
