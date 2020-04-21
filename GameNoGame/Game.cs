using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameNoGame
{
    public class Game
    {
        public Player Player;
        public Map Map;
        public int Scores;
        public GameStage Stage { get; private set; } = GameStage.NotStarted;
        public event Action<GameStage> StageChanged;

        public Game(Map map, Player player)
        {
            Map = map;
            Player = player;
        }

        public void Start(Map map /*или название карты*/)
        {
            // каким-то образом создание карты
            ChangeStage(GameStage.Setup);
        }

        private void ChangeStage(GameStage stage)
        {
            Stage = stage;
            StageChanged?.Invoke(stage); //Вызов события StageChanged
        }

        public void Move(ICreature mover, Vector movement)
        {
            if (Map.CanMove(mover, movement))
                mover.Location += movement;
        }

        public void Jump(ICreature mover)
        {
            if (!Map.CanMove(mover, new Vector(0, 1)) //игрок стоит на поверхности
                && Map.CanMove(mover, new Vector(0, -2 * mover.Size.Height))) // над ним нет препятсвий
            {
                FeelGravity(mover, new Vector(0, 5));
            }
        }

        public void MakeGravity()
        {
            //Map.MapObjects.Where()
            foreach (var o in Map.MapObjects)
            {
                if (o is ICreature)
                    FeelGravity((ICreature)o, Vector.Zero);
            }
        }

        public void FeelGravity(ICreature mover, Vector startVelocity)
        {
            var startTime = DateTime.Now;
            var dTime = DateTime.Now;
            var velocity = startVelocity;
            var g = 10;

            if (velocity != Vector.Zero)
            {
                while (velocity.Y > 0 && Map.CanMove(mover, new Vector(0, 10)))
                {
                    var tFromStart = (int)((DateTime.Now - startTime).TotalSeconds / 10);
                    velocity = new Vector(velocity.X, velocity.Y - g * tFromStart);
                    FeelMomentGravity(mover, tFromStart, g);
                }
            }

            startTime = DateTime.Now;
            while (Map.CanMove(mover, new Vector(0, -10)))
            {
                var tFromStart = (int)((DateTime.Now - startTime).TotalSeconds / 10);
                velocity = new Vector(velocity.X, velocity.Y + g * tFromStart);
                FeelMomentGravity(mover, tFromStart, -1 * g);
            }
            var a = 10;
        }

        public void FeelMomentGravity(ICreature mover, int tFromStart, int g)
        {
            var dy = g * tFromStart;
            Move(mover, new Vector(0, dy));
            Thread.Sleep(10);
        }


        /* методы игрока: Walk, Run, Jump, ShotRope */
    }
}
