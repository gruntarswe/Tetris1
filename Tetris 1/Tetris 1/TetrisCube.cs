using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Tetris_1
{
    class TetrisCube

    {
        int TetSize = 35;
        int colorNumber;
        public bool locked{get; set;}
        Color TetColor;
        Rectangle TetCube;
        ImageBrush testBrush;
        SolidColorBrush fillColor;

        
        public TetrisCube(int TeColor, bool locking)
        {
            TetCube = new Rectangle();
            TetCube.Stroke = new SolidColorBrush(Colors.Black);
            //testBrush = new ImageBrush();
            //testBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/test2.png"));
            
            
            this.colorNumber = TeColor;
            TetCube.Width = TetSize;
            TetCube.Height = TetSize;
            locked = locking;
            switch (TeColor)
            {
                case 0:
                    TetColor = Colors.Cyan;
                    break;
                case 1:
                    TetColor = Colors.Blue;
                    break;
                case 2:
                    TetColor = Colors.Orange;
                    break;
                case 3:
                    TetColor = Colors.Yellow;
                    break;
                case 4:
                    TetColor = Colors.Lime;
                    break;
                case 5:
                    TetColor = Colors.Purple;
                    break;
                case 6:
                    TetColor = Colors.Red;
                    break;
                case 7:
                    TetColor = Colors.Black;
                    break;
            }
            fillColor = new SolidColorBrush(TetColor);
            TetCube.Fill = fillColor;



        }

        
        public void DrawCube(int xCoord, int yCoord,  Canvas drawingCanvas)
        {
            int XCoord = xCoord * TetSize;
            int YCoord = yCoord * TetSize;           
            Canvas.SetLeft(TetCube, XCoord);
            Canvas.SetTop(TetCube, YCoord);
            drawingCanvas.Children.Add(TetCube);
        }
        public TetrisCube CopyCube()
        {
            return new TetrisCube(this.colorNumber, this.locked);
        }
       
    }
}
