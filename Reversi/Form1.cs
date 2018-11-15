using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    public partial class mainForm : Form
    {
        Grid Grid1 = new Grid();

        private int mouseX;
        private int mouseY;

        public mainForm()
        {
            InitializeComponent();

            NewGame();
        }

        public void NewGame()
        {
            Square.ResetAllPossible(Grid1);
            Game.SetUpPieces(Grid1);
            Game.Turn = "Black";
            Game.EnemyColor = "White";
            Game.ShowMoves(Grid1); //shows possible moves
            this.Invalidate(); //repaints to show possible moves
        }

        private void Click_Piece(object sender, MouseEventArgs e)
        {
            mouseX = this.PointToClient(Cursor.Position).X;
            mouseY = this.PointToClient(Cursor.Position).Y;

            Grid1.TestClick(Grid1, scoreBlack, scoreWhite, mouseX, mouseY);
            this.Invalidate(); //repaint
        }

        private void Paint_Everything(object sender, PaintEventArgs e)
        {
            Grid1.Paint_Grid(e);

            Decorations.Paint_Decorations(e); //displays whose turn it is
        }
    }
}
