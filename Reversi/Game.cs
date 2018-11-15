using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Reversi
{
    public class Game
    {
        private static int gridSize; //Grid.gridsize - 1, so it can be used as an array

        private static string turn = "Black"; //whose turn it is Black or White
        private static string enemyColor = "White"; //Enemy color

        private static int scoreBlack = 2; //score defaults to 2
        private static int scoreWhite = 2;

        private static bool showHints = true; //shows hints on possible moves

        public static string Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        public static string EnemyColor
        {
            set { enemyColor = value; }
        }

        public static int ScoreBlack
        {
            get { return scoreBlack; }
            set { scoreBlack = value; }
        }

        public static int ScoreWhite
        {
            get { return scoreWhite; }
            set { scoreWhite = value; }
        }

        public static bool ShowHints
        {
            get { return showHints; }
        }

        public static void SetUpPieces(Grid Grid1) //sets up the four center pieces
        {
            gridSize = Grid.GridSize - 1;
            Grid1.Squares[gridSize / 2, gridSize / 2].Status = "White"; //top left
            Grid1.Squares[gridSize / 2 + 1, gridSize / 2].Status = "Black"; //bottom left
            Grid1.Squares[gridSize / 2, gridSize / 2 + 1].Status = "Black"; //top right
            Grid1.Squares[gridSize / 2 + 1, gridSize / 2 + 1].Status = "White"; //bottom right
        }

        public static void SwitchTurn(Grid Grid1)
        {
            bool gameEnd = GameEnd(Grid1);

            if (turn == "Black")
            {
                turn = "White";
                enemyColor = "Black";
                Game.ResetPossibleStatus(Grid1);
                ShowMoves(Grid1);

                if (Square.PossibleCount == 0 && gameEnd == false) //skips turn
                {
                    SwitchTurn(Grid1);
                }
            }
            else
            {
                turn = "Black";
                enemyColor = "White";
                Game.ResetPossibleStatus(Grid1);
                ShowMoves(Grid1);

                if (Square.PossibleCount == 0 && gameEnd == false) //skips turn
                {
                    SwitchTurn(Grid1);
                }
            }
        }

        public static bool GameEnd(Grid Grid1) //test if all squares are filled
        {
            bool gameEnd = true;

            for (int y = 0; y < Grid.GridSize; y++)
            {
                for (int x = 0; x < Grid.GridSize; x++)
                {
                    if (Grid1.Squares[y, x].Status == "Possible")
                    {
                        gameEnd = false;
                    }
                }
            }
            return gameEnd;
        }

        public static void ResetPossibleStatus(Grid Grid1)
        {
            for (int y = 0; y < Grid.GridSize; y++)
            {
                for (int x = 0; x < Grid.GridSize; x++)
                {
                    if (Grid1.Squares[y, x].Status == "Possible")
                    {
                        Grid1.Squares[y, x].Status = "Empty";
                    }
                }
            }
            Square.PossibleCount = 0;
        }

        public static void GetNewScore(Grid Grid1, Label scoreBlack, Label scoreWhite)
        {
            Game.scoreBlack = 0;
            Game.scoreWhite = 0;

            for (int y = 0; y < Grid.GridSize; y++)
            {
                for (int x = 0; x < Grid.GridSize; x++)
                {
                    if (Grid1.Squares[y, x].Status == "Black")
                    {
                        Game.scoreBlack++;
                    }
                    else if (Grid1.Squares[y, x].Status == "White")
                    {
                        Game.ScoreWhite++;
                    }
                }
            }

            Decorations.UpdateScoreBoard(scoreBlack, scoreWhite);
        }

        public static void ShowMoves(Grid Grid1) //highlight areas that the player can go
        {
            for (int y = 0; y < Grid.GridSize; y++)
            {
                for (int x = 0; x < Grid.GridSize; x++)
                {
                    if (Grid1.Squares[y, x].Status == "Empty") //Tests all directions
                    {
                        TestVertHorz(Grid1, x, y);
                        TestDiagonal(Grid1, x, y);
                    }
                }
            }
            
        }

        public static void Move(Grid Grid1, int x, int y) //changes pieces to new color 
        {
            int xChange, yChange;

            if (Grid1.Squares[y, x].Possible[0] == true) //left up
            {
                xChange = -1;
                yChange = -1;
                TestMove(Grid1, x, y, xChange, yChange);
            }
            if (Grid1.Squares[y, x].Possible[1] == true) //up
            {
                xChange = 0;
                yChange = -1;
                TestMove(Grid1, x, y, xChange, yChange);
            }
            if (Grid1.Squares[y, x].Possible[2] == true) //up right
            {
                xChange = 1;
                yChange = -1;
                TestMove(Grid1, x, y, xChange, yChange);
            }
            if (Grid1.Squares[y, x].Possible[3] == true) //right
            {
                xChange = 1;
                yChange = 0;
                TestMove(Grid1, x, y, xChange, yChange);
            }
            if (Grid1.Squares[y, x].Possible[4] == true) //right down
            {
                xChange = 1;
                yChange = 1;
                TestMove(Grid1, x, y, xChange, yChange);
            }
            if (Grid1.Squares[y, x].Possible[5] == true) //down
            {
                xChange = 0;
                yChange = 1;
                TestMove(Grid1, x, y, xChange, yChange);
            }
            if (Grid1.Squares[y, x].Possible[6] == true) //down left
            {
                xChange = -1;
                yChange = 1;
                TestMove(Grid1, x, y, xChange, yChange);
            }
            if (Grid1.Squares[y, x].Possible[7] == true) //left
            {
                xChange = -1;
                yChange = 0;
                TestMove(Grid1, x, y, xChange, yChange);
            }

            Square.ResetAllPossible(Grid1);
        }

        public static void TestMove(Grid Grid1, int x, int y, int xChange, int yChange) //tests and changes enemy pieces 
        {
            int x1 = x + xChange;
            int y1 = y + yChange;

            while (Grid1.Squares[y1, x1].Status == enemyColor)
            {
                Grid1.Squares[y1, x1].Status = turn;
                x1 = x1 + xChange;
                y1 = y1 + yChange;
            }
        }

        public static void TestVertHorz(Grid Grid1, int x, int y) //Test vertically and horizontally 
        {
            if (x < Grid.GridSize - 2 && Grid1.Squares[y, x + 1].Status == enemyColor) //Right
            {
                for (int x1 = x; x1 < Grid.GridSize; x1++) //look for black piece
                {
                    if (Grid1.Squares[y, x1].Status == turn)
                    {
                        Grid1.Squares[y, x].Status = "Possible";
                        Grid1.Squares[y, x].Possible[3] = true;
                        Square.PossibleCount++;
                        break;
                    }
                }
            }
            if (x > 1 && Grid1.Squares[y, x - 1].Status == enemyColor) //Left
            {
                for (int x1 = x; x1 >= 0; x1--) //look for black piece
                {
                    if (Grid1.Squares[y, x1].Status == turn)
                    {
                        Grid1.Squares[y, x].Status = "Possible";
                        Grid1.Squares[y, x].Possible[7] = true;
                        Square.PossibleCount++;
                        break;
                    }
                }
            }
            if (y > 1 && Grid1.Squares[y - 1, x].Status == enemyColor) //Up
            {
                for (int y1 = y; y1 >= 0; y1--) //look for black piece
                {
                    if (Grid1.Squares[y1, x].Status == turn)
                    {
                        Grid1.Squares[y, x].Status = "Possible";
                        Grid1.Squares[y, x].Possible[1] = true;
                        Square.PossibleCount++;
                        break;
                    }
                }
            }
            if (y < Grid.GridSize - 2 && Grid1.Squares[y + 1, x].Status == enemyColor) //Down
            {
                for (int y1 = y; y1 < Grid.GridSize; y1++) //look for black piece
                {
                    if (Grid1.Squares[y1, x].Status == turn)
                    {
                        Grid1.Squares[y, x].Status = "Possible";
                        Grid1.Squares[y, x].Possible[5] = true;
                        Square.PossibleCount++;
                        break;
                    }
                }
            }
        }

        public static void TestDiagonal(Grid Grid1, int x, int y) //Test Diagonally
        {
            if (x > 1 && y > 1 && Grid1.Squares[y - 1, x - 1].Status == enemyColor) //Top Left
            {
                if (x <= y)
                {
                    int y1 = y;
                    for (int x1 = x; x1 >= 0; x1--) //look for black piece
                    {
                        if (Grid1.Squares[y1, x1].Status == turn)
                        {
                            Grid1.Squares[y, x].Status = "Possible";
                            Grid1.Squares[y, x].Possible[0] = true;
                            Square.PossibleCount++;
                            break;
                        }
                        y1--;
                    }
                }
                else //y < x
                {
                    int x1 = x;
                    for (int y1 = y; y1 >= 0; y1--) //look for black piece
                    {
                        if (Grid1.Squares[y1, x1].Status == turn)
                        {
                            Grid1.Squares[y, x].Status = "Possible";
                            Grid1.Squares[y, x].Possible[0] = true;
                            Square.PossibleCount++;
                            break;
                        }
                        x1--;
                    }
                }
            }
            if (x < Grid.GridSize - 2 && y > 1 && Grid1.Squares[y - 1, x + 1].Status == enemyColor) //Top Right
            {
                if (Grid.GridSize - x - 1 <= y)
                {
                    int y1 = y;
                    for (int x1 = x; x1 < Grid.GridSize; x1++) //look for black piece
                    {
                        if (Grid1.Squares[y1, x1].Status == turn)
                        {
                            Grid1.Squares[y, x].Status = "Possible";
                            Grid1.Squares[y, x].Possible[2] = true;
                            Square.PossibleCount++;
                            break;
                        }
                        y1--;
                    }
                }
                else //more y spaces
                {
                    int x1 = x;
                    for (int y1 = y; y1 >= 0; y1--) //look for black piece
                    {
                        if (Grid1.Squares[y1, x1].Status == turn)
                        {
                            Grid1.Squares[y, x].Status = "Possible";
                            Grid1.Squares[y, x].Possible[2] = true;
                            Square.PossibleCount++;
                            break;
                        }
                        x1++;
                    }
                }
            }
            if (x > 1 && y < Grid.GridSize - 2 && Grid1.Squares[y + 1, x - 1].Status == enemyColor) //Bottom Left
            {
                if (x <= Grid.GridSize - y - 1)
                {
                    int y1 = y;
                    for (int x1 = x; x1 >= 0; x1--) //look for black piece
                    {
                        if (Grid1.Squares[y1, x1].Status == turn)
                        {
                            Grid1.Squares[y, x].Status = "Possible";
                            Grid1.Squares[y, x].Possible[6] = true;
                            Square.PossibleCount++;
                            break;
                        }
                        y1++;
                    }
                }
                else //more y spaces
                {
                    int x1 = x;
                    for (int y1 = y; y1 < Grid.GridSize; y1++) //look for black piece
                    {
                        if (Grid1.Squares[y1, x1].Status == turn)
                        {
                            Grid1.Squares[y, x].Status = "Possible";
                            Grid1.Squares[y, x].Possible[6] = true;
                            Square.PossibleCount++;
                            break;
                        }
                        x1--;
                    }
                }
            }
            if (x < Grid.GridSize - 2 && y < Grid.GridSize - 2 && Grid1.Squares[y + 1, x + 1].Status == enemyColor) //Bottom Right
            {
                if (x >= y)
                {
                    int y1 = y;
                    for (int x1 = x; x1 < Grid.GridSize; x1++) //look for black piece
                    {
                        if (Grid1.Squares[y1, x1].Status == turn)
                        {
                            Grid1.Squares[y, x].Status = "Possible";
                            Grid1.Squares[y, x].Possible[4] = true;
                            Square.PossibleCount++;
                            break;
                        }
                        y1++;
                    }
                }
                else //y > x
                {
                    int x1 = x;
                    for (int y1 = y; y1 < Grid.GridSize; y1++) //look for black piece
                    {
                        if (Grid1.Squares[y1, x1].Status == turn)
                        {
                            Grid1.Squares[y, x].Status = "Possible";
                            Grid1.Squares[y, x].Possible[4] = true;
                            Square.PossibleCount++;
                            break;
                        }
                        y1++;
                    }
                }
            }
        }
    }
}
