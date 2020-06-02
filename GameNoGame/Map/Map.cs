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
        public List<Rectangle> MapObjects { get; private set; }        

        public Map(int levelNumber, Player player, Monster monster) 
        {
            MapObjects = InitMap(levelNumber, player, monster);
        }

        public Map(List<Rectangle> mapObjects)
        {
            MapObjects = mapObjects;
        }

        public bool CanMove(ICreature mover, Vector movement)
        {
            var destination = new Rectangle(mover.LeftTopLocation + movement, mover.Size);

            var res = MapObjects
                .Where(o => !(o is ICreature)) //умеет ходить только сквозь ICreature
                .Select(r => Rectangle.AreIntersected(r, destination))
                .All(i => i == false);

            return res;
        }

        public bool CanMove(Rectangle mover, Vector movement)
        {
            var destination = new Rectangle(mover.LeftTopLocation + movement, mover.Size);

            var res = MapObjects
                .Where(o => !(o is ICreature)) //умеет ходить только сквозь ICreature
                .Select(r => Rectangle.AreIntersected(r, destination))
                .All(i => i == false);

            return res;
        }

        public bool CanExist(Rectangle rect)
        {
            return CanMove(rect, new Vector(0, 0));
        }

        //public bool CanMovePartly(ICreature mover, Vector movement)
        //{
        //    var part = 0.01*movement ;
        //    var destination = new Rectangle(mover.LeftTopLocation + movement, mover.Size);
        //}

        public bool IsInPlatform(Vector point)
        {
            var destination = new Rectangle(point, new Size(1, 1));
            return MapObjects
                .Where(o => !(o is ICreature))
                .Any(i => Rectangle.AreIntersected(i, destination));
        }       
    }
}
