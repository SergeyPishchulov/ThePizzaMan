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

        public bool IntersectWithMapObj(Rectangle moover)
        {
            foreach (var r in MapObjects)
            {
                if (Rectangle.AreIntersected(r, moover))
                    return true;
            }
            return false;
        }

        
    }    
}
