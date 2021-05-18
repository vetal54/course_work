using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeRacing
{
    class PCplayer : Hero
    {
        public static int[,] ar; 
        public static int Distance;
        public static int[] Go(PictureBox pic, int[] arr,Graphics g, PCplayer player, Timer timer, Timer timer1, Timer timer2)
        {
            int higth = ar.GetLength(0);
            int wigth = ar.GetLength(1);
            int j = arr[1];
            int i = arr[0];
            Distance--;
            if (Distance == 0)
            {
                timer.Stop();
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("You Lose");
                return arr;
            }
            if (j != 9 && ar[i, j + 1] == -3)
            {
                ar[i, j] = -7;
                PlayAnimationMovement(player, g, pic, 3);
                player.KeyBoard(pic, 3);
                j += 1;
                arr[0] = i; arr[1] = j;
                return arr;
            }
            else if (j != 0 && ar[i, j - 1] == -3)
            {
                ar[i, j] = -7;
                PlayAnimationMovement(player, g, pic, 1);
                player.KeyBoard(pic, 1);
                j -= 1;
                arr[0] = i; arr[1] = j;
                return arr;
            }
            else if (i != 0 && ar[i - 1, j] == -3)
            {
                ar[i, j] = -7;
                PlayAnimationMovement(player, g, pic, 0);
                player.KeyBoard(pic, 0);
                i -= 1;
                arr[0] = i; arr[1] = j;
                return arr;
            }
            else if (i != 9 && ar[i + 1, j] == -3)
            {
                ar[i, j] = -7;
                PlayAnimationMovement(player, g, pic, 2);
                player.KeyBoard(pic, 2);
                i += 1;
                arr[0] = i; arr[1] = j;
                return arr;
            }
            return arr;
            
        }

        public static void PlayAnimationMovement(PCplayer player, Graphics g, PictureBox picture, int currentAnimation)
        {
            if (currentAnimation != -1)
            {
                Image part = new Bitmap(44, 64);
                g = Graphics.FromImage(part);
                g.DrawImage(player.Img, -22, -18, new Rectangle(new Point(64 * 1, 64 * currentAnimation), new Size(64 * 1, 64)), GraphicsUnit.Pixel);
                picture.Size = new Size(42, 60);
                picture.Image = part;
            }
        }

        public override void KeyBoard(PictureBox picture, int currentAnimation)
        {

            if (currentAnimation != -1) 
            { 
                switch (currentAnimation)
                {
                    case 0:
                        picture.Location = new Point(picture.Location.X, picture.Location.Y - 60);
                        break;
                    case 2:
                        picture.Location = new Point(picture.Location.X, picture.Location.Y + 60);
                        break;
                    case 1:
                        picture.Location = new Point(picture.Location.X - 60, picture.Location.Y);
                        break;
                    case 3:
                        picture.Location = new Point(picture.Location.X + 60, picture.Location.Y);
                        break;
                }
            }
            
        }

        public static void Maap(int [,] arr)
        {
            ar = arr;
        }
        public static void PrintShortestDistance(int[,] array, int i, int j, int NeighborNumber)
        {
            int higth = array.GetLength(0);
            int wigth = array.GetLength(1);
            int iF = i;
            int jF = j;
            array[iF, jF] = -3;
            int Count = NeighborNumber;
            NeighborNumber--;
            for (int q = 0; q < Count; q++)
            {
                if (iF != 0 && array[iF - 1, jF] == NeighborNumber)
                {
                    array[iF - 1, jF] = -3;
                    iF = iF - 1;
                }
                else if (iF != higth - 1 && array[iF + 1, jF] == NeighborNumber)
                {
                    array[iF + 1, jF] = -3;
                    iF = iF + 1;
                }
                else if (jF != 0 && array[iF, jF - 1] == NeighborNumber)
                {
                    array[iF, jF - 1] = -3;
                    jF = jF - 1;
                }
                else if (jF != wigth - 1 && array[iF, jF + 1] == NeighborNumber)
                {
                    array[iF, jF + 1] = -3;
                    jF = jF + 1;
                }
                NeighborNumber--;
            }
            Maap(array);
        }
       

        static void neighbors(int NeighborNumber, int[,] array, List<int> list, int distance)
        {
            int higth = array.GetLength(0);
            int wigth = array.GetLength(1);
            int Iindex = 0;
            int Jindex = 1;
            int count = 0;
            int count2 = 1;
            int i = 0;
            int j = 0;
            bool b = true;
            for (int q = 0; q < list.Count / 2; q++)
            {
                i = list[Iindex];
                j = list[Jindex];

                
                if (i!=0 && array[i - 1, j] == -5)
                {
                    Distance = NeighborNumber;
                    PrintShortestDistance(array, i-1, j, NeighborNumber);
                    break;
                }
                if (i!=0 && array[i - 1, j] == -2)
                {
                    array[i - 1, j] = NeighborNumber;
                    list.Add(i - 1);
                    list.Add(j);
                    count++;
                    b = false;
                }
                if (i != 9 && array[i + 1, j] == -5)
                {
                    Distance = NeighborNumber;
                    PrintShortestDistance(array, i+1, j, NeighborNumber);
                    break;
                }
                if (i!=9 && array[i + 1, j] == -2)
                {
                    array[i + 1, j] = NeighborNumber;
                    list.Add(i + 1);
                    list.Add(j);
                    count++;
                    b = false;
                }
                if (j!=0 && array[i, j-1] == -5)
                {
                    Distance = NeighborNumber;
                    PrintShortestDistance(array, i, j-1, NeighborNumber);
                    break;
                }
                if (j != 0 && array[i, j - 1] == -2)
                {
                    array[i, j - 1] = NeighborNumber;
                    list.Add(i);
                    list.Add(j - 1);
                    count++;
                    b = false;
                }
                if (j != 9 && array[i, j+1] == -5)
                {
                    Distance = NeighborNumber;
                    PrintShortestDistance(array, i, j+1, NeighborNumber);
                    break;
                }
                if (j!=9 && array[i, j + 1] == -2)
                {
                    array[i, j + 1] = NeighborNumber;
                    list.Add(i);
                    list.Add(j + 1);
                    count++;
                    b = false;
                }
                Iindex += 2;
                Jindex += 2;
                count2--;

                if (count2 == 0)
                {
                    count2 = count;
                    count = 0;
                    NeighborNumber++;
                    distance++;
                    
                }
            }
        }

        
        public static void start(int [,] arr) {
            int[,] array = arr;
            int NeighborNumber = 1;
            List<int> list = new List<int>();
            int higth = array.GetLength(0);
            int wigth = array.GetLength(1);
            int distance = 0;
            for(int i = 0; i<higth;i++)
            {
                for(int j = 0;j<wigth;j++)
                {
                    if (array[i, j] == -4)
                    {
                        array[i, j]=0;
                        list.Add(i);
                        list.Add(j);
                    }
                }
            }
            
            neighbors(NeighborNumber, array, list, distance);
        }     
    }
}
