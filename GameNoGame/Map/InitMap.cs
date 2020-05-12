using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNoGame
{
    public partial class Map
    {
        public List<Rectangle> InitMap(int levelNumber, Player player, Monster monster)
        {
            switch (levelNumber)
            {
               case 0:
                    return new List<Rectangle>() 
                    {
                        new Rectangle(new Vector(0, 700), new Size(1500, 300)),
                        new Rectangle(new Vector(700, 100), new Size(100, 100)),
                        new Rectangle(new Vector(0, 300), new Size(1500, 20)),
                        new Rectangle(new Vector(200, 20), new Size(100, 100)),
                        player,
                        monster
                    };

               case 1:
                    return new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0, 700), new Size(2000, 300)),

                        new Rectangle(new Vector(900, 300), new Size(100, 10)),
                        new Rectangle(new Vector(700, 400), new Size(100, 10)),
                        new Rectangle(new Vector(500, 500), new Size(100, 10)),

                        new Rectangle(new Vector(1100, 400), new Size(250, 340)),

                        new Rectangle(new Vector(200, 10), new Size(1000, 10)),
                        player,
                        monster
                    };

                case 2:
                    return new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0, 700), new Size(500, 300)),
                        new Rectangle(new Vector(900, 700), new Size(1000, 300)),
                        new Rectangle(new Vector(500, 100), new Size(400, 30)),
                        player,
                        monster
                    };

                default:
                    return new List<Rectangle>();
            }
        }

        public void DrawMap(Graphics g, int levelNumber)
        {
            switch (levelNumber)
            {
                case 0:
                    g.DrawImage(Properties.Resources.Platform, MapObjects[0].Cast());
                    g.DrawImage(Properties.Resources.Platform, MapObjects[1].Cast());
                    g.DrawImage(Properties.Resources.Platform, MapObjects[2].Cast());
                    g.DrawImage(Properties.Resources.OneBuilding, MapObjects[3].Cast());
                    break;

                case 1:
                    g.DrawImage(Properties.Resources.Platform, MapObjects[0].Cast());
                    g.DrawImage(Properties.Resources.Platform, MapObjects[1].Cast());
                    g.DrawImage(Properties.Resources.Platform, MapObjects[2].Cast());
                    g.DrawImage(Properties.Resources.Platform, MapObjects[3].Cast());
                    g.DrawImage(Properties.Resources.OneBuilding, MapObjects[4].Cast());
                    g.DrawImage(Properties.Resources.Platform, MapObjects[5].Cast());

                    break;

                case 2:
                    g.DrawImage(Properties.Resources.Platform, MapObjects[0].Cast());
                    g.DrawImage(Properties.Resources.Platform, MapObjects[1].Cast());
                    g.DrawImage(Properties.Resources.Platform, MapObjects[2].Cast());
                    break;

            }
        }
    }
}
