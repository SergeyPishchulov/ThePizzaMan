using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        /* методы игрока: Walk, Run, Jump, ShotRope */
    }
}
