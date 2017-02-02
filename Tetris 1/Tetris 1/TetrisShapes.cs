using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_1
{
    class TetrisShapes
    {
        public int coreShapeX{get; set;}
        public int coreShapeY { get; set; }
        private int shapeNumber;
        private int shapeDirection;
        public bool lockedShape { get; set; }
        public TetrisShapes(int shapeType, TetrisGridArray grid, bool locked)
        {
            shapeNumber = shapeType;
            shapeDirection = 1;
            lockedShape = locked;
            //Add the cubes to the array, logic to follow
            switch (shapeType)
            {
                
                //I
                case 0:
                    if(!grid.AddShapeCubes(3, 1, 4, 1, 5, 1, 6, 1, 0, false)) throw new Exception("Game Over");
                    //grid.AddCube(3, 1, 0, false);
                    //grid.AddCube(4, 1, 0, false);
                    //grid.AddCube(5, 1, 0, false);
                    //grid.AddCube(6, 1, 0, false);
                    //coreShapeX = 4;
                    //coreShapeY = 1;
                    break;
                //J
                case 1:
                    if (!grid.AddShapeCubes(3, 0, 3, 1, 4, 1, 5, 1, 1, false)) throw new Exception("Game Over");
                    //grid.AddCube(3, 0, 1, false);
                    //grid.AddCube(3, 1, 1, false);
                    //grid.AddCube(4, 1, 1, false);
                    //grid.AddCube(5, 1, 1, false);
                    //coreShapeY = 1;
                    //coreShapeX = 4;
                    break;
                //L
                case 2:
                    if (!grid.AddShapeCubes(5, 0, 5, 1, 3, 1, 4, 1, 2, false)) throw new Exception("Game Over!");
                    //grid.AddCube(5, 0, 2, false);
                    //grid.AddCube(5, 1, 2, false);
                    //grid.AddCube(3, 1, 2, false);
                    //grid.AddCube(4, 1, 2, false);
                    //coreShapeY = 1;
                    //coreShapeX = 4;
                    break;
                //O
                case 3:
                    if (!grid.AddShapeCubes(5, 0, 5, 1, 4, 1, 4, 0, 3, false)) throw new Exception("Game Over!");
                    //grid.AddCube(5, 0, 3, false);
                    //grid.AddCube(5, 1, 3, false);
                    //grid.AddCube(4, 0, 3, false);
                    //grid.AddCube(4, 1, 3, false);
                    //coreShapeX = 4;
                    //coreShapeY = 0;
                    break;
                //S
                case 4:
                    if (!grid.AddShapeCubes(4, 0, 4, 1, 3, 1, 5, 0, 4, false)) throw new Exception("Game Over!");
                    //grid.AddCube(4, 0, 4, false);
                    //grid.AddCube(5, 0, 4, false);
                    //grid.AddCube(3, 1, 4, false);
                    //grid.AddCube(4, 1, 4, false);
                    //coreShapeY = 1;
                    //coreShapeX = 4;
                    break;
                //T
                case 5:
                    if (!grid.AddShapeCubes(3, 1, 4, 0, 4, 1, 5, 1, 5, false)) throw new Exception("Game Over!");
                    //grid.AddCube(4, 0, 5, false);
                    //grid.AddCube(3, 1, 5, false);
                    //grid.AddCube(4, 1, 5, false);
                    //grid.AddCube(5, 1, 5, false);
                    //coreShapeY = 1;
                    //coreShapeX = 4;
                    break;
                //Z
                case 6:
                    if (!grid.AddShapeCubes(3, 0, 4, 0, 4, 1, 5, 1, 6, false)) throw new Exception("Game Over!");
                    //grid.AddCube(3, 0, 6, false);
                    //grid.AddCube(4, 0, 6, false);
                    //grid.AddCube(4, 1, 6, false);
                    //grid.AddCube(5, 1, 6, false);
                    //coreShapeY = 1;
                    //coreShapeX = 4;
                    break;
            


            }
            coreShapeX = 4;
            coreShapeY = 1;

        }

        internal void RotateRight(TetrisGridArray grid)
        {
            if (!lockedShape)
            {
                switch (shapeNumber)
                {
                    case 0:
                        switch (shapeDirection)
                        {
                            case 1:
                                if (!grid.check3RotationSquares(coreShapeX+1, coreShapeY-1, coreShapeX+1, coreShapeY+1, coreShapeX+1, coreShapeY+2)) return;
                                grid.moveThreeSquares(coreShapeX - 1, coreShapeX + 1, coreShapeY, coreShapeY - 1, coreShapeX, coreShapeX + 1, coreShapeY, coreShapeY + 1, coreShapeX + 2, coreShapeX + 1, coreShapeY, coreShapeY + 2);
                                shapeDirection = 2;
                                break;
                            case 2:
                                if (!grid.check3RotationSquares(coreShapeX - 1, coreShapeY + 1, coreShapeX, coreShapeY + 1, coreShapeX + 2, coreShapeY + 1)) return;
                                grid.moveThreeSquares(coreShapeX + 1, coreShapeX - 1, coreShapeY - 1, coreShapeY + 1, coreShapeX + 1, coreShapeX, coreShapeY, coreShapeY + 1, coreShapeX + 1, coreShapeX + 2, coreShapeY + 2, coreShapeY + 1);
                                shapeDirection = 3;
                                break;
                            case 3:
                                if (!grid.check3RotationSquares(coreShapeX, coreShapeY - 1, coreShapeX, coreShapeY, coreShapeX, coreShapeY + 2)) return;
                                grid.moveThreeSquares(coreShapeX - 1, coreShapeX, coreShapeY + 1, coreShapeY - 1, coreShapeX + 1, coreShapeX, coreShapeY + 1, coreShapeY, coreShapeX + 2, coreShapeX, coreShapeY + 1, coreShapeY + 2);
                                shapeDirection = 4;
                                break;
                            case 4:
                                if (!grid.check3RotationSquares(coreShapeX - 1, coreShapeY, coreShapeX + 1, coreShapeY, coreShapeX + 2, coreShapeY)) return;
                                grid.moveThreeSquares(coreShapeX, coreShapeX - 1, coreShapeY - 1, coreShapeY, coreShapeX, coreShapeX + 1, coreShapeY + 1, coreShapeY, coreShapeX, coreShapeX + 2, coreShapeY + 2, coreShapeY);
                                shapeDirection = 1;
                                break;
                        }
                        break;

                    case 1:
                        switch (shapeDirection)
                        {
                            case 1:
                                if (!grid.check3RotationSquares(coreShapeX + 1, coreShapeY - 1, coreShapeX, coreShapeY - 1, coreShapeX, coreShapeY + 1)) return;
                                grid.moveThreeSquares(coreShapeX - 1, coreShapeX + 1, coreShapeY - 1, coreShapeY - 1, coreShapeX - 1, coreShapeX, coreShapeY, coreShapeY - 1, coreShapeX + 1, coreShapeX, coreShapeY, coreShapeY + 1);
                                shapeDirection = 2;
                                break;
                            case 2:
                                if (!grid.check3RotationSquares(coreShapeX + 1, coreShapeY + 1, coreShapeX + 1, coreShapeY, coreShapeX - 1, coreShapeY)) return;
                                grid.moveThreeSquares(coreShapeX + 1, coreShapeX + 1, coreShapeY - 1, coreShapeY + 1, coreShapeX, coreShapeX + 1, coreShapeY - 1, coreShapeY, coreShapeX, coreShapeX - 1, coreShapeY + 1, coreShapeY);
                                shapeDirection = 3;
                                break;
                            case 3:
                                if (!grid.check3RotationSquares(coreShapeX - 1, coreShapeY + 1, coreShapeX, coreShapeY + 1, coreShapeX, coreShapeY - 1)) return;
                                grid.moveThreeSquares(coreShapeX + 1, coreShapeX - 1, coreShapeY + 1, coreShapeY + 1, coreShapeX + 1, coreShapeX, coreShapeY, coreShapeY + 1, coreShapeX - 1, coreShapeX, coreShapeY, coreShapeY - 1);
                                shapeDirection = 4;
                                break;
                            case 4:
                                if (!grid.check3RotationSquares(coreShapeX - 1, coreShapeY - 1, coreShapeX - 1, coreShapeY, coreShapeX + 1, coreShapeY)) return;
                                grid.moveThreeSquares(coreShapeX - 1, coreShapeX - 1, coreShapeY + 1, coreShapeY - 1, coreShapeX, coreShapeX - 1, coreShapeY + 1, coreShapeY, coreShapeX, coreShapeX + 1, coreShapeY - 1, coreShapeY);
                                shapeDirection = 1;
                                break;
                        }
                        break;

                    case 2:
                        switch (shapeDirection)
                        {
                            case 1:
                                if (!grid.check3RotationSquares(coreShapeX, coreShapeY - 1, coreShapeX + 1, coreShapeY + 1, coreShapeX, coreShapeY + 1)) return;
                                grid.moveThreeSquares(coreShapeX - 1, coreShapeX, coreShapeY, coreShapeY - 1, coreShapeX + 1, coreShapeX + 1, coreShapeY - 1, coreShapeY + 1, coreShapeX + 1, coreShapeX, coreShapeY, coreShapeY + 1);
                                shapeDirection = 2;
                                break;
                            case 2:
                                if (!grid.check3RotationSquares(coreShapeX + 1, coreShapeY, coreShapeX - 1, coreShapeY + 1, coreShapeX - 1, coreShapeY)) return;
                                grid.moveThreeSquares(coreShapeX, coreShapeX + 1, coreShapeY - 1, coreShapeY, coreShapeX + 1, coreShapeX - 1, coreShapeY + 1, coreShapeY + 1, coreShapeX, coreShapeX - 1, coreShapeY + 1, coreShapeY);
                                shapeDirection = 3;
                                break;
                            case 3:
                                if (!grid.check3RotationSquares(coreShapeX, coreShapeY + 1, coreShapeX - 1, coreShapeY - 1, coreShapeX, coreShapeY - 1)) return;
                                grid.moveThreeSquares(coreShapeX + 1, coreShapeX, coreShapeY, coreShapeY + 1, coreShapeX - 1, coreShapeX - 1, coreShapeY + 1, coreShapeY - 1, coreShapeX - 1, coreShapeX, coreShapeY, coreShapeY - 1);
                                shapeDirection = 4;
                                break;
                            case 4:
                                if (!grid.check3RotationSquares(coreShapeX - 1, coreShapeY, coreShapeX + 1, coreShapeY - 1, coreShapeX + 1, coreShapeY)) return;
                                grid.moveThreeSquares(coreShapeX, coreShapeX - 1, coreShapeY + 1, coreShapeY, coreShapeX - 1, coreShapeX + 1, coreShapeY - 1, coreShapeY - 1, coreShapeX, coreShapeX + 1, coreShapeY - 1, coreShapeY);
                                shapeDirection = 1;
                                break;
                        }
                        break;

                    case 3:
                        //switch (shapeDirection)
                        //{
                        //    case 1:
                        //        break;
                        //    case 2:
                        //        break;
                        //    case 3:
                        //        break;
                        //    case 4:
                        //        break;
                        //}
                        break;

                    case 4:
                        switch (shapeDirection)
                        {
                            case 1:
                                if (!grid.check2RotationSquares(coreShapeX + 1, coreShapeY, coreShapeX + 1, coreShapeY + 1)) return;
                                grid.moveTwoSquares(coreShapeX - 1, coreShapeX + 1, coreShapeY, coreShapeY, coreShapeX + 1, coreShapeX + 1, coreShapeY - 1, coreShapeY + 1);
                                shapeDirection = 2;
                                break;
                            case 2:
                                if (!grid.check2RotationSquares(coreShapeX, coreShapeY + 1, coreShapeX - 1, coreShapeY + 1)) return;
                                grid.moveTwoSquares(coreShapeX, coreShapeX, coreShapeY - 1, coreShapeY + 1, coreShapeX + 1, coreShapeX - 1, coreShapeY + 1, coreShapeY + 1);
                                shapeDirection = 3;
                                break;
                            case 3:
                                if (!grid.check2RotationSquares(coreShapeX - 1, coreShapeY, coreShapeX - 1, coreShapeY - 1)) return;
                                grid.moveTwoSquares(coreShapeX + 1, coreShapeX - 1, coreShapeY, coreShapeY, coreShapeX - 1, coreShapeX - 1, coreShapeY + 1, coreShapeY - 1);
                                shapeDirection = 4;
                                break;
                            case 4:
                                if (!grid.check2RotationSquares(coreShapeX, coreShapeY - 1, coreShapeX + 1, coreShapeY - 1)) return;
                                grid.moveTwoSquares(coreShapeX, coreShapeX, coreShapeY + 1, coreShapeY - 1, coreShapeX - 1, coreShapeX + 1, coreShapeY - 1, coreShapeY - 1);
                                shapeDirection = 1;
                                break;
                        }
                        break;

                    case 5:
                        switch (shapeDirection)
                        {
                            case 1:
                                if (grid.checkSquare(coreShapeX, coreShapeY + 1)) return;
                                grid.MoveCube(coreShapeX - 1, coreShapeX , coreShapeY, coreShapeY+1);
                                shapeDirection = 2;
                                break;
                            case 2:
                                if (grid.checkSquare(coreShapeX - 1, coreShapeY)) return;
                                grid.MoveCube(coreShapeX, coreShapeX - 1, coreShapeY - 1, coreShapeY);
                                shapeDirection = 3;
                                break;
                            case 3:
                                if (grid.checkSquare(coreShapeX, coreShapeY - 1)) return;
                                grid.MoveCube(coreShapeX + 1, coreShapeX, coreShapeY, coreShapeY - 1);
                                shapeDirection = 4;
                                break;
                            case 4:
                                if (grid.checkSquare(coreShapeX + 1, coreShapeY)) return;
                                grid.MoveCube(coreShapeX, coreShapeX + 1, coreShapeY + 1, coreShapeY);
                                shapeDirection = 1;
                                break;
                        }
                        break;

                    case 6:
                        switch (shapeDirection)
                        {
                            case 1:
                                if (!grid.check2RotationSquares(coreShapeX + 1, coreShapeY - 1, coreShapeX, coreShapeY + 1)) return;
                                grid.moveTwoSquares(coreShapeX - 1, coreShapeX + 1, coreShapeY - 1, coreShapeY - 1, coreShapeX, coreShapeX, coreShapeY - 1, coreShapeY + 1);
                                shapeDirection = 2;
                                break;
                            case 2:
                                if (!grid.check2RotationSquares(coreShapeX - 1, coreShapeY, coreShapeX + 1, coreShapeY + 1)) return;
                                grid.moveTwoSquares(coreShapeX + 1, coreShapeX - 1, coreShapeY - 1, coreShapeY, coreShapeX + 1, coreShapeX + 1, coreShapeY, coreShapeY + 1);
                                shapeDirection = 3;
                                break;
                            case 3:
                                if (!grid.check2RotationSquares(coreShapeX, coreShapeY - 1, coreShapeX - 1, coreShapeY + 1)) return;
                                grid.moveTwoSquares(coreShapeX, coreShapeX, coreShapeY + 1, coreShapeY - 1, coreShapeX + 1, coreShapeX - 1, coreShapeY + 1, coreShapeY + 1);
                                shapeDirection = 4;
                                break;
                            case 4:
                                if (!grid.check2RotationSquares(coreShapeX - 1, coreShapeY - 1, coreShapeX + 1, coreShapeY)) return;
                                grid.moveTwoSquares(coreShapeX - 1, coreShapeX - 1, coreShapeY, coreShapeY - 1, coreShapeX - 1, coreShapeX + 1, coreShapeY + 1, coreShapeY);
                                shapeDirection = 1;
                                break;
                        }
                        break;
                }
            }
        }

        internal void RotateLeft(TetrisGridArray grid)
        {
            if (!lockedShape)
            {
                switch (shapeNumber)
                {
                    #region case I
                    case 0:
                        switch (shapeDirection)
                        {
                            case 1:
                                if (!grid.check3RotationSquares(coreShapeX, coreShapeY - 1, coreShapeX, coreShapeY + 1, coreShapeX, coreShapeY + 2)) return;
                                grid.moveThreeSquares(coreShapeX - 1, coreShapeX, coreShapeY, coreShapeY - 1, coreShapeX + 1, coreShapeX, coreShapeY, coreShapeY + 1, coreShapeX + 2, coreShapeX, coreShapeY, coreShapeY + 2);
                                shapeDirection = 4;
                                break;
                            case 2:
                                if (!grid.check3RotationSquares(coreShapeX - 1, coreShapeY, coreShapeX, coreShapeY, coreShapeX + 2, coreShapeY)) return;
                                grid.moveThreeSquares(coreShapeX + 1, coreShapeX - 1, coreShapeY - 1, coreShapeY, coreShapeX + 1, coreShapeX, coreShapeY + 1, coreShapeY, coreShapeX + 1, coreShapeX + 2, coreShapeY + 2, coreShapeY);
                                shapeDirection = 1;
                                break;
                            case 3:                             
                                if (!grid.check3RotationSquares(coreShapeX + 1, coreShapeY - 1, coreShapeX + 1, coreShapeY, coreShapeX + 1, coreShapeY + 2)) return;                             
                                grid.moveThreeSquares(coreShapeX - 1, coreShapeX + 1, coreShapeY + 1, coreShapeY - 1, coreShapeX, coreShapeX + 1, coreShapeY + 1, coreShapeY, coreShapeX + 2, coreShapeX + 1, coreShapeY + 1, coreShapeY + 2);
                                shapeDirection = 2;
                                break;
                            case 4:
                                if (!grid.check3RotationSquares(coreShapeX - 1, coreShapeY + 1, coreShapeX + 1, coreShapeY + 1, coreShapeX + 2, coreShapeY + 1)) return;
                                grid.moveThreeSquares(coreShapeX, coreShapeX - 1, coreShapeY - 1, coreShapeY + 1, coreShapeX, coreShapeX + 1, coreShapeY, coreShapeY + 1, coreShapeX, coreShapeX+2, coreShapeY + 2, coreShapeY + 1);
                                shapeDirection = 3;
                                break;
                        }
                        break;
                    #endregion
                    
                    case 1:
                        switch (shapeDirection)
                        {
                            case 1:
                                if (!grid.check3RotationSquares(coreShapeX - 1, coreShapeY + 1, coreShapeX, coreShapeY + 1, coreShapeX, coreShapeY - 1)) return;
                                grid.moveThreeSquares(coreShapeX - 1, coreShapeX - 1, coreShapeY - 1, coreShapeY + 1, coreShapeX - 1, coreShapeX, coreShapeY, coreShapeY + 1, coreShapeX + 1, coreShapeX, coreShapeY, coreShapeY - 1);
                                shapeDirection = 4;
                                break;
                            case 4:
                                if (!grid.check3RotationSquares(coreShapeX + 1, coreShapeY + 1, coreShapeX + 1, coreShapeY, coreShapeX - 1, coreShapeY)) return;
                                grid.moveThreeSquares(coreShapeX - 1, coreShapeX + 1, coreShapeY + 1, coreShapeY + 1, coreShapeX, coreShapeX + 1, coreShapeY + 1, coreShapeY, coreShapeX, coreShapeX - 1, coreShapeY - 1, coreShapeY);
                                shapeDirection = 3;
                                break;
                            case 3:
                                if (!grid.check3RotationSquares(coreShapeX + 1, coreShapeY - 1, coreShapeX, coreShapeY - 1, coreShapeX, coreShapeY + 1)) return;
                                grid.moveThreeSquares(coreShapeX + 1, coreShapeX + 1, coreShapeY + 1, coreShapeY - 1, coreShapeX + 1, coreShapeX, coreShapeY, coreShapeY - 1, coreShapeX - 1, coreShapeX, coreShapeY, coreShapeY + 1);
                                shapeDirection = 2;
                                break;
                            case 2:
                                if (!grid.check3RotationSquares(coreShapeX - 1, coreShapeY - 1, coreShapeX - 1, coreShapeY, coreShapeX + 1, coreShapeY)) return;
                                grid.moveThreeSquares(coreShapeX + 1, coreShapeX - 1, coreShapeY - 1, coreShapeY - 1, coreShapeX, coreShapeX - 1, coreShapeY - 1, coreShapeY, coreShapeX, coreShapeX + 1, coreShapeY + 1, coreShapeY);
                                shapeDirection = 1;
                                break;
                        }
                        break;

                    case 2:
                        switch (shapeDirection)
                        {
                            case 1:
                                if (!grid.check3RotationSquares(coreShapeX, coreShapeY + 1, coreShapeX - 1, coreShapeY - 1, coreShapeX, coreShapeY - 1)) return;
                                grid.moveThreeSquares(coreShapeX - 1, coreShapeX, coreShapeY, coreShapeY + 1, coreShapeX + 1, coreShapeX - 1, coreShapeY - 1, coreShapeY - 1, coreShapeX + 1, coreShapeX, coreShapeY, coreShapeY - 1);
                                shapeDirection = 4;
                                break;
                            case 2:
                                if (!grid.check3RotationSquares(coreShapeX - 1, coreShapeY, coreShapeX + 1, coreShapeY - 1, coreShapeX + 1, coreShapeY)) return;
                                grid.moveThreeSquares(coreShapeX, coreShapeX - 1, coreShapeY - 1, coreShapeY, coreShapeX + 1, coreShapeX + 1, coreShapeY + 1, coreShapeY - 1, coreShapeX, coreShapeX + 1, coreShapeY + 1, coreShapeY);
                                shapeDirection = 1;
                                break;
                            case 3:
                                if (!grid.check3RotationSquares(coreShapeX, coreShapeY - 1, coreShapeX + 1, coreShapeY + 1, coreShapeX, coreShapeY + 1)) return;
                                grid.moveThreeSquares(coreShapeX + 1, coreShapeX, coreShapeY, coreShapeY - 1, coreShapeX - 1, coreShapeX + 1, coreShapeY + 1, coreShapeY + 1, coreShapeX - 1, coreShapeX, coreShapeY, coreShapeY + 1);
                                shapeDirection = 2;
                                break;
                            case 4:
                                if (!grid.check3RotationSquares(coreShapeX + 1, coreShapeY, coreShapeX - 1, coreShapeY + 1, coreShapeX - 1, coreShapeY)) return;
                                grid.moveThreeSquares(coreShapeX, coreShapeX + 1, coreShapeY + 1, coreShapeY, coreShapeX - 1, coreShapeX - 1, coreShapeY - 1, coreShapeY + 1, coreShapeX, coreShapeX - 1, coreShapeY - 1, coreShapeY);
                                shapeDirection = 3;
                                break;
                        }
                        break;

                    case 3:
                        //switch (shapeDirection)
                        //{
                        //    case 1:
                        //        break;
                        //    case 2:
                        //        break;
                        //    case 3:
                        //        break;
                        //    case 4:
                        //        break;
                        //}
                        break;

                    case 4:
                        switch (shapeDirection)
                        {
                            case 1:
                                if (!grid.check2RotationSquares(coreShapeX, coreShapeY + 1, coreShapeX - 1, coreShapeY - 1)) return;
                                grid.moveTwoSquares(coreShapeX, coreShapeX, coreShapeY - 1, coreShapeY + 1, coreShapeX + 1, coreShapeX - 1, coreShapeY - 1, coreShapeY - 1);
                                shapeDirection = 4;
                                break;
                            case 2:
                                if (!grid.check2RotationSquares(coreShapeX - 1, coreShapeY, coreShapeX + 1, coreShapeY - 1)) return;
                                grid.moveTwoSquares(coreShapeX + 1, coreShapeX - 1, coreShapeY, coreShapeY, coreShapeX + 1, coreShapeX + 1, coreShapeY + 1, coreShapeY - 1);
                                shapeDirection = 1;
                                break;
                            case 3:
                                if (!grid.check2RotationSquares(coreShapeX, coreShapeY - 1, coreShapeX + 1, coreShapeY + 1)) return;
                                grid.moveTwoSquares(coreShapeX, coreShapeX, coreShapeY + 1, coreShapeY - 1, coreShapeX - 1, coreShapeX + 1, coreShapeY + 1, coreShapeY + 1);
                                shapeDirection = 2;
                                break;
                            case 4:
                                if (!grid.check2RotationSquares(coreShapeX + 1, coreShapeY, coreShapeX - 1, coreShapeY + 1)) return;
                                grid.moveTwoSquares(coreShapeX - 1, coreShapeX + 1, coreShapeY, coreShapeY, coreShapeX - 1, coreShapeX - 1, coreShapeY - 1, coreShapeY + 1);
                                shapeDirection = 3;
                                break;
                        }
                        break;

                    case 5:
                        switch (shapeDirection)
                        {
                            case 1:
                                if (grid.checkSquare(coreShapeX, coreShapeY + 1)) return;
                                grid.MoveCube(coreShapeX + 1, coreShapeX, coreShapeY, coreShapeY + 1);
                                shapeDirection = 4;
                                break;
                            case 2:
                                if (grid.checkSquare(coreShapeX - 1, coreShapeY)) return;
                                grid.MoveCube(coreShapeX, coreShapeX - 1, coreShapeY + 1, coreShapeY);
                                shapeDirection = 1;
                                break;
                            case 3:
                                if (grid.checkSquare(coreShapeX, coreShapeY - 1)) return;
                                grid.MoveCube(coreShapeX - 1, coreShapeX, coreShapeY, coreShapeY - 1);
                                shapeDirection = 2;
                                break;
                            case 4:
                                if (grid.checkSquare(coreShapeX+1, coreShapeY )) return;
                                grid.MoveCube(coreShapeX, coreShapeX + 1, coreShapeY - 1, coreShapeY);
                                shapeDirection = 3;
                                break;
                        }
                        break;

                    case 6:
                        switch (shapeDirection)
                        {
                            case 1:
                                if (!grid.check2RotationSquares(coreShapeX - 1, coreShapeY, coreShapeX - 1, coreShapeY + 1)) return;
                                grid.moveTwoSquares(coreShapeX - 1, coreShapeX - 1, coreShapeY - 1, coreShapeY, coreShapeX + 1, coreShapeX - 1, coreShapeY, coreShapeY + 1);
                                shapeDirection = 4;
                                break;
                            case 2:
                                if (!grid.check2RotationSquares(coreShapeX - 1, coreShapeY - 1, coreShapeX, coreShapeY - 1)) return;
                                grid.moveTwoSquares(coreShapeX + 1, coreShapeX - 1, coreShapeY - 1, coreShapeY - 1, coreShapeX, coreShapeX, coreShapeY + 1, coreShapeY - 1);
                                shapeDirection = 1;
                                break;
                            case 3:
                                if (!grid.check2RotationSquares(coreShapeX + 1, coreShapeY - 1, coreShapeX + 1, coreShapeY)) return;
                                grid.moveTwoSquares(coreShapeX - 1, coreShapeX + 1, coreShapeY, coreShapeY - 1, coreShapeX + 1, coreShapeX + 1, coreShapeY + 1, coreShapeY);
                                shapeDirection = 2;
                                break;
                            case 4:
                                if (!grid.check2RotationSquares(coreShapeX, coreShapeY + 1, coreShapeX + 1, coreShapeY + 1)) return;
                                grid.moveTwoSquares(coreShapeX, coreShapeX, coreShapeY - 1, coreShapeY + 1, coreShapeX - 1, coreShapeX + 1, coreShapeY + 1, coreShapeY + 1);
                                shapeDirection = 3;
                                break;
                        }
                        break;
                }
            }
        }

    }
}
