using System;
using System.Drawing;

namespace GameNoGame
{
    public class Player : Rectangle, ICreature
    {
        public int Health { get; }

        public Vector Velocity { get; set; }
        public Vector RopeVelocity;
        public Vector HookFixation;

        public CreatureState State;

        public Player(Vector location, Size size) : base(location, size)
        {
            LeftTopLocation = location;
            Health = 100;
            Size = size;
            State = 0;
            RopeVelocity = Vector.Zero;
            HookFixation = Vector.Zero;
            Velocity = Vector.Zero;
        }

        public bool IsAlive() => Health > 0;
    }
}
