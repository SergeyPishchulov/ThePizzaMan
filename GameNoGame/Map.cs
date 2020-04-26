using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNoGame
{
    public class Map
    {    
        public List<Rectangle> MapObjects { get; private set; }

        public Map(List<Rectangle> mapObjects)
        {
            MapObjects = mapObjects;
        }


        public bool CanMove(ICreature mover, Vector movement)
        {
            var destination = new Rectangle(mover.LeftTopLocation + movement, mover.Size);

            var res=MapObjects
                .Where(o => !(o is ICreature)) //умеет ходить только сквозь ICreature
                .Select(r => Rectangle.AreIntersected(r, destination))
                .All(i => i == false);

            return res;
        }        
    }    
}
