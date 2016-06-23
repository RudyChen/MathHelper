using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextCanvas
{
    /// <summary>
    /// 表示方向
    /// </summary>
    public struct Vector
    {
        private double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
