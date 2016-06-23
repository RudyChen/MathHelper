using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace TextCanvas
{
    /// <summary>
    /// 抽象基类
    /// </summary>
    public abstract class Block
    {
        private Point relativePosition;

        private double width;

        private double height;

        private Vector vector;
        private Point parentPosition;

        public Point ParentPosition
        {
            get { return parentPosition; }
            set { parentPosition = value; }
        }

        public Vector Vector
        {
            get { return vector; }
            set { vector = value; }
        }

        /// <summary>
        /// 高度
        /// </summary>
        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// 宽度
        /// </summary>
        public double Width
        {
            get { return width; }
            set { width = value; }
        }


        /// <summary>
        /// 相对位置
        /// </summary>
        public Point RelativePosition
        {
            get { return relativePosition; }
            set { relativePosition = value; }
        }


        public abstract double GetPosition();


        public abstract double GetWidth();

        public abstract double GetHeight();

        public abstract void Draw(WorkPanel workPanel, Point parentPosition);
    }
}
