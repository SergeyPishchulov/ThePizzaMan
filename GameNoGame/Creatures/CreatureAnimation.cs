using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNoGame
{
    public class CreatureAnimation
    {
        public bool IsMoving;
        public ICreature Creature;

        public int Flip;
        public Vector offset;
        public int dx;
        public int dy;

        public int IdleFrames;
        public int RunFrames;
        public int AttackFrames;
        public int DeathFrames;

        public int CurrentFrame;
        public int CurrentAnimation;
        public int CurrentLimit;

        public Image Image;

        public CreatureAnimation(ICreature creature, int idle, int run, int attack, int death, Image image)
        {
            Creature = creature;

            IdleFrames = idle;
            RunFrames = run;
            AttackFrames = attack;
            DeathFrames = death;

            Image = image;

            Flip = 1;

            CurrentFrame = 0;
            CurrentAnimation = 0;
            CurrentLimit = idle;
        }

        public void SetAnimation(int currentAnimation)
        {
            CurrentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    CurrentLimit = IdleFrames;
                    break;
                case 1:
                    CurrentLimit = RunFrames;
                    break;
                case 2:
                    CurrentLimit = AttackFrames;
                    break;
                case 3:
                    CurrentLimit = DeathFrames;
                    break;
            }
        }

        public void PlayAnimation(Graphics g)
        {
            g.DrawImage(Image, 
                new System.Drawing.Rectangle(
                    new Point(Creature.Location.X - Flip * Creature.Size.Width / 2, Creature.Location.Y),
                    new Size(Flip * Creature.Size.Width, Creature.Size.Height)),
                    128 * CurrentFrame, 128 * CurrentAnimation, Creature.Size.Width, Creature.Size.Height,
                    GraphicsUnit.Pixel);

            if (CurrentFrame < CurrentLimit - 1)
                CurrentFrame++;
            else CurrentFrame = 0;
        }
    }
}
