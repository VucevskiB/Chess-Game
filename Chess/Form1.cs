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
        public Form1() {
            InitializeComponent();
            game = new Game(this);

            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            GameBox.Width = Game.IMAGE_SIZE * 8;
            GameBox.Height = Game.IMAGE_SIZE * 8;

            GameBox.MouseClick += new MouseEventHandler(Form1_MouseClick);



        }
        private void gamePanel_Paint(object sender, PaintEventArgs e) {
            game.draw(e.Graphics);
            //GameBox.Invalidate();
            //e.Graphics.Clear(Color.White);
            //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;





        }
        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            game.onBoardClick(e.X / Game.IMAGE_SIZE, e.Y / Game.IMAGE_SIZE);
            //game.changePos(new Point(e.X / Game.IMAGE_SIZE, e.Y / Game.IMAGE_SIZE));
            GameBox.Invalidate();
            
        }

        private void button1_Click(object sender, EventArgs e) {
            MessageBox.Show("sdadsa");
        }
    }
}
