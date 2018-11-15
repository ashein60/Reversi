using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Reversi
{
    public class Decorations
    {

        public static void UpdateScoreBoard(Label scoreBlack, Label scoreWhite)
        {
            scoreBlack.Text = "Black: " + Game.ScoreBlack;
            scoreWhite.Text = "White: " + Game.ScoreWhite;
        }

        public static void Paint_Decorations(PaintEventArgs e)
        {
            Brush Black = new SolidBrush(Color.Black);
            Brush White = new SolidBrush(Color.White);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None; //reset for squares
            
            if (Game.Turn == "Black")
            {
                e.Graphics.FillEllipse(Black, 78, 495, 40, 40);
            }
            else //turn == "White"
            {
                e.Graphics.FillEllipse(White, 78, 495, 40, 40);
            }

            Black.Dispose();
            White.Dispose();
        }
    }
}
