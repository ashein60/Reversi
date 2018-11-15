using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Reversi
{
    public class Square
    {
        private static int gapSize = 5; //gap between squares
        private static int squareSize = 60; 
        private static int pieceSize = 48;
        private static int pieceGap = (squareSize - pieceSize) / 4; //keeps the pieces center

        private int positionX;
        private int positionY;

        private bool[] possible = new bool[8]; //test all touching pieces, 0 top left, clockwise to 7 being left
        private static int possibleCount = 0; //tests if there is at least 1 possible

        private string status; //can be Black, White, Empty, Possible (can put a piece down)

        public static int GapSize
        {
            get { return gapSize; }
        }

        public static int SquareSize
        {
            get { return squareSize; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public bool[] Possible
        {
            get { return possible; }
            set { possible = value; }
        }

        public static int PossibleCount
        {
            get { return possibleCount; }
            set { possibleCount = value; }
        }

        public Square(int positionX, int positionY) 
        {
            this.positionX = positionX + gapSize; //gap temporarily added to make use of the gap in painting
            this.positionY = positionY + gapSize;

            status = "Empty";
        }

        public static void ResetAllPossible(Grid Grid1) //fills and defaults everything
        {
            for (int y = 0; y < Grid.GridSize; y++)
            {
                for (int x = 0; x < Grid.GridSize; x++)
                {
                    for (int i = 0; i < Grid1.Squares[y, x].possible.Length; i++)
                    {
                        Grid1.Squares[y, x].possible[i] = false;
                    }
                }
            }
        }

        public void TestClick(Grid Grid1, Label scoreBlack, Label scoreWhite, int mouseX, int mouseY, int x, int y)
        {
            if (mouseX >= positionX && mouseX <= positionX + squareSize)
            {
                if (mouseY >= positionY && mouseY <= positionY + squareSize)
                {
                    if (status == "Possible") //can't click on an existing piece
                    {
                        Game.Move(Grid1, x, y); //need x and y
                        status = Game.Turn;
                        Game.SwitchTurn(Grid1);
                        Game.GetNewScore(Grid1, scoreBlack, scoreWhite);
                    }
                }
            }
        }

        public void Paint_Square(PaintEventArgs e)
        {
            Brush Background = new SolidBrush(Color.LimeGreen);
            Brush Black = new SolidBrush(Color.Black);
            Brush White = new SolidBrush(Color.White);
            Brush Possible = new SolidBrush(Color.FromArgb(0 , 170, 0));

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None; //reset for squares
            e.Graphics.FillRectangle(Background, positionX, positionY, squareSize - gapSize, squareSize - gapSize);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //only used for pieces

            if (status == "Black")
            {
                e.Graphics.FillEllipse(Black, positionX + pieceGap, positionY + pieceGap, pieceSize, pieceSize);
            }
            else if (status == "White")
            {
                e.Graphics.FillEllipse(White, positionX + pieceGap, positionY + pieceGap, pieceSize, pieceSize);
            }
            else if (status == "Possible")
            {
                if (Game.ShowHints == true)
                {
                    e.Graphics.FillEllipse(Possible, positionX + pieceGap, positionY + pieceGap, pieceSize, pieceSize);
                }
            }

            Background.Dispose(); //don't create a hole
            Black.Dispose();
            White.Dispose();
            Possible.Dispose();
        }
    }
}
