using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace TextCanvas
{
    /// <summary>
    /// 分数类
    /// </summary>
    public class FractionBlock : MathBlock
    {
        private LineBlock fractionLine;

        public LineBlock FractionLine
        {
            get { return fractionLine; }
            set { fractionLine = value; }
        }
       
        public FractionBlock()
        {

        }

        public FractionBlock(MathBlock molecule, MathBlock denominator)
        {
            Children.Add(molecule);
            Children.Add(denominator);
        }


        public override void Draw(WorkPanel workPanel, Point parentPosition)
        {
            base.Draw(workPanel, parentPosition);

            var currentPosition = new Point(parentPosition.X + RelativePosition.X, parentPosition.Y + RelativePosition.Y);

            if (Children.Count > 0)
            {
                ////分子
                var molecule = Children.Find(p => p.Vector.Y > 0);
                ////分母
                var denominator = Children.Find(p => p.Vector.Y < 0);

                var numeratorWidth = molecule == null ? 0 : molecule.GetWidth();
                var denominatorWidth = denominator == null ? 0 : denominator.GetWidth();

                
                var lineLength= numeratorWidth >= denominatorWidth ? numeratorWidth : denominatorWidth;
                var heightVSDFS = this.GetHeight() / 2;
                
                ////画分子
                if (molecule != null)
                {
                    var numeratorRelativeX = (lineLength - numeratorWidth) / 2;
                    molecule.RelativePosition = new Point(numeratorRelativeX, 0);
                    molecule.Draw(workPanel, currentPosition);
                }

                var lineMargin= GetFractionLineMarginByFontSize(molecule);
                fractionLine = new LineBlock(new Point(currentPosition.X, currentPosition.Y + molecule.GetHeight()+ lineMargin), new Point(currentPosition.X + lineLength, currentPosition.Y + molecule.GetHeight()+ lineMargin));
                fractionLine.Length = lineLength;
                FractionLine.Margin = lineMargin;

                var blockHeight = molecule.GetHeight();

                ///画分母
                if (denominator != null)
                {
                    var denominatorX = (FractionLine.Length - denominator.GetWidth()) / 2;
                    denominator.RelativePosition = new Point(denominatorX, blockHeight + FractionLine.Margin);
                    denominator.Draw(workPanel, currentPosition);
                }

            }
            
            fractionLine.Draw(workPanel, currentPosition);


        }

        public override double GetHeight()
        {
            double height = 0;
            if (Children!=null&&Children.Count>0)
            {
                foreach (var item in Children)
                {
                    height += item.GetHeight();
                }

                return height;
            }

            return 40;
        }

        private double GetFractionLineMarginByFontSize(Block block)
        {
            if (block is MathBlock)
            {
                var mathBlock = block as MathBlock;
                var resultBlock = mathBlock.Children.Find(p => p is TextBlock);
                var textBlock = resultBlock as TextBlock;
                if (null != textBlock)
                {
                    return (double)textBlock.FontSize / 6;
                }
            }
            else if (block is TextBlock)
            {
                var textBlock = block as TextBlock;
                return (double)textBlock.FontSize / 6;
            }

            return 0;
        }
    }
}
