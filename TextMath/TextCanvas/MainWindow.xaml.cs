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
        IntPtr winPtr = IntPtr.Zero;
        IntPtr canvasPtr= IntPtr.Zero; 
        public MainWindow()
        {
            InitializeComponent();
            DrawingVisual textBoxVisual = new DrawingVisual();
            DrawText(textBoxVisual, new Point(0, 10));
            winPtr= new WindowInteropHelper(this).Handle; 
            //textContainer.Focus();
        }

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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            canvasPtr = ((HwndSource)PresentationSource.FromVisual(textContainer)).Handle;
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            if (winPtr != IntPtr.Zero)
            {
                CaretManager.HideCaret(winPtr);
                CaretManager.DestroyCaret(winPtr);
            }
        }      

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            canvasPtr = ((HwndSource)PresentationSource.FromVisual(textContainer)).Handle;
            if (canvasPtr != IntPtr.Zero)
            {
                CaretManager.HideCaret(canvasPtr);
                //CaretManager.DestroyCaret(canvasPtr);
                CaretManager.DestroyCaret();
            }
            //if (winPtr != IntPtr.Zero)
            //{
            //    CaretManager.HideCaret(winPtr);
            //    CaretManager.DestroyCaret(winPtr);
            //}
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            canvasPtr = ((HwndSource)PresentationSource.FromVisual(textContainer)).Handle;
            if (canvasPtr != IntPtr.Zero)
            {
                CaretManager.CreateCaret(canvasPtr, IntPtr.Zero, 3, 15);
                CaretManager.SetCaretPos(500, 200);
                CaretManager.ShowCaret(canvasPtr);
            }
            //winPtr = new WindowInteropHelper(this).Handle;
            //if (winPtr != IntPtr.Zero)
            //{
            //    CaretManager.CreateCaret(winPtr, IntPtr.Zero, 3, 15);
            //    CaretManager.SetCaretPos(500, 200);
            //    CaretManager.ShowCaret(winPtr);
            //}            
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            canvasPtr = ((HwndSource)PresentationSource.FromVisual(textContainer)).Handle;
            if (canvasPtr != IntPtr.Zero)
            {
                CaretManager.HideCaret(canvasPtr);
                //CaretManager.DestroyCaret(canvasPtr);
                CaretManager.DestroyCaret();
            }
            //if (winPtr != IntPtr.Zero)
            //{
            //    CaretManager.HideCaret(winPtr);
            //    CaretManager.DestroyCaret(winPtr);
            //}
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            //canvasPtr = new WindowInteropHelper(this).Handle;
            //if (canvasPtr != IntPtr.Zero)
            //{
            //    CaretManager.CreateCaret(canvasPtr, IntPtr.Zero, 3, 15);
            //    CaretManager.SetCaretPos(500, 200);
            //    CaretManager.ShowCaret(canvasPtr);
            //}
        }

        private void textContainer_GotFocus(object sender, RoutedEventArgs e)
        {            
            //if (canvasPtr != IntPtr.Zero)
            //{
            //    CaretManager.CreateCaret(canvasPtr, IntPtr.Zero, 3, 15);
            //    CaretManager.SetCaretPos(500, 200);
            //    CaretManager.ShowCaret(canvasPtr);
            //}
        }

        private void textContainer_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (canvasPtr != IntPtr.Zero)
            //{
            //    CaretManager.HideCaret(canvasPtr);
            //    CaretManager.DestroyCaret(canvasPtr);
            //}
        }

        private void textContainer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textContainer.Focus();
        }
    }
}
