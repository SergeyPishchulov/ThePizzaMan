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
        public Size Size { get; set; }

        public Vector LeftTopLocation { get; set; }

        public bool Aim = false;

        public Rectangle(Vector leftTopLocation, Size size)
        {
            //Location = location;
            LeftTopLocation = leftTopLocation;
            Size = size;
        }

        public System.Drawing.Rectangle Cast()
        {
            return new System.Drawing.Rectangle(
                LeftTopLocation.X,
                LeftTopLocation.Y,
                Size.Width,
                Size.Height);
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
            return (r.LeftTopLocation.X, r.LeftTopLocation.X + r.Size.Width - 1);
        }

        public static (int, int) GetYBorders(Rectangle r)
        {
            return (r.LeftTopLocation.Y, r.LeftTopLocation.Y + r.Size.Height - 1);
        }

        static bool ProjectionIntersect(int minA, int maxA, int minB, int maxB)
        {
            return (minA <= minB) && (maxA >= minB)
                || (minB <= minA) && (maxB >= minA);

            //return minA <= maxB && minB <= maxA;
        }

    }
}
