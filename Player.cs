using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeRacing
{
    public class Player : Hero
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
    }
}
