using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace TextCanvas
{
    /// <summary>
    /// 根式块
    /// </summary>
    public class RadicalBlock : MathBlock
    {
        public RadicalBlock()
        {

        }

        private double symbolWidth = 12;

        public double SymbolWidth
        {
            get { return symbolWidth; }
            set { symbolWidth = value; }
        }


        public RadicalBlock(MathBlock radicalBlock)
        {
            this.Children.Add(radicalBlock);
        }

        public override void Draw(WorkPanel workPanel, Point parentPosition)
        {
            base.Draw(workPanel, parentPosition);

            var currentPosition = new Point(parentPosition.X + RelativePosition.X, parentPosition.Y + RelativePosition.Y);

            if (this.Children.Count > 0)
            {
                var item = this.Children.First();
                var contentPosition = new Point(currentPosition.X + SymbolWidth, currentPosition.Y + 2);
                item.Draw(workPanel, contentPosition);
                var length = item.GetWidth();
                var height = item.GetHeight();
                height = height == 0 ? 12 : height;
                this.DrawRadicalSymbol(workPanel, currentPosition, height, length);

            }
        }

        private void DrawRadicalSymbol(WorkPanel workPanel, Point currentPosition, double height, double length)
        {
            var startPointY = currentPosition.Y + height * 2 / 3;
            var startPoint = new Point(currentPosition.X, startPointY);

            var secondPoint = new Point(startPoint.X + 3, startPoint.Y - 2);

            var thirdPoint = new Point(currentPosition.X + SymbolWidth / 2, currentPosition.Y + height);

            var endPoint = new Point(currentPosition.X + SymbolWidth, currentPosition.Y);

            DrawingVisual visual = new DrawingVisual();
            using (DrawingContext drawContext = visual.RenderOpen())
            {
                SolidColorBrush drawBrush = new SolidColorBrush() { Color = Colors.Black };
                Pen drawPen = new Pen(drawBrush, 1);
                var lineStart = new Point(currentPosition.X + symbolWidth, currentPosition.Y);
                var lineEnd = new Point(currentPosition.X + length + symbolWidth + 2, currentPosition.Y);
                drawContext.DrawLine(drawPen, lineStart, lineEnd);
                drawContext.DrawLine(drawPen, startPoint, secondPoint);
                drawContext.DrawLine(drawPen, secondPoint, thirdPoint);
                drawContext.DrawLine(drawPen, thirdPoint, endPoint);
                workPanel.AddVisual(visual);
            }
        }
    }
}
