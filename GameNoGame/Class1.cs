using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNoGame
{
    partial class Game
    {
        public void InitGame(int levelNumber)
        {
            if (levelNumber == 1)
            {
                Player = new Player(new Vector(250, 480), new Size(128, 128));
                Monster = new Monster(new Vector(0, 0), new Size(128, 128));
                var mapObjects = new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0, 700), new Size(1500, 300)),
                        new Rectangle(new Vector(700, 100), new Size(100, 100)),
                        new Rectangle(new Vector(0, 300), new Size(1500, 20)),
                        new Rectangle(new Vector(200, 20), new Size(100, 100)),
                        Player,
                        Monster
                    };
                Map = new Map(mapObjects);

            }
            else if (levelNumber == 2)
            {
                Player = new Player(new Vector(250, 480), new Size(128, 128));
                Monster = new Monster(new Vector(0, 0), new Size(128, 128));
                var mapObjects = new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0, 700), new Size(2000, 300)),

                        new Rectangle(new Vector(900, 300), new Size(100, 10)),
                        new Rectangle(new Vector(700, 400), new Size(100, 10)),
                        new Rectangle(new Vector(500, 500), new Size(100, 10)),

                        new Rectangle(new Vector(1100, 400), new Size(250, 340)),

                        new Rectangle(new Vector(200, 10), new Size(1000, 10)),
                        Player,
                        Monster
                    };
                Map = new Map(mapObjects);
            }
            else if (levelNumber == 3)
            {
                Player = new Player(new Vector(250, 480), new Size(128, 128));
                Monster = new Monster(new Vector(0, 0), new Size(128, 128));
                var mapObjects = new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0, 700), new Size(500, 300)),
                        new Rectangle(new Vector(900, 700), new Size(1000, 300)),
                        new Rectangle(new Vector(500, 100), new Size(400, 30)),
                        Player,
                        Monster
                    };
                Map = new Map(mapObjects);
            }

            else if (levelNumber == 4)
            {
                Player = new Player(new Vector(250, 480), new Size(128, 128));
                Monster = new Monster(new Vector(0, 0), new Size(128, 128));
                var mapObjects = new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0, 700), new Size(500, 300)),
                        new Rectangle(new Vector(900, 700), new Size(1000, 300)),
                        new Rectangle(new Vector(500, 100), new Size(400, 30)),
                        Player,
                        Monster
                    };
                Map = new Map(mapObjects);
            }
            else
                throw new Exception();
        }
    }
}
