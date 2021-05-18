using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeRacing
{
    public class EatCheese 
    {
        public static bool Eat(PictureBox picture, int currentAnimation)
        {
            var currObject = Map.mapObjects1[0];
            PointF delta = new PointF();
            delta.X = (picture.Location.X + Map.size / 2) - (currObject.position.X + currObject.size.Width / 2);
            delta.Y = (picture.Location.Y + Map.size / 2) - (currObject.position.Y + currObject.size.Height / 2);
            if (Math.Abs(delta.X) <= Map.size / 2 + currObject.size.Width / 2)
            {
                if (Math.Abs(delta.Y) <= Map.size / 2 + currObject.size.Height / 2)
                {
                    if (delta.X < 0 && currentAnimation == 3 && picture.Location.Y + picture.Height > currObject.position.Y && picture.Location.Y + picture.Size.Height / 100 < currObject.position.Y + currObject.size.Height)
                    {
                        //picture.Location = new Point(picture.Location.X - 6, picture.Location.Y);
                        return true;
                       
                    }
                    if (delta.X > 0 && currentAnimation == 1 && picture.Location.Y + picture.Height > currObject.position.Y && picture.Location.Y + picture.Size.Height / 100 < currObject.position.Y + currObject.size.Height)
                    {
                        //picture.Location = new Point(picture.Location.X + 6, picture.Location.Y);
                        return true;
                       
                    }
                    if (delta.Y < 0 && currentAnimation == 2 && picture.Location.X + picture.Width > currObject.position.X && picture.Location.X + picture.Size.Width / 100 < currObject.position.X + currObject.size.Width)
                    {
                        //picture.Location = new Point(picture.Location.X, picture.Location.Y - 6);
                        return true;

                    }
                    if (delta.Y > 0 && currentAnimation == 0 && picture.Location.X + picture.Width > currObject.position.X && picture.Location.X + picture.Size.Width / 100 < currObject.position.X + currObject.size.Width)
                    {
                        //picture.Location = new Point(picture.Location.X, picture.Location.Y + 6);

                        return true;
                    }
                }
            }
            return false;
        }
    }
}
