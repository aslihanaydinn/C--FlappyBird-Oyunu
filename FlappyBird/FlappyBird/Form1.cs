using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }
        public void EndGame()
        {
            timer_GameControl.Stop();
            label1.Text = "GAME OVER";
        }

        private void gameTimer(object sender, EventArgs e)
        {
            pictureBox_Bird.Top += gravity;
            picturebox_Bot.Left -= pipeSpeed;
            picturebox_top.Left -= pipeSpeed;
            label1.Text = "SCORE: " + score;

            if (picturebox_Bot.Left<-150)
            {
                picturebox_Bot.Left = 800;
                score++;
            }
            if (picturebox_top.Left < -180)
            {
                picturebox_top.Left = 950;
                score++;
            }
            if (pictureBox_Bird.Bounds.IntersectsWith(picturebox_Bot.Bounds) || 
                pictureBox_Bird.Bounds.IntersectsWith(picturebox_top.Bounds) ||
                pictureBox_Bird.Bounds.IntersectsWith(pictureBox_Ground.Bounds) || 
                pictureBox_Bird.Top < -25)
            {
                EndGame();
            }
            
        }

        private void game_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void game_Up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity =     15;
            }
        }
    }
}
