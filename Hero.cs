using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeRacing
{
    public class Hero
    {
        public   Image Img;

        public  string Name { get; set; }

        public void ToString()
        {
            MessageBox.Show("Ви граете за - " + Name);
        }
    }
}
