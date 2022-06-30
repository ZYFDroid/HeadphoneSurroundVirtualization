using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEQCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            int requiredThreads = Environment.ProcessorCount + Environment.ProcessorCount / 2;
            for (int i = 0; i < requiredThreads; i++)
            {
                startThreaad();
            }
            
        }

        private void startThreaad()
        {
            System.Threading.Thread thread = new System.Threading.Thread(() =>
            {
                float p = 100000;
                while (true)
                {
                    p *= 0.99999f;
                    if (p < 1)
                    {
                        p += 100000;
                    }
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
