/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2021-10 </edited>
namespace Ordisoftware.Core;

using System.Runtime.InteropServices;

[SuppressMessage("CodeQuality", "IDE0079:Retirer la suppression inutile", Justification = "N/A")]
[SuppressMessage("Naming", "GCop204:Rename the variable '{0}' to something clear and meaningful.", Justification = "<En attente>")]
[SuppressMessage("Naming", "GCop209:Use PascalCasing for {0} names", Justification = "<En attente>")]
[SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "N/A")]
[SuppressMessage("Performance", "U2U1004:Public value types should implement equality", Justification = "N/A")]
[SuppressMessage("Major Code Smell", "S4200:Native methods should be wrapped", Justification = "N/A")]
[SuppressMessage("Major Code Smell", "S4214:\"P/Invoke\" methods should not be visible", Justification = "N/A")]
[SuppressMessage("Interoperability", "CA1401:Les P/Invoke ne doivent pas �tre visibles", Justification = "N/A")]
[SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "N/A")]
[SuppressMessage("Performance", "SS017:Structs should implement Equals(), GetHashCode(), and ToString().", Justification = "N/A")]
static public class NativeMethods
{

  #region WorkStation

  public const int WM_QUERYENDSESSION = 0x11;

  [DllImport("user32.dll", SetLastError = true)]
  static public extern bool LockWorkStation();

  [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  static public extern EXECUTIONSTATE SetThreadExecutionState(EXECUTIONSTATE esFlags);

  [DllImport("powrprof.dll", SetLastError = true)]
  static public extern bool IsPwrSuspendAllowed();

  [Flags]
  public enum EXECUTIONSTATE : uint
  {
    None = 0,
    EsSystemRequired = 0x00000001,
    EsDisplayRequired = 0x00000002,
    EsAwaymodeRequired = 0x00000040,
    EsContinuous = 0x80000000
  }

  public const EXECUTIONSTATE SleepDisallow = EXECUTIONSTATE.EsContinuous
                                            | EXECUTIONSTATE.EsSystemRequired
                                            | EXECUTIONSTATE.EsAwaymodeRequired;

  public const EXECUTIONSTATE SleepAllow = EXECUTIONSTATE.EsContinuous;

  #endregion

  #region Windows

  public const int WM_DRAWCLIPBOARD = 0x308;

  public const int MAX_PATH = 260;

  public const uint SW_RESTORE = 0x09;

  [StructLayout(LayoutKind.Sequential)]
  public struct RECT
  {
    public int left;
    public int top;
    public int right;
    public int bottom;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct HARDWAREINPUT
  {
    public uint Msg;
    public ushort ParamL;
    public ushort ParamH;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct KEYBDINPUT
  {
    public ushort Vk;
    public ushort Scan;
    public uint Flags;
    public uint Time;
    public IntPtr ExtraInfo;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct MOUSEINPUT
  {
    public int X;
    public int Y;
    public uint MouseData;
    public uint Flags;
    public uint Time;
    public IntPtr ExtraInfo;
  }

  [StructLayout(LayoutKind.Explicit)]
  public struct MOUSEKEYBDHARDWAREINPUT
  {
    [FieldOffset(0)]
    public HARDWAREINPUT Hardware;
    [FieldOffset(0)]
    public KEYBDINPUT Keyboard;
    [FieldOffset(0)]
    public MOUSEINPUT Mouse;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct INPUT
  {
    public uint Type;
    public MOUSEKEYBDHARDWAREINPUT Data;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct PointStruct
  {
    public int X;
    public int Y;
    public PointStruct(int x, int y)
    {
      X = x;
      Y = y;
    }
  }

  [DllImport("user32.dll")]
  static public extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

  [DllImport("user32.dll", SetLastError = true)]
  static public extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

  [DllImport("user32.dll")]
  static public extern int ShowWindow(IntPtr hWnd, uint Msg);

  [DllImport("user32.dll")]
  [return: MarshalAs(UnmanagedType.Bool)]
  static public extern bool GetCursorPos(out System.Drawing.Point lpPoint);

  [DllImport("user32.dll")]
  static public extern IntPtr WindowFromPoint(PointStruct Point);

  #endregion

  #region WinMedia

  public const int WM_APPCOMMAND = 0x319;
  public const int APPCOMMAND_VOLUME_MUTE = 0x80000;

  [DllImport("winmm.dll", CharSet = CharSet.Unicode)]
  static public extern uint mciSendString(string command, StringBuilder returnValue, int returnLength, IntPtr winHandle);

  #endregion

  #region Screensaver

  public const int WM_SYSCOMMAND = 0x0112;
  public const int SC_SCREENSAVE = 0xF140;
  public const int SPI_GETSCREENSAVERRUNNING = 0x0072;

  [DllImport("user32.dll")]
  static public extern bool SystemParametersInfo(int action, int param, ref int retval, int updini);

  [DllImport("user32.dll")]
  static public extern bool GetWindowRect(HandleRef hWnd, [In, Out] ref RECT rect);

  [DllImport("user32.dll")]
  static public extern IntPtr GetForegroundWindow();

  #endregion

  #region Clipboard

  [DllImport("User32.dll", CharSet = CharSet.Auto)]
  static public extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
  static public IntPtr ClipboardViewerNext { get; set; }

  #endregion

  #region Taskbar

  public const int ABM_GETTASKBARPOS = 5;

  [StructLayout(LayoutKind.Sequential)]
  public struct APPBARDATA
  {
    public int cbSize;
    public IntPtr hWnd;
    public int uCallbackMessage;
    public int uEdge;
    public RECT rc;
    public IntPtr lParam;
  }

  [DllImport("shell32.dll")]
  public static extern IntPtr SHAppBarMessage(int msg, ref APPBARDATA data);

  #endregion

  #region Shell icons

  // https://stackoverflow.com/questions/1309738/how-do-i-get-an-image-for-the-various-messageboximages-or-messageboxicons#25429905

  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "N/A")]
  [SuppressMessage("CodeQuality", "IDE0079:Retirer la suppression inutile", Justification = "N/A")]
  public enum SHSTOCKICONID : uint
  {
    SIID_DOCNOASSOC = 0,
    SIID_DOCASSOC = 1,
    SIID_APPLICATION = 2,
    SIID_FOLDER = 3,
    SIID_FOLDEROPEN = 4,
    SIID_DRIVE525 = 5,
    SIID_DRIVE35 = 6,
    SIID_DRIVEREMOVE = 7,
    SIID_DRIVEFIXED = 8,
    SIID_DRIVENET = 9,
    SIID_DRIVENETDISABLED = 10,
    SIID_DRIVECD = 11,
    SIID_DRIVERAM = 12,
    SIID_WORLD = 13,
    SIID_SERVER = 15,
    SIID_PRINTER = 16,
    SIID_MYNETWORK = 17,
    SIID_FIND = 22,
    SIID_HELP = 23,
    SIID_SHARE = 28,
    SIID_LINK = 29,
    SIID_SLOWFILE = 30,
    SIID_RECYCLER = 31,
    SIID_RECYCLERFULL = 32,
    SIID_MEDIACDAUDIO = 40,
    SIID_LOCK = 47,
    SIID_AUTOLIST = 49,
    SIID_PRINTERNET = 50,
    SIID_SERVERSHARE = 51,
    SIID_PRINTERFAX = 52,
    SIID_PRINTERFAXNET = 53,
    SIID_PRINTERFILE = 54,
    SIID_STACK = 55,
    SIID_MEDIASVCD = 56,
    SIID_STUFFEDFOLDER = 57,
    SIID_DRIVEUNKNOWN = 58,
    SIID_DRIVEDVD = 59,
    SIID_MEDIADVD = 60,
    SIID_MEDIADVDRAM = 61,
    SIID_MEDIADVDRW = 62,
    SIID_MEDIADVDR = 63,
    SIID_MEDIADVDROM = 64,
    SIID_MEDIACDAUDIOPLUS = 65,
    SIID_MEDIACDRW = 66,
    SIID_MEDIACDR = 67,
    SIID_MEDIACDBURN = 68,
    SIID_MEDIABLANKCD = 69,
    SIID_MEDIACDROM = 70,
    SIID_AUDIOFILES = 71,
    SIID_IMAGEFILES = 72,
    SIID_VIDEOFILES = 73,
    SIID_MIXEDFILES = 74,
    SIID_FOLDERBACK = 75,
    SIID_FOLDERFRONT = 76,
    SIID_SHIELD = 77,
    SIID_WARNING = 78,
    SIID_INFO = 79,
    SIID_ERROR = 80,
    SIID_KEY = 81,
    SIID_SOFTWARE = 82,
    SIID_RENAME = 83,
    SIID_DELETE = 84,
    SIID_MEDIAAUDIODVD = 85,
    SIID_MEDIAMOVIEDVD = 86,
    SIID_MEDIAENHANCEDCD = 87,
    SIID_MEDIAENHANCEDDVD = 88,
    SIID_MEDIAHDDVD = 89,
    SIID_MEDIABLURAY = 90,
    SIID_MEDIAVCD = 91,
    SIID_MEDIADVDPLUSR = 92,
    SIID_MEDIADVDPLUSRW = 93,
    SIID_DESKTOPPC = 94,
    SIID_MOBILEPC = 95,
    SIID_USERS = 96,
    SIID_MEDIASMARTMEDIA = 97,
    SIID_MEDIACOMPACTFLASH = 98,
    SIID_DEVICECELLPHONE = 99,
    SIID_DEVICECAMERA = 100,
    SIID_DEVICEVIDEOCAMERA = 101,
    SIID_DEVICEAUDIOPLAYER = 102,
    SIID_NETWORKCONNECT = 103,
    SIID_INTERNET = 104,
    SIID_ZIPFILE = 105,
    SIID_SETTINGS = 106,
    SIID_DRIVEHDDVD = 132,
    SIID_DRIVEBD = 133,
    SIID_MEDIAHDDVDROM = 134,
    SIID_MEDIAHDDVDR = 135,
    SIID_MEDIAHDDVDRAM = 136,
    SIID_MEDIABDROM = 137,
    SIID_MEDIABDR = 138,
    SIID_MEDIABDRE = 139,
    SIID_CLUSTEREDDRIVE = 140,
    SIID_MAX_ICONS = 175
  }

  [Flags]
  [SuppressMessage("Critical Code Smell", "S2346:Flags enumerations zero-value members should be named \"None\"", Justification = "N/A")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "N/A")]
  [SuppressMessage("CodeQuality", "IDE0079:Retirer la suppression inutile", Justification = "N/A")]
  public enum SHGSI : uint
  {
    SHGSI_LARGEICON = 0,
    SHGSI_SMALLICON = 0x000000001,
    SHGSI_ICON = 0x000000100,
    SHGSI_SYSICONINDEX = 0x000004000,
    SHGSI_LINKOVERLAY = 0x000008000,
    SHGSI_SELECTED = 0x000010000,
    SHGSI_SHELLICONSIZE = 0x000000004
  }

  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public struct SHSTOCKICONINFO
  {
    public uint cbSize;
    public IntPtr hIcon;
    public int iSysIconIndex;
    public int iIcon;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
    public string szPath;
  }

  [DllImport("Shell32.dll", SetLastError = false)]
  static public extern Int32 SHGetStockIconInfo(SHSTOCKICONID siid, SHGSI uFlags, ref SHSTOCKICONINFO psii);

  #endregion

  #region RichTextBox

  // Constants from the Platform SDK.
  public const int EM_SETEVENTMASK = 1073;
  public const int EM_GETPARAFORMAT = 1085;
  public const int EM_SETPARAFORMAT = 1095;
  public const int EM_SETTYPOGRAPHYOPTIONS = 1226;
  public const int WM_SETREDRAW = 11;
  public const int TO_ADVANCEDTYPOGRAPHY = 1;
  public const int PFM_ALIGNMENT = 8;
  public const int SCF_SELECTION = 1;

  // It makes no difference if we use PARAFORMAT or
  // PARAFORMAT2 here, so I have opted for PARAFORMAT2.
  [StructLayout(LayoutKind.Sequential)]
  public struct PARAFORMAT
  {
    public int cbSize;
    public uint dwMask;
    public short wNumbering;
    public short wReserved;
    public int dxStartIndent;
    public int dxRightIndent;
    public int dxOffset;
    public short wAlignment;
    public short cTabCount;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    public int[] rgxTabs;

    // PARAFORMAT2 from here onwards.
    public int dySpaceBefore;
    public int dySpaceAfter;
    public int dyLineSpacing;
    public short sStyle;
    public byte bLineSpacingRule;
    public byte bOutlineLevel;
    public short wShadingWeight;
    public short wShadingStyle;
    public short wNumberingStart;
    public short wNumberingStyle;
    public short wNumberingTab;
    public short wBorderSpace;
    public short wBorderWidth;
    public short wBorders;
  }

  [DllImport("user32.dll", CharSet = CharSet.Auto)]
  static public extern int SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);

  [DllImport("user32.dll", CharSet = CharSet.Auto)]
  static public extern int SendMessage(HandleRef hWnd, int msg, int wParam, ref PARAFORMAT lp);

  #endregion

}
