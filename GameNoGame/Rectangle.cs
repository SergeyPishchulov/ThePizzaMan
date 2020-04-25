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

        public Vector LeftTopLocation { get; set; }

        public Rectangle(Vector location, Size size)
        {
            Location = location;
            LeftTopLocation = new Vector(location.X - size.Width / 2,
                                         location.Y - size.Height / 2);
            Size = size;
        }

        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            var (r1Left, r1Right) = GetXBorders(r1);
            var (r2Left, r2Right) = GetXBorders(r2);
            var (r1Top, r1Bottom) = GetYBorders(r1);
            var (r2Top, r2Bottom) = GetYBorders(r2);

            return ProjectionIntersect(r1Left, r1Right, r2Left, r2Right)
                && ProjectionIntersect(r1Top, r1Bottom, r2Top, r2Bottom);
        }

        public static (int, int) GetXBorders(Rectangle r)
        {
            return (r.Location.X - r.Size.Width / 2, r.Location.X + r.Size.Width / 2);
        }

        public static (int, int) GetYBorders(Rectangle r)
        {
            return (r.Location.Y - r.Size.Height / 2, r.Location.Y + r.Size.Height / 2);
        }

        static bool ProjectionIntersect(int minA, int maxA, int minB, int maxB)
        {
            return (minA <= minB) && (maxA >= minB)
                || (minB <= minA) && (maxB >= minA);

            //return minA <= maxB && minB <= maxA;
        }

    }
}
