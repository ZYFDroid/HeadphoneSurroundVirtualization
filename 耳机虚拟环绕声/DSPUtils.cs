using NAudio.Dsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 耳机虚拟环绕声
{
    public static class MathHelper
    {
        public static float clamp(float x)
        {
            return x < -1 ? -1 : (x > 1 ? 1 : x);
        }

        public static float clamp(float x,float min,float max)
        {
            return x < min ? min : (x > max ? max : x);
        }
        public static float db2linear(float dB)
        {
            return (float) Math.Pow(10d, dB / 20.0);
        }

        public static float linear2db(float x)
        {
            return (float)(20.0 * Math.Log10(x / 1.0));
        }
    }
}
