using System;
using System.Drawing;

namespace GameNoGame
{
    public class Player : Rectangle, ICreature
    {
        //public Vector Location { get; set; }
        //public Size Size { get; set; }
        public int Health { get; }

        public CreatureState State;

        public Player(Vector location, Size size) : base(location, size)
        {
            Location = location;
            Health = 100;
            Size = size;
            State = 0;
        }        

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}
