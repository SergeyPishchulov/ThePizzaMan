using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNoGame
{
    public class Rectangle 
    {
        public Vector Location { get; set; }
        public Size Size { get; set; }

        public Rectangle(Vector location, Size size)
        {
            Location = location;
            Size = size;
        }

    }
}
