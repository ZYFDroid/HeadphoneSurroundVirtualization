namespace 耳机虚拟环绕声.ThirdParties.EqualizerAPO
{
    // 因为觉得NAudio自带的BiquadFilter音质不好所以手动照着EqualizerAPO写了一遍
    // 然后发现音质比EqualizerAPO差的原因是自己的代码有bug
    public class BiQuad
    {


        float[] a = new float[4];
        float a0;
        float x1, x2;
        float y1, y2;


        public float process(float sample)
        {
            float result = a0 * sample + a[1] * x2 + a[0] * x1 - a[3] * y2 - a[2] * y1;

            x2 = x1;
            x1 = sample;

            y2 = y1;
            y1 = result;

            return result;
        }
        public void processBatch(float[] samples,int offset,int count,int channels=2,int channel = 0)
        {
            for (int ptr = offset+ channel; ptr < offset+count; ptr+= channels)
            {
                float sample = samples[ptr];
                float result = a0 * sample + a[1] * x2 + a[0] * x1 - a[3] * y2 - a[2] * y1;

                x2 = x1;
                x1 = sample;

                y2 = y1;
                y1 = result;

                if (float.IsNaN(result)) { result = 0;resetState(); }
                if (float.IsInfinity(result)) { result = 0;resetState(); }
                
                result = MathHelper.clamp(result, minOut, maxOut);

                samples[ptr] = result;
            }
        }

        private float minOut = -MathHelper.db2linear(15);
        private float maxOut = MathHelper.db2linear(15);

        private void resetState()
        {
            x1 = 0;x2 = 0;y1 = 0;y2 = 0;
        }


        const float pi = 3.141592654f;
        float sin(float f) { return (float)System.Math.Sin(f); }
        float cos(float f) { return (float)System.Math.Cos(f); }
        float pow(float f1,float f2) { return (float)System.Math.Pow(f1,f2); }


        private void setBiquadFilter(float dbGain, float freq, float srate, float bandwidthOrQOrS)
        {
            float A = pow(10, dbGain / 40);
            float omega = 2 * pi * freq / srate;
            float sn = sin(omega);
            float cs = cos(omega);
            float alpha;
            alpha = sn / (2 * bandwidthOrQOrS);

            float b0, b1, b2, a0, a1, a2;
            //case peaking
            b0 = 1 + (alpha * A);
            b1 = -2 * cs;
            b2 = 1 - (alpha * A);
            a0 = 1 + (alpha / A);
            a1 = -2 * cs;
            a2 = 1 - (alpha / A);


            this.a0 = b0 / a0;
            this.a[0] = b1 / a0;
            this.a[1] = b2 / a0;
            this.a[2] = a1 / a0;
            this.a[3] = a2 / a0;

            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
        }

        public static BiQuad PeakEQ(float sampleRate,float centerFrequent,float Q,float dbGain)
        {
            BiQuad quad = new BiQuad();
            quad.setBiquadFilter(dbGain, centerFrequent, sampleRate, Q);
            return quad;
        }
    }
}
