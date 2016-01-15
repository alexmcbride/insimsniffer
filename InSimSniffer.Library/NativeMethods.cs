using System;
using System.Runtime.InteropServices;

namespace InSimSniffer.Library {
    internal static class NativeMethods {
        public const uint CP_ACP = 0;
        public const uint CP_OEMCP = 1;
        public const uint CP_SYMBOL = 42;
        public const uint CP_UTF7 = 65000;
        public const uint CP_UTF8 = 65001;
        public const uint CP_GB2312 = 936;
        public const uint CP_BIG5 = 950;
        public const uint CP_SHIFTJIS = 932;

        [DllImport("kernel32.dll")]
        public static extern int WideCharToMultiByte(uint CodePage, uint dwFlags,
            [MarshalAs(UnmanagedType.LPWStr)] string lpWideCharStr, int cchWideChar,
            [MarshalAs(UnmanagedType.LPArray)] byte[] lpMultiByteStr, int cbMultiByte, IntPtr lpDefaultChar,
            [MarshalAs(UnmanagedType.Bool)] out bool lpUsedDefaultChar);
    }
}
