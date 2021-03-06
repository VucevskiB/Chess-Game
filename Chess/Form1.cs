using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        
        Game game;
        public int TimeGiven { get; set; }
        private int blacksTime;
        private int whitesTime;

        public bool ActivateAI { get; set; }
        public Piece.COLOR Player1Color { get; set; }
        public Piece.COLOR Player2Color { get; set; }

        Piece.COLOR AICOLOR;

        public Form1(bool isAIActive, int color) {
            ActivateAI = isAIActive;
            setColors(color);

            InitializeComponent();

            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            GameBox.Width = Game.IMAGE_SIZE * 8;
            GameBox.Height = Game.IMAGE_SIZE * 8;

            GameBox.MouseClick += new MouseEventHandler(Form1_MouseClick);

            TimeGiven = 5;
            whitesTime = TimeGiven * 60;
            blacksTime = TimeGiven * 60;

            int seconds = whitesTime % 60;
            clockWhite.Text = (whitesTime / 60) + ":" + seconds + "0";

            seconds = blacksTime % 60;
            clockBlack.Text = (blacksTime / 60) + ":" + seconds + "0";

            WhitePointsTxt.Text = "";
            BlackPointsTxt.Text = "";

            if (ActivateAI)
                AICOLOR = Player2Color;

            game = new Game(this);

        }
        public void setColors(int i) { 
            if(i == 1) {
                Player1Color = Piece.COLOR.BLACK;
                Player2Color = Piece.COLOR.WHITE;
            }
            else {
                Player1Color = Piece.COLOR.WHITE;
                Player2Color = Piece.COLOR.BLACK;
            }
        }
        public void gamePanel_Paint(object sender, PaintEventArgs e) {
            game.draw(e.Graphics);
            setScoreCount();
            setTurnText();

            if(game.WhitesTurn == (AICOLOR == Piece.COLOR.WHITE) && ActivateAI) {
                ResignButton.Enabled = false;
            }
            else {
                ResignButton.Enabled = true;
            }
            //GameBox.Invalidate();
            //e.Graphics.Clear(Color.White);
            //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;





        }
        private Bitmap drawGreenCircle() {
            int nSize = 20;
            Bitmap bm = new Bitmap(whiteGreenCheck.Width, whiteGreenCheck.Height);
            using (Graphics gr = Graphics.FromImage(bm)) {
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.FillEllipse(Brushes.Green, Convert.ToInt32((whiteGreenCheck.Width - nSize) / 2), Convert.ToInt32((whiteGreenCheck.Height - nSize) / 2), nSize, nSize);
            }
            return bm;
        }
        private void setTurnText() {
            whiteGreenCheck.Image = null;
            blackGreenCheck.Image = null;
            if (game.WhitesTurn) {
                TurnText.Text = "Whites Turn";
                whiteGreenCheck.Image = drawGreenCircle();
            }
            else {
                TurnText.Text = "Blacks Turn";
                blackGreenCheck.Image = drawGreenCircle();
            }  
            
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            if (!(game.WhitesTurn == (AICOLOR == Piece.COLOR.WHITE) && ActivateAI)) {
                game.onBoardClick(e.X / Game.IMAGE_SIZE, e.Y / Game.IMAGE_SIZE);
            }
            //game.changePos(new Point(e.X / Game.IMAGE_SIZE, e.Y / Game.IMAGE_SIZE));
            GameBox.Invalidate();
            setScoreCount();



        }
        private void setScoreCount() {
            int eval = game.MainBoard.PieceCount;
            WhitePointsTxt.Text = "";
            BlackPointsTxt.Text = "";
            if (eval > 0) {
                WhitePointsTxt.Text = "+" + Math.Abs(eval)/10;
            }
            else if(eval < 0){
                BlackPointsTxt.Text = "+" + Math.Abs(eval)/10;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            string text = "Black has lost";
            if (game.WhitesTurn) {
                text = "White has lost";
            }

            var popUp = MessageBox.Show(text);
            if(popUp == DialogResult.OK) {
                var game = new Chess();
                var t = new Thread(() => Application.Run(new Chess()));
                t.Start();

                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (game.WhitesTurn) {
                whitesTime--;
                int seconds = whitesTime % 60;
                clockWhite.Text = (whitesTime / 60) + ":" +  seconds;
            }
            else {
                blacksTime--;
                int seconds = blacksTime % 60;
                clockBlack.Text = (blacksTime / 60) + ":" + seconds;
            }
            //clockBlack.Text = i + "";
        }

    }
}
