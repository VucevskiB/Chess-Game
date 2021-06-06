using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Chess : Form
    {
        //1 = black ,  2 = white
        int color;
        Random random = new Random();
        public Chess() {
            InitializeComponent();
            color = 2;
            selector.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y - 50);
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e) {
            selector.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 50);
            color = 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            selector.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 50);
            color = random.Next(0,3);
        }

        private void pictureBox3_Click(object sender, EventArgs e) {
            selector.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y - 50);
            color = 2;
        }

        private void StartButton_Click(object sender, EventArgs e) {
            var form = new Form1(radioButton2.Checked, color);
            var t = new Thread(() => Application.Run(new Form1(radioButton2.Checked, color)));
            t.Start();

            this.Close();
        }
    }
}
