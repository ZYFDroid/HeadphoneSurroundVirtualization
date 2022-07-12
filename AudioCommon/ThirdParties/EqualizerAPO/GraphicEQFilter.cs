using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using FFTWSharp;
/*
CSharp Reimplemention of EqualizerAPO Graphics EQ Filter
The orignal C++ version at https://sourceforge.net/projects/equalizerapo/
 */

namespace EqualizerAPO
{
    public class GraphicEQFilter
    {
        List<FilterNode> filterNodes = new List<FilterNode>();

        private float sampleRate = 0;

        public GraphicEQFilter(float sampleRate)
        {
            this.sampleRate = sampleRate;
        }


        public void UpdateFreqNodes(List<FilterNode> nodes)
        {
            filterNodes.Clear();
            filterNodes.AddRange(nodes.OrderBy(o => o.freq).Select(o => o.Copy()));
            if (filterNodes.Count == 0)
            {
                filterNodes.Add(new FilterNode() { freq = 11451.4f, dbGain = 0 });
            }

            filterNodes.Insert(0, new FilterNode() { freq = 20, dbGain = filterNodes.First().dbGain });
            filterNodes.Insert(0, new FilterNode() { freq = 20000, dbGain = filterNodes.Last().dbGain });

            // float max = nodes.Select(f => f.dbGain).Max();
            // filterNodes.ForEach(f => f.dbGain -= max);
        }


        public double gainAt(double freq)
        {

            double current = Freq2Log((int)freq);
           
            FilterNode leftNode = new FilterNode() { freq = 20, dbGain = filterNodes.First().dbGain };
            FilterNode rightNode = new FilterNode() { freq = 20000, dbGain = filterNodes.Last().dbGain };

            if(freq < 20) { return leftNode.dbGain; }
            if(freq > 20000) { return rightNode.dbGain; }
            for (int i = 1; i < filterNodes.Count; i++)
            {
                if(freq <= filterNodes[i].freq)
                {
                    leftNode = filterNodes[i - 1];
                    rightNode = filterNodes[i];
                    break;
                }
            }

            double min = Freq2Log((int)leftNode.freq);
            double max = Freq2Log((int)rightNode.freq);

            if(Math.Abs(max - min) < 0.001)
            {
                return leftNode.dbGain;
            }

            double multiplier = (current - min) / (max - min);

            double dbMin = leftNode.dbGain;
            double dbMax = rightNode.dbGain;

            return dbMin + (dbMax - dbMin) * multiplier;
        }


        public static float Freq2Log(int freq)
        {
            return (float)(Math.Log10(freq / 2) - 1f) / 3f;
        }

        public static int Log2Freq(float log)
        {
            return (int)Math.Round(Math.Pow(10, (log * 3) + 1) * 2d);
        }


        public float[] GenerateInpulseResponse()
        {
            fftwf_complexarray timeData = new fftwf_complexarray(filterLength * 2);
            fftwf_complexarray freqData = new fftwf_complexarray(filterLength * 2);
            fftwf_plan planForward = fftwf_plan.dft_1d(filterLength * 2, timeData, freqData, fftw_direction.Forward, fftw_flags.Estimate);
            fftwf_plan planReverse = fftwf_plan.dft_1d(filterLength * 2, freqData, timeData, fftw_direction.Backward, fftw_flags.Estimate);
            freqData.Cache();
            for (int i = 0; i < filterLength; i++)
            {
                double freq = i * 1.0 * sampleRate / (filterLength * 2);
                double dbGain = gainAt(freq);
                float gain = (float)Math.Pow(10.0, dbGain / 20.0);

                freqData[i,0] = gain;
                freqData[i,1] = 0;
                freqData[2 * filterLength - i - 1,0] = gain;
                freqData[2 * filterLength - i - 1,1] = 0;
            }
            freqData.Apply();

            mps(timeData, freqData, planForward, planReverse);

            planReverse.Execute();

            timeData.Cache();

            for (int i = 0; i < 2 * filterLength; i++)
            {
                timeData[i,0] /= 2 * filterLength;
                timeData[i,1] /= 2 * filterLength;
            }

            for (int i = 0; i < filterLength; i++)
            {
                float factor = (float)(0.5 * (1d + Math.Cos(2d * Math.PI * i * 1.0 / (2d * filterLength))));
                timeData[i,0] *= factor;
                timeData[i,1] *= factor;
            }

            float[] buf = new float[filterLength];
            for (int i = 0; i < filterLength; i++)
            {
                buf[i] = timeData[i,0];
            }
            return buf;
        }
        const int filterLength = 4096;
        private void mps(fftwf_complexarray timeData, fftwf_complexarray freqData,fftwf_plan planForward, fftwf_plan planReverse)
        {
            double threshold = Math.Pow(10.0, -100.0 / 20.0);
            float logThreshold = (float)Math.Log(threshold);
            freqData.Cache();
            for (int i = 0; i < filterLength * 2; i++)
            {
                if (freqData[i,0] < threshold)
                    freqData[i,0] = logThreshold;
                else
                    freqData[i,0] = (float)Math.Log(freqData[i,0]);

                freqData[i,1] = 0;
            }
            freqData.Apply();
            planReverse.Execute();

            timeData.Cache();
            for (int i = 0; i < filterLength * 2; i++)
            {
                timeData[i,0] /= filterLength * 2;
                timeData[i,1] /= filterLength * 2;
            }

            for (int i = 1; i < filterLength; i++)
            {
                timeData[i,0] += timeData[filterLength * 2 - i,0];
                timeData[i,1] -= timeData[filterLength * 2 - i,1];

                timeData[filterLength * 2 - i,0] = 0;
                timeData[filterLength * 2 - i,1] = 0;

            }

            timeData[filterLength,1] *= -1;

            timeData.Apply();

            planForward.Execute();
            freqData.Cache();
            for (int i = 0; i < filterLength * 2; i++)
            {
                double eR = Math.Exp(freqData[i,0]);
                freqData[i,0] = (float)(eR * Math.Cos(freqData[i,1]));
                freqData[i,1] = (float)(eR * Math.Sin(freqData[i,1]));
            }
            freqData.Apply();
        }



    }

    public class FilterNode
    {
        public float freq;
        public float dbGain;

        internal FilterNode Copy()
        {
            return new FilterNode()
            {
                freq = this.freq,
                dbGain = this.dbGain
            };
        }
    }
}
