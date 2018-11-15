namespace Reversi
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.turnLabel = new System.Windows.Forms.Label();
            this.scoreBlack = new System.Windows.Forms.Label();
            this.scoreWhite = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // turnLabel
            // 
            this.turnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnLabel.ForeColor = System.Drawing.Color.White;
            this.turnLabel.Location = new System.Drawing.Point(0, 485);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(78, 60);
            this.turnLabel.TabIndex = 0;
            this.turnLabel.Text = "Turn:";
            this.turnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreBlack
            // 
            this.scoreBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreBlack.ForeColor = System.Drawing.Color.White;
            this.scoreBlack.Location = new System.Drawing.Point(179, 485);
            this.scoreBlack.Name = "scoreBlack";
            this.scoreBlack.Size = new System.Drawing.Size(150, 60);
            this.scoreBlack.TabIndex = 1;
            this.scoreBlack.Text = "Black: 2";
            this.scoreBlack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scoreWhite
            // 
            this.scoreWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreWhite.ForeColor = System.Drawing.Color.White;
            this.scoreWhite.Location = new System.Drawing.Point(335, 485);
            this.scoreWhite.Name = "scoreWhite";
            this.scoreWhite.Size = new System.Drawing.Size(150, 60);
            this.scoreWhite.TabIndex = 2;
            this.scoreWhite.Text = "White: 2";
            this.scoreWhite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(485, 545);
            this.Controls.Add(this.scoreWhite);
            this.Controls.Add(this.scoreBlack);
            this.Controls.Add(this.turnLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reversi";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Paint_Everything);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Click_Piece);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label scoreBlack;
        private System.Windows.Forms.Label scoreWhite;
    }
}

