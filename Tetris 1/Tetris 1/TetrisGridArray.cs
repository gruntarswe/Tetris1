using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using System.Threading;

namespace Tetris_1
{
    class TetrisGridArray
    {
        private int ArrayWidth = 12;
        private int ArrayHeight = 24;
        private TetrisCube[,] cubeArray;
       
        
        
        public TetrisGridArray()
        {
            


            cubeArray = new TetrisCube[ ArrayHeight, ArrayWidth];
            //Init the array
            for (int i = 0; i < ArrayHeight; i++)
            {
                for (int j = 0; j < ArrayWidth; j++)
                {
                    cubeArray[i, j] = null;
                }
            }
            
            //Establish the border

            for (int i = 0; i < ArrayHeight; i++)
            {
                if (i == 0 || i == ArrayHeight - 1)
                {
                    for (int j = 0; j < ArrayWidth; j++)
                    {
                        cubeArray[i, j] = new TetrisCube(7, true);
                    }
                }
                else
                {
                    cubeArray[i, 0] = new TetrisCube(7, true);
                    cubeArray[i, ArrayWidth-1] = new TetrisCube(7, true);
                }
            }
        }


        public void MoveCube(int startX, int endX, int startY, int endY)
        {
            if (cubeArray[startY+1, startX+1] != null)
            {
                if (cubeArray[endY+1, endX+1]== null)
                {
                    cubeArray[endY+1, endX+1] = cubeArray[startY+1, startX+1].CopyCube();
                    cubeArray[startY+1, startX+1] = null;
                }
            }
        }

        public bool AddCube(int xCoord, int yCoord, int TeColor, bool locked)
        {
            if (cubeArray[yCoord + 1, xCoord + 1] == null)
            {
                cubeArray[yCoord + 1, xCoord + 1] = new TetrisCube(TeColor, locked);
                return true;
            }
            return false;
        }
        public bool AddShapeCubes(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int color, bool locked)
        {
            if (!AddCube(x1, y1, color, locked)|| !AddCube(x2, y2, color, locked) || !AddCube(x3, y3, color, locked) || !AddCube(x4, y4, color, locked)) return false;
            //if (!AddCube(x2, y2, color, locked)) return false;
            //if (!AddCube(x3, y3, color, locked)) return false;
            //if (!AddCube(x4, y4, color, locked)) return false;
            return true;
        }

        internal void MoveLeft(TetrisShapes trackingShape)
        {
            for (int i = 1; i < ArrayWidth-1; i++)
            {
                for (int j = ArrayHeight - 2; j > 0; j--)
                {
                    if (cubeArray[j, i] != null && cubeArray[j, i].locked == false)
                    {
                        if (cubeArray[j, i-1] != null)
                        {
                            return;
                        }
                    }

                }
                for (int j = ArrayHeight - 2; j > 0; j--)
                {
                    if (cubeArray[j, i] != null && cubeArray[j, i].locked == false)
                    {
                        MoveCube(i-1, i-2, j-1, j-1);
                    }
                }
            }
            trackingShape.coreShapeX -= 1;
        }

        public void DrawArray(Canvas drawingCanvas )
        {
            drawingCanvas.Children.Clear();
            
            for (int i = 0; i < ArrayHeight; i++)
            {
                for (int j = 0; j < ArrayWidth; j++)
                {
                    if (cubeArray[i, j] != null)
                    {
                        cubeArray[i, j].DrawCube(j, i, drawingCanvas);
                    }
                }
            }
        }

        internal void checkRows(ref int score, ref int rows, int level)
        {
            for (int i = 3; i < ArrayHeight-1; i++)
            {
                if (checkThisRow(i))
                {
                    for (int j = 1; j < ArrayWidth-1; j++)
                    {
                        cubeArray[i, j] = null;
                        
                    }
                    MoveEverythingDown(i);
                  

                    score += 80 + level * 20;
                    rows += 1;
                }
            }
        }

        private void MoveEverythingDown(int i)
        {

            for (int k = i; k > 1; k--)
            {
                for (int j = 1; j < ArrayWidth-1; j++)
                {
                    if (cubeArray[k - 1, j] != null)
                    {
                        MoveCube(j - 1, j - 1, k - 2, k - 1);
                    }
                }
                

            }

        }

        private bool checkThisRow(int row)
        {
            for (int i = 1; i < ArrayWidth-1; i++)
            {
                if (cubeArray[row,i] == null)
                {
                    return false;
                }
            }
            return true;
        }

        internal void MoveRight(TetrisShapes trackingShape)
        {
            for (int i = ArrayWidth - 2; i > 0; i--)
            {
                for (int j = ArrayHeight - 2; j > 0; j--)
                {
                    if (cubeArray[ j, i] != null && cubeArray[j, i].locked == false)
                    {
                        if (cubeArray[j, i+1] != null)
                        {
                            return;
                        }
                    }

                }
                for (int j = ArrayHeight - 2; j > 0; j--)
                {
                    if (cubeArray[j, i] != null && cubeArray[j, i].locked == false)
                    {
                        MoveCube(i - 1, i, j - 1, j - 1);
                    }
                }
            }
            trackingShape.coreShapeX += 1;
        }

        public bool TetrisGravity(TetrisShapes lockedShape)
        {
            if (!lockedShape.lockedShape)
            {


                for (int i = ArrayHeight - 2; i > 0; i--)
                {
                    for (int j = 1; j < ArrayWidth - 1; j++)
                    {
                        if (cubeArray[i, j] != null && cubeArray[i, j].locked == false)
                        {

                            if (cubeArray[i + 1, j] != null)
                            {
                                lockedShape.lockedShape = true;
                            }
                            else if (cubeArray[i, j + 1] != null && cubeArray[i - 1, j + 1] != null && !cubeArray[i - 1, j + 1].locked && cubeArray[i, j + 1].locked  )
                            {
                                lockedShape.lockedShape = true;
                            }
                            else if(cubeArray[i, j - 1] != null && cubeArray[i - 1, j - 1] != null && !cubeArray[i - 1, j - 1].locked && cubeArray[i, j - 1].locked )
                            {
                                lockedShape.lockedShape = true;
                            }
                            else if(i > 1&& cubeArray[i - 1, j + 1] != null && cubeArray[i - 2, j + 1] != null && !cubeArray[i - 2, j + 1].locked && cubeArray[i - 1, j + 1].locked )
                            {
                                lockedShape.lockedShape = true;
                                
                            }
                            else if (i > 1 && cubeArray[i - 1, j - 1] != null && cubeArray[i - 2, j - 1] != null && !cubeArray[i - 2, j - 1].locked && cubeArray[i - 1, j - 1].locked)
                            {
                                lockedShape.lockedShape = true;

                            }
                            else if(j < ArrayWidth - 2&& cubeArray[i, j + 2] != null && cubeArray[i - 1, j + 2] != null && !cubeArray[i - 1, j + 2].locked && cubeArray[i, j + 2].locked )
                            {
                                lockedShape.lockedShape = true;
                                
                            }
                            else if (j > 1 && cubeArray[i, j - 2] != null && cubeArray[i - 1, j - 2] != null && !cubeArray[i - 1, j - 2].locked && cubeArray[i, j - 2].locked)
                            {
                                lockedShape.lockedShape = true;

                            }
                        }
                        if (lockedShape.lockedShape)
                        {
                            for (int f = ArrayHeight - 2; f > 0; f--)
                            {
                                for (int k = 1; k < ArrayWidth - 1; k++)
                                {
                                    if (cubeArray[f, k] != null)
                                    {
                                        cubeArray[f, k].locked = true;
                                    }
                                }
                            }
                            return true;
                        }
                    }

                    for (int j = 1; j < ArrayWidth - 1; j++)
                    {
                        if (cubeArray[i, j] != null && cubeArray[i, j].locked == false)
                        {
                            MoveCube(j - 1, j - 1, i - 1, i);
                        }
                    }
                }
            }
            lockedShape.coreShapeY +=1;
            return false;
        }

        internal bool checkSquare(int x, int y)
        {
            if (x > -2 && y > -2)
            {
                if (cubeArray[y + 1, x + 1] == null)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        internal bool check3RotationSquares(int x1,int y1,int x2,int y2,int x3,int y3)
        {
            if (checkSquare(x1, y1)|| checkSquare(x2, y2) || checkSquare(x3, y3)) return false;
            //if (checkSquare(x2, y2)) return false;
            //if (checkSquare(x3, y3)) return false;
            return true;
        }

        internal bool check2RotationSquares(int x1, int y1, int x2, int y2)
        {
            if (checkSquare(x1, y1)|| checkSquare(x2, y2)) return false;
           // if (checkSquare(x2, y2)) return false;
            return true;
        }

        internal void moveThreeSquares(int startX1, int endX1, int startY1, int endY1, int startX2, int endX2, int startY2, int endY2, int startX3, int endX3, int startY3, int endY3)
        {
            MoveCube(startX1, endX1, startY1, endY1);
            MoveCube(startX2, endX2, startY2, endY2);
            MoveCube(startX3, endX3, startY3, endY3);
        }

        internal void moveTwoSquares(int startX1, int endX1, int startY1, int endY1, int startX2, int endX2, int startY2, int endY2)
        {
            MoveCube(startX1, endX1, startY1, endY1);
            MoveCube(startX2, endX2, startY2, endY2);
        }
        
    }
}
