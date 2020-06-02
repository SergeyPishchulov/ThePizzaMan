using System;
using System.Drawing;

namespace GameNoGame
{
    public class Monster : Rectangle, ICreature
    {
        public int Health { get; }
        public Vector Velocity { get; set; } = Vector.Zero;
        public Monster(Vector location, Size size=default ) : base(location, size)
        {
            LeftTopLocation = location;
            Health = 100;
            Size = new Size(64, 64);
        }

        public Vector SearchPlayer(Player player)
        {
            return Vector.Zero;
        }

        public bool IsAlive() => Health > 0;
    }
}
