using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TextCanvas
{
    public static class CaretManager
    {
        [DllImport("user32.dll")]
        public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

        [DllImport("user32.dll")]
        public static extern bool ShowCaret(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool HideCaret(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool SetCaretPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool DestroyCaret(IntPtr hWnd);
    }
}
