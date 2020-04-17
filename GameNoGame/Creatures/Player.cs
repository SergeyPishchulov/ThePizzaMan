using System;
using System.Drawing;

namespace GameNoGame
{
    public class Player : Rectangle, ICreature
    {
        public Vector Location { get; set; }
        public Size Size { get; }
        public int Health { get; }

        public CreatureState State;

        public Player(Vector location, Size size = default) : base(location, size)
        {
            Location = location;
            Health = 100;
            Size = new Size(128, 128);
            State = 0;
        }        

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}
