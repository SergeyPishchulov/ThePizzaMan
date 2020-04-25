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

        public void Start()
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

        public void Jump(ICreature mover, Vector movement)
        {
            if (!Map.CanMove(mover, new Vector(0, 10)))
                Move(mover, movement);
        }
        
        /* методы игрока: Walk, Run, Jump, ShotRope */
    }
}
