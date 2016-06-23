using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace TextCanvas
{
    public class LineBlock : DrawBlock
    {
        private Point startPoint;

        private Point endPoint;
        private double margin;
        private double length;
        private double defaultLength = 10;

        public LineBlock(Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        public override void Draw(WorkPanel workPanel, Point parentPosition)
        {
            DrawingVisual visual = new DrawingVisual();
            ParentPosition = parentPosition;

            using (DrawingContext dc = visual.RenderOpen())
            {

                dc.DrawLine(new Pen(Brushes.Black, 1), startPoint, endPoint);
                workPanel.AddVisual(visual);
            }
        }

        public double DefaultLength
        {
            get { return defaultLength; }
            set { defaultLength = value; }
        }

        public Point EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        public Point StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        public double Margin
        {
            get { return margin; }
            set { margin = value; }
        }

        public double Length
        {
            get { return length; }
            set { length = value < defaultLength ? defaultLength : value; }
        }
    }
}
