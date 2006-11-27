// Copyright 2006 Bret Taylor
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may
// not use this file except in compliance with the License. You may obtain
// a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations
// under the License.

using System;
using System.Runtime.InteropServices;

namespace Stickies {
  /// <summary>
  /// Reproductions of constants from winuser.h.
  /// </summary>
  class WinUser {
    public const int WM_SETFOCUS = 0x0007;
    public const int WM_KILLFOCUS = 0x0008;
    public const int WM_WINDOWPOSCHANGING = 0x0046;
    public const int WM_WINDOWPOSCHANGED = 0x0047;
    public const int WM_NCHITTEST = 0x0084;
    public const int WM_HOTKEY = 0x0312;
    public const int WM_NCLBUTTONDOWN = 0x00A1;
    public const int WM_NCLBUTTONUP = 0x00A2;
    public const int WM_NCLBUTTONDBLCLK = 0x00A3;
    public const int WM_NCRBUTTONDOWN = 0x00A4;
    public const int WM_NCRBUTTONUP = 0x00A5;
    public const int WM_NCRBUTTONDBLCLK = 0x00A6;
    public const int WM_NCMBUTTONDOWN = 0x00A7;
    public const int WM_NCMBUTTONUP = 0x00A8;
    public const int WM_NCMBUTTONDBLCLK = 0x00A9;
    public const int WM_USER = 0x0400;

    public const int HTERROR = -2;
    public const int HTTRANSPARENT = -1;
    public const int HTNOWHERE = 0;
    public const int HTCLIENT = 1;
    public const int HTCAPTION = 2;
    public const int HTSYSMENU = 3;
    public const int HTGROWBOX = 4;
    public const int HTSIZE = HTGROWBOX;
    public const int HTMENU = 5;
    public const int HTHSCROLL = 6;
    public const int HTVSCROLL = 7;
    public const int HTMINBUTTON = 8;
    public const int HTMAXBUTTON = 9;
    public const int HTLEFT = 10;
    public const int HTRIGHT = 11;
    public const int HTTOP = 12;
    public const int HTTOPLEFT = 13;
    public const int HTTOPRIGHT = 14;
    public const int HTBOTTOM = 15;
    public const int HTBOTTOMLEFT = 16;
    public const int HTBOTTOMRIGHT = 17;
    public const int HTBORDER = 18;

    public const int AW_HOR_POSITIVE = 0x00000001;
    public const int AW_HOR_NEGATIVE = 0x00000002;
    public const int AW_VER_POSITIVE = 0x00000004;
    public const int AW_VER_NEGATIVE = 0x00000008;
    public const int AW_CENTER = 0x00000010;
    public const int AW_HIDE = 0x00010000;
    public const int AW_ACTIVATE = 0x00020000;
    public const int AW_SLIDE = 0x00040000;
    public const int AW_BLEND = 0x00080000;

    public const int MOD_ALT = 1;
    public const int MOD_CONTROL = 2;
    public const int MOD_SHIFT = 4;
    public const int MOD_WIN = 8;

    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(String className, String title);
 
    [DllImport("user32.dll")]
    public static extern IntPtr PostMessage(IntPtr hWnd, IntPtr msg, IntPtr wParam, IntPtr lParam);

    [DllImport("User32.dll")]
    public static extern int AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

    [DllImport("User32.dll")]
    public static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);

    [DllImport("User32.dll", SetLastError = true)]
    public static extern int UnregisterHotKey(IntPtr hwnd, int id);

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS {
      public IntPtr hwnd;
      public IntPtr hwndInsertAfter;
      public int x;
      public int y;
      public int cx;
      public int cy;
      public int flags;
    }

    /// <summary>
    /// Converts an LParam representing a Point to a C# point. Equivalent
    /// to the standard LPARAM macros in winuser.h
    /// </summary>
    public static System.Drawing.Point LParamToPoint(System.IntPtr lParam) {
      long lParam64 = lParam.ToInt64();
      return new System.Drawing.Point((int) (lParam64 & 0x0000FFFF),
                                      (int) (lParam64 >> 16));
    }
  }
}
