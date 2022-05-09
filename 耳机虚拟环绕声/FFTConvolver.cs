using System.Runtime.InteropServices;

namespace FFTConvolver
{

    public static class FFTConvolver
    {
        const string dllname = "FFTConvolver.dll";

        [DllImport(dllname)]
        public static extern unsafe bool con01_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con01_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con01_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con02_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con02_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con02_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con03_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con03_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con03_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con04_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con04_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con04_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con05_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con05_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con05_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con06_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con06_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con06_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con07_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con07_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con07_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con08_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con08_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con08_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con09_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con09_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con09_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con10_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con10_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con10_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con11_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con11_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con11_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con12_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con12_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con12_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con13_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con13_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con13_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con14_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con14_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con14_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con15_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con15_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con15_reset();
        [DllImport(dllname)]
        public static extern unsafe bool con16_init(ulong blockSize, float* ir, ulong irLen);
        [DllImport(dllname)]
        public static extern unsafe void con16_process(float* input, float* output, ulong len);
        [DllImport(dllname)]
        public static extern void con16_reset();

    }
}