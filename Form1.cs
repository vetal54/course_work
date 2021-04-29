using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MazeRacing
{
    public partial class Form1 : Form
    {
        Hero[] hero;
        Player player;
        Graphics g;
        private int currentFrame = 2;
        private int currentAnimation = -1;

        public Form1()
        {
            InitializeComponent();
            hero = new Hero[2];
            player = new Player();
            player.Img = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\soldier.png"));
            player.Name = "TOM";
            hero[0] = player;
            player.ToString();

            Map.map = Map.GetMap();
            
            timer2.Interval = 50;
            timer2.Tick += new EventHandler(updatemove);

            timer1.Interval = 100;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            timer2.Start();

            this.KeyDown += new KeyEventHandler(keyboard);
            this.KeyUp += new KeyEventHandler(freeKeyb);
        }

        private void freeKeyb(object sender, KeyEventArgs e)
        {
            
            currentAnimation = -1;
        }

        private void updatemove(object sender, EventArgs e)
        {
            switch (currentAnimation)
            {
                case 0:
                    currentAnimation = 0;
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 3);
                    break;
                case 2:
                    currentAnimation = 2;
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 3);
                    break;
                case 1:
                    currentAnimation = 1;
                    pictureBox1.Location = new Point(pictureBox1.Location.X - 3, pictureBox1.Location.Y);
                    break;
                case 3:
                    currentAnimation = 3;
                    pictureBox1.Location = new Point(pictureBox1.Location.X + 4, pictureBox1.Location.Y);
                    break;
            }
        }

        private void keyboard(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode.ToString())
            {
                case "W":
                    currentAnimation = 0;
                    break;
                case "S":
                    currentAnimation = 2;
                    break;
                case "A":
                    currentAnimation = 1;
                    break;
                case "D":
                    currentAnimation = 3;
                    break;
            }
        }

        private void update(object sender, EventArgs e)
        {
            Physics.IsCollide(pictureBox1, currentAnimation);
            if(EatCheese.Eat(pictureBox1, currentAnimation))
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("Ви перемогли");
               
                pictureBox1.Location = new Point(100,100);
                timer1.Start();
                timer2.Start();
            }
            Player.PlayAnimationMovement(player,g,pictureBox1,currentAnimation,currentFrame);
            if (currentFrame == 8)
                 currentFrame = 0;
            currentFrame++;
            
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Map.DrawMap(g);
        }
    }
}
