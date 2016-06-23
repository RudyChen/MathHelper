using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace TextCanvas
{
    /// <summary>
    /// 指数块
    /// </summary>
    public class ExponentialBlock : MathBlock
    {

        public ExponentialBlock()
        {

        }

        public ExponentialBlock(MathBlock exponentialBase, MathBlock power)
        {
            this.Children.Add(exponentialBase);
            this.Children.Add(power);
        }

        public override void Draw(WorkPanel workPanel, Point parentPosition)
        {
            base.Draw(workPanel, parentPosition);

            var currentPosition = new Point(parentPosition.X + RelativePosition.X, parentPosition.Y + RelativePosition.Y);

            if (Children.Count > 0)
            {
                var power = Children.Find(p => p.Vector.X == 1 && p.Vector.Y == 1);
                var exponetialBase = Children.Find(p => p.Vector.X == 0 && p.Vector.Y == 0);

                if (exponetialBase != null)
                {
                    ////获取底数的宽度
                    var exponenttialBaseWidth = exponetialBase.GetWidth();

                    ////画底数
                    exponetialBase.Draw(workPanel, currentPosition);

                    var powerPosition = new Point(currentPosition.X + 2 + exponenttialBaseWidth, currentPosition.Y - 6);

                    if (null != power)
                    {
                        power.Draw(workPanel, powerPosition);
                    }
                }
            }
        }
    }
}
