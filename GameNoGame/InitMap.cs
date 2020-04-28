using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNoGame
{
    public partial class Map
    {
        List<Rectangle> InitMap(int levelNumber, Player player)
        {
            switch (levelNumber)
            {
               case 0:
                    return new List<Rectangle>() {
                    new Rectangle(new Vector(0, 700), new Size(1500, 300)),
                    new Rectangle(new Vector(700, 100), new Size(100, 100)),
                    new Rectangle(new Vector(0, 300), new Size(1500, 20)),
                    new Rectangle(new Vector(200, 20), new Size(100, 100)),
                    player
                    };

               case 1:
                    return new List<Rectangle>() {
                    new Rectangle(new Vector(0, 700), new Size(1500, 300)),
                    new Rectangle(new Vector(700, 100), new Size(100, 100)),
                    new Rectangle(new Vector(0, 300), new Size(500, 20)),
                    new Rectangle(new Vector(200, 20), new Size(100, 100)),
                    player
                    };

                default:
                    return new List<Rectangle>();
            }
        }
    }
}
