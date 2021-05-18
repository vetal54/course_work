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
        PCplayer PCPlayer;
        Graphics g;
        private int currentFrame = 2;
        private int currentAnimation = -1;
        public static int[,] array;
        public int[] arr = new int[2] { 8, 1 };

        public Form1()
        {
            InitializeComponent();
            hero = new Hero[2];
            player = new Player();
            player.Img = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\men.png"));
            player.Name = "TOM";

            PCPlayer = new PCplayer();
            PCPlayer.Img = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\soldier.png"));
            PCPlayer.Name = "PC Player";
            pictureBox2.Location = new Point( 1 * 60,8*60);
            hero[0] = player;
            hero[1] = PCPlayer;
            player.ToString();

            Map.map = Map.GetMap();
            
            timer2.Interval = 50;
            timer2.Tick += new EventHandler(updatemove);

            timer3.Interval = 1000;
            timer3.Tick += new EventHandler(updatemove1);

            timer1.Interval = 100;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            timer2.Start();
            timer3.Start();
            PCplayer.start(Map.GetMap());
            this.KeyDown += new KeyEventHandler(keyboard);
            this.KeyUp += new KeyEventHandler(freeKeyb);
        }

        private void freeKeyb(object sender, KeyEventArgs e)
        {
            currentAnimation = -1;
        }

        private void updatemove(object sender, EventArgs e)
        {
            player.KeyBoard(pictureBox1, currentAnimation);
           
        }

        private void updatemove1(object sender, EventArgs e)
        {
            
            array = PCplayer.ar;
            arr = PCplayer.Go(pictureBox2, arr,g, PCPlayer,timer3,timer1,timer2);
           
        }

        private void keyboard(object sender, KeyEventArgs e)
        {
            currentAnimation = Player.KeyCode(e);
            //PCplayer.start(Map.GetMap());
            //array = PCplayer.ar;
            //arr = PCplayer.Go(pictureBox2, arr);
        }

        private void update(object sender, EventArgs e)
        {
            player.KeyBoard(pictureBox1, currentAnimation);
            if (EatCheese.Eat(pictureBox1, currentAnimation))
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                MessageBox.Show("Ви перемогли");

                //pictureBox1.Location = new Point(100, 100);
                //timer1.Start();
                //timer2.Start();
            }
            Player.PlayAnimationMovement(player, g, pictureBox1, currentAnimation, currentFrame);
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
