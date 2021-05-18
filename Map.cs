using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeRacing
{
    public static class Map
    {
        public const int mapHeight = 10;
        public const int mapWidth = 10;
        public static int size = 60;
        public static List<MapEntity> mapObjects;
        public static List<MapEntity> mapObjects1;
      
        public static int[,] map = new int[mapHeight, mapWidth];

        public static int[,] GetMap()
        {
            return new int[,]{
               {-1,-1,-1,-2,-1,-1,-1,-1,-1,-1},
               {-2,-2,-2,-2,-2,-2,-2,-2,-2,-2},
               {-2,-2,-2,-2,-2,-2,-2,-2,-2,-2},
               {-2,-2,-2,-2,-2,-2,-2,-2,-5,-2},
               {-2,-2,-1,-1,-1,-1,-2,-2,-2,-2},
               {-2,-2,-2,-2,-2,-2,-2,-2,-2,-2},
               {-2,-2,-2,-2,-2,-2,-2,-2,-2,-2},
               {-2,-2,-2,-2,-2,-2,-1,-2,-2,-2},
               {-2,-4,-2,-2,-2,-2,-1,-2,-2,-2},
               {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
            };
        }

        public static void DrawMap(Graphics g)
        {
            mapObjects = new List<MapEntity>();
            mapObjects1 = new List<MapEntity>();
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if(map[i,j] == -1)
                    {
                        SolidBrush blueBrush = new SolidBrush(Color.Black);
                        Rectangle rect = new Rectangle(j * 60, i * 60, 60, 60);
                        MapEntity mapEntity = new MapEntity(new Point(j * size, i *size), new Size(size, size ));
                        mapObjects.Add(mapEntity);
                      
                        g.FillRectangle(blueBrush,rect);
                    }
                    if(map[i,j] == -5)
                    {
                        SolidBrush blueBrush = new SolidBrush(Color.Yellow);
                        Rectangle rect = new Rectangle(j * 60, i * 60, 60, 60);
                        MapEntity mapEntity = new MapEntity(new Point(j * size, i * size), new Size(size, size));
                        mapObjects1.Add(mapEntity);
                       
                        g.FillRectangle(blueBrush, rect);
                    }
                }
            }
        }
    }
}
