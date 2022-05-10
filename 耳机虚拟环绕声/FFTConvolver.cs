using System;
using System.Runtime.InteropServices;
using 耳机虚拟环绕声;

namespace FFTConvolver
{
    public static unsafe class FFTConvolver
    {
        public delegate bool ConvolverInitCall(ulong blockSize, float* ir, ulong irLen);
        public delegate void ConvolverProcess(float* input,float* output, ulong len);
        public delegate void ConvolverReset();

        [DllImport("kernel32.dll")]
        private extern static IntPtr LoadLibrary(String path);

        [DllImport("kernel32.dll")]
        private extern static IntPtr GetProcAddress(IntPtr lib, String funcName);

        [DllImport("kernel32.dll")]
        private extern static bool FreeLibrary(IntPtr lib);

        private static IntPtr _dllHandle = IntPtr.Zero;
        public static void Init()
        {
            if(_dllHandle == IntPtr.Zero)
            {
                IntPtr dllHandle = LoadLibrary(Program.FFTConvolverModule);
                if(dllHandle == IntPtr.Zero)
                {
                    System.Windows.Forms.MessageBox.Show("加载DLL失败："+Program.FFTConvolverModule);
                    throw new Exception("加载DLL失败");
                }
                IntPtr exportAddress = IntPtr.Zero;

                exportAddress = GetProcAddress(dllHandle, "con01_init");
                con01_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con01_process");
                con01_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con01_reset");
                con01_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con02_init");
                con02_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con02_process");
                con02_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con02_reset");
                con02_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con03_init");
                con03_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con03_process");
                con03_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con03_reset");
                con03_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con04_init");
                con04_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con04_process");
                con04_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con04_reset");
                con04_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con05_init");
                con05_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con05_process");
                con05_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con05_reset");
                con05_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con06_init");
                con06_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con06_process");
                con06_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con06_reset");
                con06_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con07_init");
                con07_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con07_process");
                con07_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con07_reset");
                con07_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con08_init");
                con08_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con08_process");
                con08_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con08_reset");
                con08_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con09_init");
                con09_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con09_process");
                con09_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con09_reset");
                con09_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con10_init");
                con10_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con10_process");
                con10_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con10_reset");
                con10_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con11_init");
                con11_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con11_process");
                con11_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con11_reset");
                con11_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con12_init");
                con12_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con12_process");
                con12_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con12_reset");
                con12_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con13_init");
                con13_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con13_process");
                con13_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con13_reset");
                con13_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con14_init");
                con14_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con14_process");
                con14_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con14_reset");
                con14_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con15_init");
                con15_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con15_process");
                con15_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con15_reset");
                con15_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con16_init");
                con16_init = Marshal.GetDelegateForFunctionPointer<ConvolverInitCall>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con16_process");
                con16_process = Marshal.GetDelegateForFunctionPointer<ConvolverProcess>(exportAddress);
                exportAddress = GetProcAddress(dllHandle, "con16_reset");
                con16_reset = Marshal.GetDelegateForFunctionPointer<ConvolverReset>(exportAddress);


                _dllHandle = dllHandle;
            }
        }

        public static ConvolverInitCall con01_init;
        public static ConvolverProcess con01_process;
        public static ConvolverReset con01_reset;
        public static ConvolverInitCall con02_init;
        public static ConvolverProcess con02_process;
        public static ConvolverReset con02_reset;
        public static ConvolverInitCall con03_init;
        public static ConvolverProcess con03_process;
        public static ConvolverReset con03_reset;
        public static ConvolverInitCall con04_init;
        public static ConvolverProcess con04_process;
        public static ConvolverReset con04_reset;
        public static ConvolverInitCall con05_init;
        public static ConvolverProcess con05_process;
        public static ConvolverReset con05_reset;
        public static ConvolverInitCall con06_init;
        public static ConvolverProcess con06_process;
        public static ConvolverReset con06_reset;
        public static ConvolverInitCall con07_init;
        public static ConvolverProcess con07_process;
        public static ConvolverReset con07_reset;
        public static ConvolverInitCall con08_init;
        public static ConvolverProcess con08_process;
        public static ConvolverReset con08_reset;
        public static ConvolverInitCall con09_init;
        public static ConvolverProcess con09_process;
        public static ConvolverReset con09_reset;
        public static ConvolverInitCall con10_init;
        public static ConvolverProcess con10_process;
        public static ConvolverReset con10_reset;
        public static ConvolverInitCall con11_init;
        public static ConvolverProcess con11_process;
        public static ConvolverReset con11_reset;
        public static ConvolverInitCall con12_init;
        public static ConvolverProcess con12_process;
        public static ConvolverReset con12_reset;
        public static ConvolverInitCall con13_init;
        public static ConvolverProcess con13_process;
        public static ConvolverReset con13_reset;
        public static ConvolverInitCall con14_init;
        public static ConvolverProcess con14_process;
        public static ConvolverReset con14_reset;
        public static ConvolverInitCall con15_init;
        public static ConvolverProcess con15_process;
        public static ConvolverReset con15_reset;
        public static ConvolverInitCall con16_init;
        public static ConvolverProcess con16_process;
        public static ConvolverReset con16_reset;

    }

}