using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Reversi
{
    public class Grid
    {
        private static int gridSize = 8; //keep even 8 is standard 
        public Square[,] Squares = new Square[gridSize, gridSize];

        public static int GridSize
        {
            get { return gridSize; }
        }


        public Grid()
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    Squares[y, x] = new Square(x * Square.SquareSize, y * Square.SquareSize);
                }
            }
        }

        public void TestClick(Grid Grid1, Label scoreBlack, Label scoreWhite, int mouseX, int mouseY)
        {
            for (int y = 0; y < Grid.gridSize; y++) //could do foreach, but need to store current x and y
            {
                for (int x = 0; x < Grid.gridSize; x++)
                {
                    Squares[y, x].TestClick(Grid1, scoreBlack, scoreWhite, mouseX, mouseY, x, y);
                }
            }
        }

        public void Paint_Grid(PaintEventArgs e)
        {
            foreach (Square i in Squares)
            {
                i.Paint_Square(e);
            }
        }
    }
}
