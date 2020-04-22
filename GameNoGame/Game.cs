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

        public void Start(Map map )
        {
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
                && Map.CanMove(mover, new Vector(0, 2 * mover.Size.Height))) // над ним нет препятсвий
                GoUp(mover);
        }

        public void MakeGravity()
        {
            foreach (var o in Map.MapObjects)
            {
                if (o is ICreature)
                    Fall((ICreature)o);
            }
        }

        public void GoUp(ICreature mover)
        {
            var startTime = DateTime.Now;
            var g= 10;
            var velocity = Vector.Zero;
            while (Map.CanMove(mover, new Vector(0, 10)) && velocity.Y > 0)
            {
                var tFromStart = (int)((DateTime.Now - startTime).TotalSeconds / 10);
                velocity = new Vector(0, g * tFromStart);
                Move(mover, new Vector(0, g * tFromStart));
                Thread.Sleep(10);
            }
        }

        public void Fall(ICreature mover)
        {
            var startTime = DateTime.Now;
            var g = -10;
            while (Map.CanMove(mover, new Vector(0, -10)) )
            {
                var tFromStart = (int)((DateTime.Now - startTime).TotalSeconds / 10);
                Move(mover, new Vector(0, g * tFromStart));
                Thread.Sleep(10);
            }         
        }
    }
}
