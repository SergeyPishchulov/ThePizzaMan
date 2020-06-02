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
               case 1:
                    return new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0, 700), new Size(1500, 300)),
                        new Rectangle(new Vector(700, 100), new Size(100, 100)),
                        new Rectangle(new Vector(0, 300), new Size(700, 20)),
                        new Rectangle(new Vector(200, 20), new Size(100, 100)),
                        player,
                        monster,

                        new Rectangle(new Vector(0,0), new Size(1, 1024)), // левый край
                        new Rectangle(new Vector(0,0), new Size(1440, 1)), // верхний край
                        new Rectangle(new Vector(1440 ,0), new Size(1, 1024)), // правый край
                        new Rectangle(new Vector(0, 1280), new Size(1440, 10)) // нижний край
                    };

               case 2:
                    return new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0, 700), new Size(2000, 300)),

                        new Rectangle(new Vector(900, 300), new Size(100, 10)),
                        new Rectangle(new Vector(700, 400), new Size(100, 10)),
                        new Rectangle(new Vector(500, 500), new Size(100, 10)),

                        new Rectangle(new Vector(1100, 400), new Size(250, 340)),

                        new Rectangle(new Vector(200, 10), new Size(1000, 10)),
                        player,
                        monster,

                        new Rectangle(new Vector(0,0), new Size(1, 1024)), // левый край
                        new Rectangle(new Vector(0,0), new Size(1440, 1)), // верхний край
                        new Rectangle(new Vector(1440 ,0), new Size(1, 1024)), // правый край
                        new Rectangle(new Vector(0, 1280), new Size(1440, 10)) // нижний край
                    };

                case 3:
                    return new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0, 700), new Size(500, 300)),
                        new Rectangle(new Vector(900, 700), new Size(1000, 300)),
                        new Rectangle(new Vector(500, 100), new Size(400, 30)),
                        player,
                        monster,

                        new Rectangle(new Vector(0,0), new Size(1, 1024)), // левый край
                        new Rectangle(new Vector(0,0), new Size(1440, 1)), // верхний край
                        new Rectangle(new Vector(1440 ,0), new Size(1, 1024)), // правый край
                        new Rectangle(new Vector(0, 1280), new Size(1440, 10)) // нижний край
                    };

                case 4:
                    return new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0,0), new Size(1, 1024)), // левый край
                        new Rectangle(new Vector(0,0), new Size(1440, 1)), // верхний край
                        new Rectangle(new Vector(1440 ,0), new Size(1, 1024)), // правый край
                        new Rectangle(new Vector(0, 1280), new Size(1440, 10)) // нижний край
                    };

                default:
                    return new List<Rectangle>();
            }
        }

        public void DrawMap(Graphics g, int levelNumber)
        {
            switch (levelNumber)
            {
                case 1:
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[0].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[1].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[2].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\OneBuilding.png"), MapObjects[3].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\OneBuilding.png"), MapObjects[4].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\OneBuilding.png"), MapObjects[5].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[6].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[7].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[8].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\OneBuilding.png"), MapObjects[9].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[10].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[11].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[12].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\OneBuilding.png"), MapObjects[13].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\OneBuilding.png"), MapObjects[14].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\OneBuilding.png"), MapObjects[15].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\OneBuilding.png"), MapObjects[16].Cast());
                    break;

                case 2:
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[0].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[1].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[2].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[3].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\OneBuilding.png"), MapObjects[4].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[5].Cast());
                    break;

                case 3:
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[0].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[1].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[2].Cast());
                    break;

                case 4:
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[2].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[3].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[4].Cast());
                    g.DrawImage(Image.FromFile("Sprites\\Platform.png"), MapObjects[5].Cast());
                    break;

            }
        }
    }
}
