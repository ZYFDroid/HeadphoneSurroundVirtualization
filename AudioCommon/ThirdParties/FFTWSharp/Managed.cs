// The code in this file is provided courtesy of Tamas Szalay. Some functionality has been added.
// Trimmed for ¶ú»úÐéÄâ»·ÈÆÉù use.
// Orginal version at https://github.com/tszalay/FFTWSharp
// FFTWSharp
// ===========
// Basic C# wrapper for FFTW.
//
// Features
// ============
//    * Unmanaged function calls to main FFTW functions for both single and double precision
//    * Basic managed wrappers for FFTW plans and unmanaged arrays
//    * Test program that demonstrates basic functionality
//
// Notes
// ============
//    * Most of this was written in 2005
//    * Slightly updated since to get it running with Visual Studio Express 2010
//    * If you have a question about FFTW, ask the FFTW people, and not me. I did not write FFTW.
//    * If you have a question about this wrapper, probably still don't ask me, since I wrote it almost a decade ago.

using System;
using System.Runtime.InteropServices;
using System.Numerics;
using System.Threading;

namespace FFTWSharp
{
    #region Single Precision
    /// <summary>
    /// To simplify FFTW memory management
    /// </summary>
    public class fftwf_complexarray
    {
        private IntPtr handle;
        public IntPtr Handle
        { get { return handle; } }

        // The logical length of the array (# of complex numbers, not elements)
        private int length;
        public int Length
        { get { return length; } }

        private float[] tempBuffer = null;

        /// <summary>
        /// Creates a new array of complex numbers
        /// </summary>
        /// <param name="length">Logical length of the array</param>
        public fftwf_complexarray(int length)
        {
            this.length = length;
            this.handle = fftwf.malloc(this.length * 8);
        }

        /// <summary>
        /// Set the data to an array of complex numbers (real + imaginary floats following eachother)
        /// </summary>
        private void SetData(float[] data)
        {
            if (data.Length / 2 != this.length)
                throw new ArgumentException("Array length mismatch!");

            Marshal.Copy(data, 0, handle, this.length * 2);
        }

        /// <summary>
        /// Get the full array of floats out (alternating real and imaginary)
        /// </summary>
        private float[] GetData()
        {
            float[] dataf = new float[length * 2];
            Marshal.Copy(handle, dataf, 0, length * 2);

            return dataf;
        }


        public void Cache()
        {
            tempBuffer = GetData();
        }

        public void Apply()
        {
            SetData(tempBuffer);
            tempBuffer = null;
        }

        private float get(int index,int part)
        {
            return tempBuffer[index * 2 + part];
        }

        private void set(int index,int part,float value)
        {
            tempBuffer[index * 2 + part] = value;
        }

        public float this[int index,int part]
        {
            get { return get(index, part); }
            set { set(index, part, value); }
        }

        ~fftwf_complexarray()
        {
            fftwf.free(handle);
        }
    }

    /// <summary>
    /// Creates, stores, and destroys fftw plans
    /// </summary>
    public class fftwf_plan
    {
        static Mutex FFTW_Lock = new Mutex();

        protected IntPtr handle;
        public IntPtr Handle
        { get { return handle; } }

        public void Execute()
        {
            fftwf.execute(handle);
        }

        ~fftwf_plan()
        {
            fftwf.destroy_plan(handle);
        }

        #region Plan Creation
        //Complex<->Complex transforms
        public static fftwf_plan dft_1d(int n, fftwf_complexarray input, fftwf_complexarray output, fftw_direction direction, fftw_flags flags)
        {
            FFTW_Lock.WaitOne();
            fftwf_plan p = new fftwf_plan();
            p.handle = fftwf.dft_1d(n, input.Handle, output.Handle, direction, flags);
            FFTW_Lock.ReleaseMutex();

            return p;
        }

        #endregion
    }
    #endregion
}