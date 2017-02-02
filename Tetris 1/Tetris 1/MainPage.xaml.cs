using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.ApplicationModel.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tetris_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Timer gravityTimer2;
        private Timer redrawTimer;
        private TetrisGridArray testing1;
        private TetrisShapes shapeCreate;
        int score = 0;
        int level = 1;
        int rows = 0;
        int offset = 0;
        private bool waitingGameOver = false;
        TetrisBag bagging;
        public MainPage()
        {
            
            this.InitializeComponent();
            testing1 = new TetrisGridArray();
            bagging = new TetrisBag();

            shapeCreate = new TetrisShapes(bagging.GetCurrent(), testing1, false);
            testing1.DrawArray(Gamedraw);
            var autoEvent = new AutoResetEvent(false);
            gravityTimer2 = new Timer(gravityCallBack, autoEvent, 1000, 500);
            redrawTimer = new Timer(redrawGrid, autoEvent, 150, 100);

            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            


        }

        private async void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            
            if (args.VirtualKey == VirtualKey.Down)
            {
                
                AutoResetEvent randomObject = new AutoResetEvent(false);
                gravityCallBack(randomObject);
            }
            else if (args.VirtualKey == VirtualKey.Up)
            {
                gravityDrop();
            }
            else if (args.VirtualKey == VirtualKey.Left)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    testing1.MoveLeft(shapeCreate);
                });

            }
            else if (args.VirtualKey == VirtualKey.Right)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    testing1.MoveRight(shapeCreate);
                });
            }
            else if (args.VirtualKey == VirtualKey.A)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    shapeCreate.RotateLeft(testing1);
                });
                
            }
            else if (args.VirtualKey == VirtualKey.S)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    shapeCreate.RotateRight(testing1);
                });
                
            }
            args.Handled = true;
            args = null;
        }

       
        private async void gravityCallBack(object call)
        {
            var e = (AutoResetEvent)call;
            e.Dispose();
            e = null;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,  () =>
            {
                if (!waitingGameOver)
                {
                    if (testing1.TetrisGravity(shapeCreate))
                    {


                        gravityTimer2.Change(1500, 525 - 25 * level);
                        testing1.checkRows(ref score, ref rows, level);
                        LevelUp();
                        scoreText.Text = score.ToString();
                        levelText.Text = level.ToString();
                        NewShape();

                        GC.Collect();

                    }
                }

            });

        }
        private async void gravityDrop()
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (!waitingGameOver)
                {
                    for (int i = 0; i < 22; i++)
                    {
                        if (testing1.TetrisGravity(shapeCreate))
                        {

                            gravityTimer2.Change(1500, 525 - 25 * level);
                            testing1.checkRows(ref score, ref rows, level);
                            LevelUp();
                            scoreText.Text = score.ToString();
                            levelText.Text = level.ToString();
                            NewShape();
                            return;
                        }
                    }
                }
                

            });

        }

        private async void redrawGrid(object call)
        {
            var e = (AutoResetEvent)call;
            e.Dispose();
            e = null;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (!waitingGameOver)
                {
                    testing1.DrawArray(Gamedraw);
                }
            });
        }
        private void LevelUp()
        {
            if (rows >= 5-offset)
            {
                if (level == 21)
                {
                    return;
                }
                if (rows > 5 - offset)
                {
                    offset = rows - 5 + offset;
                }
                else offset = 0;
                level++;
                rows = 0;
                
            }
        }

        private async void NewShape()
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                shapeCreate = null;
                try
                {
                    shapeCreate = new TetrisShapes(bagging.GetNext(), testing1, false);
                    
                }
                catch(Exception ex) 
                {
                    waitingGameOver = true;
                    GameOver(ex.Message);
                }

            });
            
        }

        private async void GameOver(string message)
        {
            var gameOverDialog = new MessageDialog(message + "\nYou got score : "+score);
            gameOverDialog.Commands.Add(new UICommand { Label = "New Game?", Id = 0 });
            gameOverDialog.Commands.Add(new UICommand { Label = "Exit", Id = 1 });
            var f = await gameOverDialog.ShowAsync();
            if ((int)f.Id == 0) 
            {
                testing1 = null;
                bagging = null;
                testing1 = new TetrisGridArray();
                bagging = new TetrisBag();
                shapeCreate = new TetrisShapes(bagging.GetCurrent(), testing1, false);
                waitingGameOver = false;
                score = 0;
                rows = 0;
                level = 1;
            }
            else if((int)f.Id == 1)
            {
                redrawTimer.Dispose();
                gravityTimer2.Dispose();
                CoreApplication.Exit();
            }
        }
    }
}
