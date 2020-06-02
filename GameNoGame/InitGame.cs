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
                Aim = new Rectangle(new Vector(1250,50), new Size(100,100));
                Aim.Aim = true;
                Player = new Player(new Vector(100, 660), new Size(64, 64));
                Monster = new Monster(new Vector(10, 10), new Size(64, 64));
                var mapObjects = new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0, 750), new Size(800, 300)),
                        new Rectangle(new Vector(1000, 750), new Size(800, 300)),
                        new Rectangle(new Vector(100, 100), new Size(200, 20)),
                        new Rectangle(new Vector(400, 100), new Size(600, 20)),
                        new Rectangle(new Vector(200, 250), new Size(200, 20)),
                        new Rectangle(new Vector(800, 300), new Size(100, 20)),
                        new Rectangle(new Vector(1000, 200), new Size(100, 20)),
                        new Rectangle(new Vector(0,0), new Size(2, 880)), // левый край
                        new Rectangle(new Vector(0,0), new Size(1440, 2)), // верхний край
                        new Rectangle(new Vector(1440 ,0), new Size(2, 880)), // правый край
                        new Rectangle(new Vector(1200, 600), new Size(1140, 20)),
                        new Rectangle(new Vector(100, 600), new Size(1000, 20)),
                        new Rectangle(new Vector(1300, 400), new Size(300, 20)),
                        new Rectangle(new Vector(0, 450), new Size(400, 20)),
                        new Rectangle(new Vector(500, 450), new Size(700, 20)),
                        new Rectangle(new Vector(1200, 150), new Size(300, 20)),
                        new Rectangle(new Vector(0, 100), new Size(100, 350)),

                        Aim,
                        Player,
                        Monster,
                    };
                Map = new Map(mapObjects);

            }
            else if (levelNumber == 2)
            {
                Player = new Player(new Vector(250, 480), new Size(64, 64));
                Monster = new Monster(new Vector(100, 480), new Size(64, 64));
                var mapObjects = new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0, 700), new Size(2000, 300)),

                        new Rectangle(new Vector(900, 300), new Size(100, 10)),
                        new Rectangle(new Vector(700, 400), new Size(100, 10)),
                        new Rectangle(new Vector(500, 500), new Size(100, 10)),

                        new Rectangle(new Vector(1100, 400), new Size(250, 340)),

                        new Rectangle(new Vector(200, 10), new Size(1000, 10)),
                        Player,
                        Monster,

                        new Rectangle(new Vector(0,0), new Size(1, 1024)), // левый край
                        new Rectangle(new Vector(0,0), new Size(1440, 1)), // верхний край
                        new Rectangle(new Vector(1440 ,0), new Size(1, 1024)), // правый край
                    };
                Map = new Map(mapObjects);
            }
            else if (levelNumber == 3)
            {
                Player = new Player(new Vector(250, 480), new Size(64, 64));
                Monster = new Monster(new Vector(100, 100), new Size(64, 64));
                var mapObjects = new List<Rectangle>()
                    {
                        new Rectangle(new Vector(0, 700), new Size(500, 300)),
                        new Rectangle(new Vector(900, 700), new Size(1000, 300)),
                        new Rectangle(new Vector(500, 100), new Size(400, 30)),
                        Player,
                        Monster,

                        new Rectangle(new Vector(0,0), new Size(1, 1024)), // левый край
                        new Rectangle(new Vector(0,0), new Size(1440, 1)), // верхний край
                        new Rectangle(new Vector(1440 ,0), new Size(1, 1024)), // правый край
                        new Rectangle(new Vector(0, 1280), new Size(1440, 10)) // нижний край
                    };
                Map = new Map(mapObjects);
            }

            else if (levelNumber == 4)
            {
                Player = new Player(new Vector(250, 480), new Size(64, 64));
                Monster = new Monster(new Vector(100, 100), new Size(64, 64));
                var mapObjects = new List<Rectangle>()
                    {
                        Player,
                        Monster,

                        new Rectangle(new Vector(0,0), new Size(1, 1024)), // левый край
                        new Rectangle(new Vector(0,0), new Size(1440, 1)), // верхний край
                        new Rectangle(new Vector(1440 ,0), new Size(1, 1024)), // правый край
                        new Rectangle(new Vector(0, 800), new Size(1440, 10)) // нижний край
                    };
                Map = new Map(mapObjects);
            }
            else
                throw new Exception();
        }
    }
}
