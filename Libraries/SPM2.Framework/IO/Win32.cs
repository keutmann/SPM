using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SPM2.Framework.IO
{
    public static class Win32
    {
        public const int SW_SHOWNORMAL = 1;

        [DllImport("shell32.dll")]
        public static extern bool ShellExecuteEx(
            [In, Out] SHELLEXECUTEINFO execInfo);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetDiskFreeSpace(string lpRootPathName,
            out uint lpSectorsPerCluster, out uint lpBytesPerSector,
            out uint lpNumberOfFreeClusters, out uint lpTotalNumberOfClusters);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetCompressedFileSize(
            string lpFileName, out uint lpFileSizeHigh);
    }

    [StructLayout(LayoutKind.Sequential)]
    public class SHELLEXECUTEINFO
    {
        public int cbSize;
        public int fMask;
        public IntPtr hwnd;
        public string lpVerb;
        public string lpFile;
        public string lpParameters;
        public string lpDirectory;
        public int nShow;
        public IntPtr hInstApp;
        public int lpIDList;
        public string lpClass;
        public IntPtr hkeyClass;
        public int dwHotKey;
        public IntPtr hIcon;
        public IntPtr hProcess;
    }

    public enum SEE_MASK
    {
        CLASSNAME = 0x01,
        CLASSKEY = 0x03,
        IDLIST = 0x04,
        INVOKEIDLIST = 0x0c,
        ICON = 0x10,
        HOTKEY = 0x20,
        NOCLOSEPROCESS = 0x40,
        CONNECTNETDRV = 0x80,
        FLAG_DDEWAIT = 0x100,
        DOENVSUBST = 0x200,
        FLAG_NO_UI = 0x400,
        NO_CONSOLE = 0x8000,
        UNICODE = 0x10000,
        HMONITOR = 0x200000
    }
}