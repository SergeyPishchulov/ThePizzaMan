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

        public void OnTick(Vector MoveOffset, bool needJump)
        {
            Move(Player, 10 * MoveOffset); //по X
            if (needJump && StayOnGround(Player))
                Jump(Player);
            Player.Velocity += new Vector(0, 10);//gravity
            Move(Player, Player.Velocity);
            if (StayOnGround(Player)) Player.Velocity = new Vector(Player.Velocity.X, 0);
        }

        

        public void Move(ICreature mover, Vector movement)
        {
            if (Map.CanMove(mover, movement))
                mover.LeftTopLocation += movement;
            else
            {
                var part =new Vector(movement.X/10, movement.Y/10);
                for (var i = 0; i < 10; i++)
                    Move(mover, part);
            }
        }

        public bool StayOnGround(ICreature mover) => !Map.CanMove(mover, new Vector(0, 10));

        public void Jump(ICreature mover)
        {
            Player.Velocity += new Vector(0, -70); 
        }

        /* методы игрока: Walk, Run, Jump, ShotRope */
    }
}
