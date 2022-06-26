namespace 耳机虚拟环绕声.ThirdParties.EqualizerAPO
{
    // Bi-quad filter 算法从EqualizerAPO
    public class BiQuad
    {
        private static bool IS_DENORMAL(float d)
        {
            float dBMin = 1e-64f;
            return d < dBMin && d > -dBMin;
        }

        float[] a = new float[4];
        float a0;
        float x1, x2;
        float y1, y2;

        public void removeDenormals()
        {
            if (IS_DENORMAL(x1))
                x1 = 0.0f;
            if (IS_DENORMAL(x2))
                x2 = 0.0f;
            if (IS_DENORMAL(y1))
                y1 = 0.0f;
            if (IS_DENORMAL(y2))
                y2 = 0.0f;
        }
        public float process(float sample)
        {
            float result = a0 * sample + a[1] * x2 + a[0] * x1 - a[3] * y2 - a[2] * y1;

            x2 = x1;
            x1 = sample;

            y2 = y1;
            y1 = result;

            return result;
        }

        void setCoefficients(float[] ain, float[] a0in)
        {
            for (int i = 0; i < 4; i++)
                a[i] = ain[i];
            a0 = a0in[0];
        }

        const float pi = 3.141592654f;
        float sin(float f) { return (float)System.Math.Sin(f); }
        float cos(float f) { return (float)System.Math.Cos(f); }
        float log10(float f) { return (float)System.Math.Log10(f); }
        float sqrt(float f) { return (float)System.Math.Sqrt(f); }
        float pow(float f1,float f2) { return (float)System.Math.Pow(f1,f2); }
        float gainAt(float freq,float srate)
        {
            float omega = 2 * pi * freq / srate;
            float sn = sin(omega / 2.0f);
            float phi = sn * sn;
            float b0 = this.a0;
            float b1 = this.a[0];
            float b2 = this.a[1];
            float a0 = 1.0f;
            float a1 = this.a[2];
            float a2 = this.a[3];

            float dbGain = 10 * log10(pow(b0 + b1 + b2, 2) - 4 * (b0 * b1 + 4 * b0 * b2 + b1 * b2) * phi + 16 * b0 * b2 * phi * phi)
                - 10 * log10(pow(a0 + a1 + a2, 2) - 4 * (a0 * a1 + 4 * a0 * a2 + a1 * a2) * phi + 16 * a0 * a2 * phi * phi);

            return dbGain;
        }

        private void setBiquadFilter(float dbGain, float freq, float srate, float bandwidthOrQOrS, bool isBandwidthOrS)
        {
            float A = pow(10, dbGain / 40);
            float omega = 2 * pi * freq / srate;
            float sn = sin(omega);
            float cs = cos(omega);
            float alpha;
            alpha = sn / (2 * bandwidthOrQOrS);
            float beta = 2 * sqrt(A) * alpha;

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
            quad.setBiquadFilter(dbGain, centerFrequent, sampleRate, Q, false);
            return quad;
        }
    }
}
