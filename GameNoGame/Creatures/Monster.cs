using System;
using System.Drawing;

namespace GameNoGame
{
    public class Monster : Rectangle, ICreature
    {
        public int Health { get; }

        public CreatureState State;

        public Monster(Vector location, Size size=default ) : base(location, size)
        {
            LeftTopLocation = location;

            Health = 100;
            Size = new Size(128, 128);
            State = 0;
        }

        public Vector SearchPlayer()
        {
            return Vector.Zero;
        }

        public bool IsAlive() => Health > 0;
    }
}
