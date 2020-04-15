using System;
using System.Drawing;

namespace GameNoGame
{
    public class Player : ICreature
    {
        public Vector Location { get; set; }
        public Size Size { get; }
        public int Health { get; }

        public CreatureState State;

        public Player(Vector location)
        {
            Location = location;
            Health = 100;
            Size = new Size(128, 128);
            State = 0;
        }

        public void Move(Vector movement)
        {
            Location += movement;   
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public bool CanMove(Vector location)
        {
            return true;

            /*
             * ѕереносим на точку location пр€моугольник Player'a, 
             * сравниваем пересечение этого пр€моугольника
             * с пр€моугольником объекта на карте
             * если пересекаетс€ Ч false, 
             * если нет Ч true
             */
        }
        
    }
}
