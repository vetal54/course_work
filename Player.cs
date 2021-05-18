using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeRacing
{
    class Player : Hero
    {
        public static void PlayAnimationMovement(Player player,Graphics g, PictureBox picture, int currentAnimation, int currentFrame)
        {
            if (currentAnimation != -1)
            {
                Image part = new Bitmap(46, 64);
                g = Graphics.FromImage(part);
                g.DrawImage(player.Img, -22, -18, new Rectangle(new Point(64 * currentFrame, 64 * currentAnimation), new Size(64 * currentFrame, 64)), GraphicsUnit.Pixel);
                picture.Size = new Size(42, 64);
                picture.Image = part;
            }
        }

        public override void KeyBoard(PictureBox picture, int currentAnimation)
        {
            int a = Physics.IsCollide(picture, currentAnimation);
            if (a != -1)
            {
                switch (currentAnimation)
                {
                    case 0:
                        picture.Location = new Point(picture.Location.X, picture.Location.Y - 3);
                        break;
                    case 2:
                        picture.Location = new Point(picture.Location.X, picture.Location.Y + 3);
                        break;
                    case 1:
                        picture.Location = new Point(picture.Location.X - 3, picture.Location.Y);
                        break;
                    case 3:
                        picture.Location = new Point(picture.Location.X + 4, picture.Location.Y);
                        break;
                }
            }
        }

    

        public static int KeyCode(KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "W":
                    return 0;
                    break;
                case "S":
                    return 2;
                    break;
                case "A":
                    return 1;
                    break;
                case "D":
                    return 3;
                    break;
                default:
                    return -1;
                        
            }
        }
    }
}
