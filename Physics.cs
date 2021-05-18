using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeRacing
{
    public static class Physics
    {
        public static int IsCollide(PictureBox picture, int currentAnimation)
        {
                int b=-3;
                for (int i = 0; i < Map.mapObjects.Count; i++)
                {
                    var currObject = Map.mapObjects[i];
                    PointF delta = new PointF();
                    delta.X = (picture.Location.X + Map.size / 2) - (currObject.position.X + currObject.size.Width / 2);
                    delta.Y = (picture.Location.Y + Map.size / 2) - (currObject.position.Y + currObject.size.Height / 2);
                    if (Math.Abs(delta.X) <= Map.size / 2 + currObject.size.Width / 2)
                    {
                        if (Math.Abs(delta.Y) <= Map.size / 2 + currObject.size.Height / 2)
                        {
                            if (delta.X < 0 && currentAnimation == 3 && picture.Location.Y + picture.Height > currObject.position.Y && picture.Location.Y + picture.Size.Height / 100 < currObject.position.Y + currObject.size.Height)
                            {
                                 b = -1;
                                 return b;
                            }

                            if (delta.X > 0 && currentAnimation == 1 && picture.Location.Y + picture.Height > currObject.position.Y && picture.Location.Y + picture.Size.Height / 100 < currObject.position.Y + currObject.size.Height)
                            {
                                 b = -1;
                                 return b;
                            }

                            if (delta.Y < 0 && currentAnimation == 2 && picture.Location.X + picture.Width > currObject.position.X && picture.Location.X + picture.Size.Width / 100 < currObject.position.X + currObject.size.Width)
                            {
                                 b = -1;
                                 return b;
                            }   

                            if (delta.Y > 0 && currentAnimation == 0 && picture.Location.X + picture.Width > currObject.position.X && picture.Location.X + picture.Size.Width / 100 < currObject.position.X + currObject.size.Width)
                            {
                                 b = -1;
                                 return b;
                            }
                           
                        }
                        
                    }
                   
                }
            if (b != -1) return -2;
            else return b;
            
            
        }
    }
}
