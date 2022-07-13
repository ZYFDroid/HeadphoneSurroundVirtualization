using System;
using System.Runtime.InteropServices;
using 耳机虚拟环绕声;

namespace FFTConvolver
{
    public static unsafe class FFTConvolver
    {

        public const string dllName = "fftconvolver_200.dll";

        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool init_mem();

        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool set_sr_ir(float* ir,int irLen,int chanCount);



        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool set_en_ir(float* ll, float* lr, float* rl, float* rr,int irlen);



        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void set_cmp_param(float srate, float gate, float ratio, float attack, float release);



        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void set_bypass(bool bypass);



        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void set_fc2f(bool fc2f);



        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void set_master_gain(float gain);



        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool pro_call(float* input, float* output, float* meters, int offset,int outOffset, int len);



    }

}