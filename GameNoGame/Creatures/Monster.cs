using System;
using System.Drawing;

namespace GameNoGame
{
    public class Monster : ICreature
    {
        public Vector Location { get; set; }
        public Size Size { get; }
        public int Health { get; }

        public CreatureState State;

        public Monster(Vector location)
        {
            Location = location;
            Health = 100;
            Size = new Size(128, 128);
            State = 0;
        }

        public Vector SearchPlayer()
        {
            return Vector.Zero;
        }

        public void Move(Vector movement)
        {
            /* исходя от нахождения игрока */
        }

        public bool CanMove(Vector location)
        {
            return true;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}
