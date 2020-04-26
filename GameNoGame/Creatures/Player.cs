using System;
using System.Drawing;

namespace GameNoGame
{
    public class Player : Rectangle, ICreature
    {
        //public Vector Location { get; set; }
        //public Size Size { get; set; }
        public int Health { get; }

        public Vector Velocity { get; set; } = Vector.Zero;
        public int FlyingTime;

        public CreatureState State;

        public Player(Vector location, Size size) : base(location, size)
        {
            LeftTopLocation = location;
            Health = 100;
            Size = size;
            State = 0;
        }

        public bool IsAlive() => Health > 0;
    }
}
