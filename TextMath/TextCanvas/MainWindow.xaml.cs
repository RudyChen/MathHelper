using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Interop;

namespace TextCanvas
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Brush textBrush = Brushes.Black;

        private Pen drawingPen = new Pen(Brushes.SteelBlue, 3);

        Caret caret = new Caret(false);
        System.Threading.Timer caretTimer;
        int blinkPeriod = 600;
        IntPtr windowPtr = IntPtr.Zero;
        public MainWindow()
        {
            InitializeComponent();
            DrawingVisual textBoxVisual = new DrawingVisual();
            DrawText(textBoxVisual, new Point(0, 10));
            windowPtr= new WindowInteropHelper(this).Handle; 
            textContainer.Focus();
            CaretManager.CreateCaret(windowPtr,IntPtr.Zero, 3, 24);

        }

        void blinkCaret(Object state)
        {
            caret.ToggleVisibility();          
        }


        DrawingVisual textVisual = null;
        private void DrawTextBoxText_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            

            stopWatch.Start();
           
            stopWatch.Stop();
            Console.WriteLine("used time :" + stopWatch.ElapsedMilliseconds);
        }
        static string customerString = "Ω";
        static char[] specialCharSet = new char[] { 'Ω', '°' };
        public void DrawText(DrawingVisual visual, Point textStartPoint)
        {
            #region 分数
            
           TextBlock upTextBlock = new TextBlock("5x×6y", 24, textBrush, FontStyles.Italic,FontWeights.Normal,FontStretches.Condensed);
           upTextBlock.Vector = new Vector() { X=0,Y=1};

           TextBlock underTextBlock = new TextBlock("3x-4y", 24, textBrush, FontStyles.Italic, FontWeights.Normal, FontStretches.Condensed);
           underTextBlock.Vector = new Vector() {X=0,Y=-1 };

           FractionBlock fractionBlock = new FractionBlock();
           fractionBlock.RelativePosition = new Point(0, 0);
           fractionBlock.Children.Add(upTextBlock);

           fractionBlock.Children.Add(underTextBlock);

           fractionBlock.Draw(textContainer,new Point(280, 100));
           
            #endregion

            #region 指数

            
            TextBlock powerBlock = new TextBlock("2x+4y", 16, textBrush, FontStyles.Italic, FontWeights.Normal, FontStretches.Condensed);
            powerBlock.Vector = new Vector() { X = 1, Y = 1 };


            TextBlock baseBlock = new TextBlock("3x-4y", 24, textBrush, FontStyles.Italic, FontWeights.Normal, FontStretches.Condensed);
            baseBlock.Vector = new Vector() { X = 0, Y = 0 };

            ExponentialBlock exponentialBlock = new ExponentialBlock();
            exponentialBlock.Children.Add(powerBlock);
            exponentialBlock.Children.Add(baseBlock);

            exponentialBlock.Draw(textContainer, new Point(80, 100));
            
            #endregion

            #region 根式
            TextBlock radicalTextBlock = new TextBlock("2x+4y", 24, textBrush, FontStyles.Italic, FontWeights.Normal, FontStretches.Condensed);
            RadicalBlock radicalBlock = new RadicalBlock();
            radicalBlock.Children.Add(radicalTextBlock);
            radicalBlock.Draw(textContainer, new Point(180, 100));
            #endregion


            /*
            using (DrawingContext dc=visual.RenderOpen())
            {
                
                string unicodeString = drawTextBox.Text;
                FormattedText textFormat = new FormattedText(customerString, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(new FontFamily("file:///C:\\Windows\\Fonts\\#微软雅黑"),
                                                 FontStyles.Normal,
                                                 FontWeights.Normal,
                                                 FontStretches.Condensed), 24, textBrush);
                FormattedText topRightFormat = new FormattedText("2X*5÷7Y", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(new FontFamily("file:///C:\\Windows\\Fonts\\#微软雅黑"),
                                                 FontStyles.Normal,
                                                 FontWeights.Normal,
                                                 FontStretches.Condensed), 12, textBrush);
                dc.DrawText(textFormat, textStartPoint);
                double[] textWidthes=textFormat.GetMaxTextWidths();
                double textWidth= textFormat.Width;
                double textWidthWithWhiteSpace= textFormat.WidthIncludingTrailingWhitespace;
                int topX = Convert.ToInt32(textWidthWithWhiteSpace) + 2;

                int topY = (int)(textStartPoint.Y - 2);
                dc.DrawText(topRightFormat, new Point(topX, topY));
                textContainer.AddVisual(visual);
                
                    

            }
            */
        }

        private void Canvas_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.IBeam)
            {
                this.Cursor = Cursors.IBeam;

            }

        }

        private void Canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //IntPtr hwnd = new WindowInteropHelper(this).Handle;
            //CaretManager.CreateCaret(hwnd, IntPtr.Zero, 3, 15);
            //CaretManager.SetCaretPos(500, 200);
            //CaretManager.ShowCaret(hwnd);
            Button testButton = new Button();
            testButton.Width = 40;
            testButton.Height = 24;
            testButton.Content = "click me";
            caret.Location = new Point(20, 30);
            textContainer.Children.Add(testButton);
            Canvas.SetLeft(testButton,50);
            Canvas.SetTop(testButton, 20);
            textContainer.Children.Add(caret);
            caretTimer = new System.Threading.Timer(blinkCaret, null, blinkPeriod, blinkPeriod);
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            //IntPtr hwnd = new WindowInteropHelper(this).Handle;
            //CaretManager.DestoryCaret(hwnd);
            
        }

        private void textContainer_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
