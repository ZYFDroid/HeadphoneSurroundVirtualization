using System;
using System.Runtime.InteropServices;
using 耳机虚拟环绕声;

namespace FFTConvolver
{
    public static class FFTConvolver
    {

        public const string dllName = "fftconvolver_214.dll";

        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool init_mem();

        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool set_sr_ir(ref float ir,int irLen,int chanCount);



        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern bool set_en_ir(ref float ll, ref float lr, ref float rl, ref float rr,int irlen);



        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void set_cmp_param(float srate, float gate, float ratio, float attack, float release);



        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void set_bypass(bool bypass);



        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void set_fc2f(bool fc2f);



        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void set_master_gain(float gain);




        public delegate void pro_call_(ref float input, ref float output, ref float meters, int offset, int outOffset, int len);

        public static pro_call_ pro_call;

        [DllImport("kernel32.dll")]
        private extern static IntPtr LoadLibrary(String path);

        [DllImport("kernel32.dll")]
        private extern static IntPtr GetProcAddress(IntPtr lib, String funcName);

        [DllImport("kernel32.dll")]
        private extern static bool FreeLibrary(IntPtr lib);

        private static IntPtr _dllHandle = IntPtr.Zero;
        public static void Init()
        {
            if (_dllHandle == IntPtr.Zero)
            {
                IntPtr dllHandle = LoadLibrary(dllName);
                if (dllHandle == IntPtr.Zero)
                {
                    System.Windows.Forms.MessageBox.Show("加载环绕引擎失败");
                    throw new Exception("加载DLL失败");
                }
                IntPtr exportAddress = IntPtr.Zero;

                exportAddress = GetProcAddress(dllHandle, "pro_call");
                pro_call = Marshal.GetDelegateForFunctionPointer<pro_call_>(exportAddress);
                

                _dllHandle = dllHandle;
            }
        }
    }

}