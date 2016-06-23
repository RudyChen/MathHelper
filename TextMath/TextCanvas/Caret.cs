using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace TextCanvas
{
    public class Caret : FrameworkElement
    {
        Point location;

        public double CaretLength { get; set; }
        bool isHorizontal = false;

        public static readonly DependencyProperty VisibleProperty = DependencyProperty.Register("Visible", typeof(bool), typeof(Caret), new FrameworkPropertyMetadata(false /* defaultValue */, FrameworkPropertyMetadataOptions.AffectsRender));

        public Caret(bool isHorizontal)
        {
            this.isHorizontal = isHorizontal;
            CaretLength = 18;
            Visible = true;
            
        }

        protected override void OnRender(DrawingContext dc)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.Green);
            Pen pen = new Pen(brush, 2);
            if (Visible)
            {
                dc.DrawLine(pen, location, OtherPoint);
            }
            else if (isHorizontal)
            {
                dc.DrawLine(pen, location, OtherPoint);
            }
        }

        Point OtherPoint
        {
            get
            {
                if (isHorizontal)
                {
                    return new Point(Left + CaretLength, Top);
                }
                else
                {
                    return new Point(Left, VerticalCaretBottom);
                }
            }
        }

        public void ToggleVisibility()
        {
            Dispatcher.Invoke(new Action(() => { Visible = !Visible; }));
        }

        bool Visible
        {
            get
            {
                return (bool)GetValue(VisibleProperty);
            }
            set
            {
                SetValue(VisibleProperty, value);
            }
        }

        public Point Location
        {
            get { return location; }
            set
            {
                location.X = Math.Floor(value.X) + .5;
                location.Y = Math.Floor(value.Y) + .5;
                if (Visible)
                {
                    Visible = false;
                }
            }
        }

        public double Left
        {
            get { return location.X; }
            set
            {
                location.X = Math.Floor(value) + .5;
                if (Visible)
                {
                    Visible = false;
                }
            }
        }

        public double Top
        {
            get { return location.Y; }
            set
            {
                location.Y = Math.Floor(value) + .5;
                if (Visible)
                {
                    Visible = false;
                }
            }
        }

        public double VerticalCaretBottom
        {
            get { return location.Y + CaretLength; }
        }
    }
}
