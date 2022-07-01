/*
The MIT License (MIT)

Copyright (c) 2015

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Runtime.InteropServices;

namespace EarTrumpet.Interop.MMDeviceAPI
{
    // W10_TH1: CA286FC3-91FD-42C3-8E9B-CAAFA66242E3
    // W10_TH2: 6BE54BE8-A068-4875-A49D-0C2966473B11
    // Win7-Win8, W10_RS1-Present:
    [Guid("F8679F50-850A-41CF-9C72-430F290290C8")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPolicyConfigWin7
    {
        void Unused1();
        void Unused2();
        void Unused3();
        void Unused4();
        void Unused5();
        void Unused6();
        void Unused7();
        void Unused8();
        void GetPropertyValue([MarshalAs(UnmanagedType.LPWStr)]string wszDeviceId, ref PROPERTYKEY pkey, ref PropVariant pv);
        void SetPropertyValue([MarshalAs(UnmanagedType.LPWStr)]string wszDeviceId, ref PROPERTYKEY pkey, ref PropVariant pv);
        void SetDefaultEndpoint([MarshalAs(UnmanagedType.LPWStr)]string wszDeviceId, ERole eRole);
        void SetEndpointVisibility([MarshalAs(UnmanagedType.LPWStr)]string wszDeviceId, [MarshalAs(UnmanagedType.I2)]short isVisible);
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct PROPERTYKEY
    {
        public Guid fmtid;
        public UIntPtr pid;

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var pkey = ((PROPERTYKEY)obj);
            return pkey.fmtid == fmtid && pkey.pid == pid;
        }

        public override int GetHashCode()
        {
            return fmtid.GetHashCode() + pid.GetHashCode();
        }
    }

    [ComImport]
    [Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPropertyStore
    {
        [PreserveSig]
        int GetCount([Out] out uint cProps);
        [PreserveSig]
        int GetAt([In] uint iProp, out PROPERTYKEY pkey);
        PropVariant GetValue([In] ref PROPERTYKEY key);
        [PreserveSig]
        int SetValue([In] ref PROPERTYKEY key, [In] ref PropVariant pv);
        [PreserveSig]
        int Commit();
    }

    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct PropArray
    {
        internal uint cElems;
        internal IntPtr pElems;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct PropVariant
    {
        [FieldOffset(0)] public VarEnum varType;
        [FieldOffset(2)] public ushort wReserved1;
        [FieldOffset(4)] public ushort wReserved2;
        [FieldOffset(6)] public ushort wReserved3;
        [FieldOffset(8)] public byte bVal;
        [FieldOffset(8)] public sbyte cVal;
        [FieldOffset(8)] public ushort uiVal;
        [FieldOffset(8)] public short iVal;
        [FieldOffset(8)] public uint uintVal;
        [FieldOffset(8)] public int intVal;
        [FieldOffset(8)] public ulong ulVal;
        [FieldOffset(8)] public long lVal;
        [FieldOffset(8)] public float fltVal;
        [FieldOffset(8)] public double dblVal;
        [FieldOffset(8)] public short boolVal;
        [FieldOffset(8)] public IntPtr pclsidVal;
        [FieldOffset(8)] public IntPtr pszVal;
        [FieldOffset(8)] public IntPtr pwszVal;
        [FieldOffset(8)] public IntPtr punkVal;
        [FieldOffset(8)] public PropArray ca;
        [FieldOffset(8)] public System.Runtime.InteropServices.ComTypes.FILETIME filetime;
    }
}