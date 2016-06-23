using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace TextCanvas
{
    [Serializable]
    public class TextBlock : Block
    {
        public TextBlock()
        {

        }

        public TextBlock(string text, int fontSize, Brush brush, FontStyle fontStyle, FontWeight fongWeight, FontStretch fontStretch)
        {
            this.text = text;
            this.fontSize = fontSize;
            this.brush = brush;
            this.fontStyle = fontStyle;
            this.fontWeight = fongWeight;
            this.fontStretch = fontStretch;
        }

        private string text;

        private int fontSize;


        private string fontFamily;

        private FontStyle fontStyle;

        private FontWeight fontWeight;

        private FontStretch fontStretch;

        private Brush brush;
        
        public Brush Brush
        {
            get { return brush; }
            set { brush = value; }
        }


        public FontStretch FontStretch
        {
            get { return fontStretch; }
            set { fontStretch = value; }
        }


        public FontWeight FontWeight
        {
            get { return fontWeight; }
            set { fontWeight = value; }
        }


        public FontStyle FontStyle
        {
            get { return fontStyle; }
            set { fontStyle = value; }
        }


        public string FontFamily
        {
            get { return fontFamily; }
            set { fontFamily = value; }
        }


        public int FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }


        public string Text
        {
            get { return text; }
            set { text = value; }
        }



        public override double GetHeight()
        {
            FormattedText textFormat = this.GetFormattedText();
            return textFormat.Height;
        }

        public override double GetPosition()
        {
            throw new NotImplementedException();
        }

        public override double GetWidth()
        {
            FormattedText textFormat = this.GetFormattedText();

            return textFormat.WidthIncludingTrailingWhitespace;
        }

        public override void Draw(WorkPanel workPanel,Point parentPosition)
        {
            FormattedText textFormat = this.GetFormattedText();

            DrawingVisual visual = new DrawingVisual();

            Point drawPoint = new Point();
            if (parentPosition == null)
            {
                throw new Exception("绘制父元素位置为空");
            }

            drawPoint.X = parentPosition.X + this.RelativePosition.X;
            drawPoint.Y = parentPosition.Y + this.RelativePosition.Y;
            ParentPosition = parentPosition;

            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawText(textFormat, drawPoint);
            }

            workPanel.AddVisual(visual);

            this.Width = textFormat.WidthIncludingTrailingWhitespace;

            this.Height = textFormat.MaxTextHeight;

        }

        private FormattedText GetFormattedText()
        {
            //Calibri
          return  new FormattedText(Text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(new FontFamily("Times New Roman"),
                                                  FontStyles.Italic,
                                                  FontWeights.Normal,
                                                  FontStretches.Normal), FontSize, Brush);
        }
    }
}