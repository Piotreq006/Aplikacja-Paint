using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaintApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button btnPen = new Button();
        Button btnEraser = new Button();
        Button clearAll = new Button();
        Button btnRed = new Button();
        Button btnGreen = new Button();
        Button btnBlue = new Button();
        Button btnSave = new Button();
        Button btnLoad = new Button();
        RadioButton big = new RadioButton();
        RadioButton medium = new RadioButton();
        RadioButton small = new RadioButton();

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Paint After 1 year in Russia";
            this.WindowState = System.Windows.WindowState.Maximized;
            SolidColorBrush brsh = new SolidColorBrush(Colors.LightGray);
            MyGrid.Background = (Brush)brsh;


            MyCanvas.Height = System.Windows.SystemParameters.WorkArea.Height - 150;
            MyCanvas.Width = System.Windows.SystemParameters.WorkArea.Width;
            MyCanvas.Margin = new Thickness(0, 0, 0, 0);
            MyCanvas.VerticalAlignment = VerticalAlignment.Bottom;
            MyCanvas.HorizontalAlignment = HorizontalAlignment.Left;

            MyCanvas.UseCustomCursor = true;
            AddButtonOnGreed();

            MyCanvas.DefaultDrawingAttributes.Color = Colors.Red;
            MyCanvas.DefaultDrawingAttributes.Width = 10;
            MyCanvas.DefaultDrawingAttributes.Height = 10;
        }

        public void AddButtonOnGreed()
        {
            btnPen.Content = "Pen";
            btnPen.Name = "btnPen";
            btnPen.HorizontalAlignment = HorizontalAlignment.Left;
            btnPen.VerticalAlignment = VerticalAlignment.Top;
            btnPen.Width = 100;
            btnPen.Height = 50;
            btnPen.Foreground = new SolidColorBrush(Colors.White);
            btnPen.Background = new SolidColorBrush(Colors.DarkGray);
            btnPen.FontWeight = FontWeights.Bold;
            btnPen.FontSize = 14;
            btnPen.Margin = new Thickness(90, 40, 0, 0);
            btnPen.Click += new RoutedEventHandler(btnClick);
            MyGrid.Children.Add(btnPen);

            btnEraser.Content = "Eraser";
            btnEraser.Name = "btnEraser";
            btnEraser.HorizontalAlignment = HorizontalAlignment.Left;
            btnEraser.VerticalAlignment = VerticalAlignment.Top;
            btnEraser.Width = 100;
            btnEraser.Height = 50;
            btnEraser.Foreground = new SolidColorBrush(Colors.White);
            btnEraser.Background = new SolidColorBrush(Colors.DarkGray);
            btnEraser.FontWeight = FontWeights.Bold;
            btnEraser.FontSize = 14;
            btnEraser.Margin = new Thickness(200, 40, 0, 0);
            btnEraser.Click += new RoutedEventHandler(btnClick);
            MyGrid.Children.Add(btnEraser);

            clearAll.Content = "Clear All";
            clearAll.Name = "clearAll";
            clearAll.HorizontalAlignment = HorizontalAlignment.Left;
            clearAll.VerticalAlignment = VerticalAlignment.Top;
            clearAll.Width = 100;
            clearAll.Height = 50;
            clearAll.Foreground = new SolidColorBrush(Colors.White);
            clearAll.Background = new SolidColorBrush(Colors.DarkGray);
            clearAll.FontWeight = FontWeights.Bold;
            clearAll.FontSize = 14;
            clearAll.Margin = new Thickness(310, 40, 0, 0);
            clearAll.Click += new RoutedEventHandler(btnClick);
            MyGrid.Children.Add(clearAll);

            btnRed.Background = new SolidColorBrush(Colors.Red);
            btnRed.Name = "btnRed";
            btnRed.HorizontalAlignment = HorizontalAlignment.Left;
            btnRed.VerticalAlignment = VerticalAlignment.Top;
            btnRed.Width = 20;
            btnRed.Height = 20;
            btnRed.Margin = new Thickness(100, 100, 0, 0);
            btnRed.Click += new RoutedEventHandler(btnClick);
            MyGrid.Children.Add(btnRed);

            btnGreen.Background = new SolidColorBrush(Colors.Green);
            btnGreen.Name = "btnGreen";
            btnGreen.HorizontalAlignment = HorizontalAlignment.Left;
            btnGreen.VerticalAlignment = VerticalAlignment.Top;
            btnGreen.Width = 20;
            btnGreen.Height = 20;
            btnGreen.Margin = new Thickness(130, 100, 0, 0);
            btnGreen.Click += new RoutedEventHandler(btnClick);
            MyGrid.Children.Add(btnGreen);

            btnBlue.Background = new SolidColorBrush(Colors.Blue);
            btnBlue.Name = "btnBlue";
            btnBlue.HorizontalAlignment = HorizontalAlignment.Left;
            btnBlue.VerticalAlignment = VerticalAlignment.Top;
            btnBlue.Width = 20;
            btnBlue.Height = 20;
            btnBlue.Margin = new Thickness(160, 100, 0, 0);
            btnBlue.Click += new RoutedEventHandler(btnClick);
            MyGrid.Children.Add(btnBlue);

            big.Content = "Big";
            big.Name = "big";
            big.FontWeight = FontWeights.Bold;
            big.HorizontalAlignment = HorizontalAlignment.Left;
            big.VerticalAlignment = VerticalAlignment.Top;
            big.Margin = new Thickness(10, 40, 0, 0);
            big.Click += new RoutedEventHandler(radioBtnClick);
            MyGrid.Children.Add(big);

            medium.Content = "Medium";
            medium.Name = "medium";
            medium.FontWeight = FontWeights.Bold;
            medium.HorizontalAlignment = HorizontalAlignment.Left;
            medium.VerticalAlignment = VerticalAlignment.Top;
            medium.Margin = new Thickness(10, 60, 0, 0);
            medium.Click += new RoutedEventHandler(radioBtnClick);
            MyGrid.Children.Add(medium);

            small.Content = "Small";
            small.Name = "small";
            small.FontWeight = FontWeights.Bold;
            small.HorizontalAlignment = HorizontalAlignment.Left;
            small.VerticalAlignment = VerticalAlignment.Top;
            small.Margin = new Thickness(10, 80, 0, 0);
            small.Click += new RoutedEventHandler(radioBtnClick);
            small.IsChecked = true;
            MyGrid.Children.Add(small);

            btnSave.Content = "Save";
            btnSave.Name = "btnSave";
            btnSave.HorizontalAlignment = HorizontalAlignment.Left;
            btnSave.VerticalAlignment = VerticalAlignment.Top;
            btnSave.Width = 100;
            btnSave.Height = 50;
            btnSave.Foreground = new SolidColorBrush(Colors.White);
            btnSave.Background = new SolidColorBrush(Colors.DarkGray);
            btnSave.FontWeight = FontWeights.Bold;
            btnSave.FontSize = 14;
            btnSave.Margin = new Thickness(460, 40, 0, 0);
            btnSave.Click += new RoutedEventHandler(btnClick);
            MyGrid.Children.Add(btnSave);

            btnLoad.Content = "Load";
            btnLoad.Name = "btnLoad";
            btnLoad.HorizontalAlignment = HorizontalAlignment.Left;
            btnLoad.VerticalAlignment = VerticalAlignment.Top;
            btnLoad.Width = 100;
            btnLoad.Height = 50;
            btnLoad.Foreground = new SolidColorBrush(Colors.White);
            btnLoad.Background = new SolidColorBrush(Colors.DarkGray);
            btnLoad.FontWeight = FontWeights.Bold;
            btnLoad.FontSize = 14;
            btnLoad.Margin = new Thickness(570, 40, 0, 0);
            btnLoad.Click += new RoutedEventHandler(btnClick);
            MyGrid.Children.Add(btnLoad);
        }

        public void btnClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btnPen":
                    {
                        MyCanvas.EditingMode = InkCanvasEditingMode.Ink;
                        MyCanvas.Cursor = System.Windows.Input.Cursors.Pen;
                    }
                    break;

                case "btnEraser":
                    {
                        MyCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                        MyCanvas.Cursor = System.Windows.Input.Cursors.Cross;
                    }
                    break;

                case "clearAll":
                    {
                        this.MyCanvas.Strokes.Clear();
                    }
                    break;

                case "btnRed":
                    {
                        MyCanvas.DefaultDrawingAttributes.Color = Colors.Red;
                    }
                    break;

                case "btnGreen":
                    {
                        MyCanvas.DefaultDrawingAttributes.Color = Colors.Green;
                    }
                    break;

                case "btnBlue":
                    {
                        MyCanvas.DefaultDrawingAttributes.Color = Colors.Blue;
                    }
                    break;
                case "btnSave":
                    {
                        SaveFileDialog saveFileDialog12 = new SaveFileDialog();
                        saveFileDialog12.Filter = "InkCanvas Format|*.sandy";
                        saveFileDialog12.Title = "Save InkCanvas File";
                        saveFileDialog12.ShowDialog();
                        if (saveFileDialog12.FileName == "") return;
                        FileStream fs = File.Open(saveFileDialog12.FileName, FileMode.OpenOrCreate);
                        MyCanvas.Strokes.Save(fs);
                        fs.Close();
                    }
                    break;
                case "btnLoad":
                    {
                        OpenFileDialog openFileDialog1 = new OpenFileDialog();
                        openFileDialog1.Title = "Load InkCanvas File";
                        openFileDialog1.DefaultExt = "sandy";
                        openFileDialog1.Filter = "Inkcanvas Format(.sandy)|*.sandy";
                        openFileDialog1.ShowDialog();
                        if (openFileDialog1.FileName == "") return;
                        FileStream fs = File.Open(openFileDialog1.FileName, FileMode.Open);
                        StrokeCollection myStrk = new StrokeCollection(fs);
                        MyCanvas.Strokes = myStrk;
                        fs.Close();

                    }
                    break;
            }
        }

        public void radioBtnClick(object sender, RoutedEventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            switch (btn.Name)
            {
                case "big":
                    {
                        MyCanvas.DefaultDrawingAttributes.Width = 50;
                        MyCanvas.DefaultDrawingAttributes.Height = 50;
                    }
                    break;

                case "medium":
                    {
                        MyCanvas.DefaultDrawingAttributes.Width = 25;
                        MyCanvas.DefaultDrawingAttributes.Height = 25;
                    }
                    break;

                case "small":
                    {
                        MyCanvas.DefaultDrawingAttributes.Width = 10;
                        MyCanvas.DefaultDrawingAttributes.Height = 10;
                    }
                    break;
            }
        }
    }


}
