using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
/*
CSharp Reimplemention of EqualizerAPO's Graphics EQ Filter 
The orignal C++ version at https://sourceforge.net/projects/equalizerapo/

DFT-1D Forward and Backward from NAudio (Modified from inverse to backward)

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
            ComplexArray timeData = new ComplexArray(filterLength * 2);
            ComplexArray freqData = new ComplexArray(filterLength * 2);
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

            mps(timeData, freqData);

            //planReverse.Execute();
            FFT(false, 10+1+1+1, freqData, timeData);


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
        private void mps(ComplexArray timeData, ComplexArray freqData)
        {
            double threshold = Math.Pow(10.0, -100.0 / 20.0);
            float logThreshold = (float)Math.Log(threshold);
            for (int i = 0; i < filterLength * 2; i++)
            {
                if (freqData[i,0] < threshold)
                    freqData[i,0] = logThreshold;
                else
                    freqData[i,0] = (float)Math.Log(freqData[i,0]);

                freqData[i,1] = 0;
            }
            FFT(false, 10 + 1 + 1 + 1, freqData, timeData);

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


            FFT(true, 10 + 1 + 1 + 1, timeData, freqData);

            for (int i = 0; i < filterLength * 2; i++)
            {
                double eR = Math.Exp(freqData[i,0]);
                freqData[i,0] = (float)(eR * Math.Cos(freqData[i,1]));
                freqData[i,1] = (float)(eR * Math.Sin(freqData[i,1]));
            }
        }


        public static void FFT(bool forward, int m, ComplexArray data0, ComplexArray data)
        {
            int n, i, i1, j, k, i2, l, l1, l2;
            float c1, c2, tx, ty, t1, t2, u1, u2, z;


            for (int iccc = 0; iccc < data.Length; iccc++)
            {
                data[iccc,0] = data0[iccc,0];
                data[iccc,1] = data0[iccc,1];
            }


            // Calculate the number of points
            n = 1;
            for (i = 0; i < m; i++)
                n *= 2;

            // Do the bit reversal
            i2 = n >> 1;
            j = 0;
            for (i = 0; i < n - 1; i++)
            {
                if (i < j)
                {
                    tx = data[i,0];
                    ty = data[i,1];
                    data[i,0] = data[j,0];
                    data[i,1] = data[j,1];
                    data[j,0] = tx;
                    data[j,1] = ty;
                }
                k = i2;

                while (k <= j)
                {
                    j -= k;
                    k >>= 1;
                }
                j += k;
            }

            // Compute the FFT 
            c1 = -1.0f;
            c2 = 0.0f;
            l2 = 1;
            for (l = 0; l < m; l++)
            {
                l1 = l2;
                l2 <<= 1;
                u1 = 1.0f;
                u2 = 0.0f;
                for (j = 0; j < l1; j++)
                {
                    for (i = j; i < n; i += l2)
                    {
                        i1 = i + l1;
                        t1 = u1 * data[i1,0] - u2 * data[i1,1];
                        t2 = u1 * data[i1,1] + u2 * data[i1,0];
                        data[i1,0] = data[i,0] - t1;
                        data[i1,1] = data[i,1] - t2;
                        data[i,0] += t1;
                        data[i,1] += t2;
                    }
                    z = u1 * c1 - u2 * c2;
                    u2 = u1 * c2 + u2 * c1;
                    u1 = z;
                }
                c2 = (float)Math.Sqrt((1.0f - c1) / 2.0f);
                if (forward)
                    c2 = -c2;
                c1 = (float)Math.Sqrt((1.0f + c1) / 2.0f);
            }

        }
        
    }

    public class ComplexArray
    {
        public int Length => buffer.Length / 2;

        private float[] buffer = null;

        public ComplexArray(int length)
        {
            buffer = new float[length * 2];
        }


        private float get(int index, int part)
        {
            return buffer[index * 2 + part];
        }

        private void set(int index, int part, float value)
        {
            buffer[index * 2 + part] = value;
        }

        public float this[int index, int part]
        {
            get { return get(index, part); }
            set { set(index, part, value); }
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
