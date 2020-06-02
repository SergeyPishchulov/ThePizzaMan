using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNoGame
{
    public class Food : Rectangle
    {
        public Food(Vector location, Size size) : base(location, size)
        {
            LeftTopLocation = location;
            Size = size;
        }

    }
}
