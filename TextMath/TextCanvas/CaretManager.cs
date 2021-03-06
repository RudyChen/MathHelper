﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

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

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool DestroyCaret();

        private static Point currentPoint;

        public static Point CurrentPoint
        {
            get { return currentPoint; }
            set { currentPoint = value; }
        }

        private static int width;

        public static int Width
        {
            get { return width; }
            set { width = value; }
        }

        private static int height;

        public static int Height
        {
            get { return height; }
            set { height = value; }
        }
                
    }
}
