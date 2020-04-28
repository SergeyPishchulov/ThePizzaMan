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

        public void OnTick(Vector MoveOffset, bool needJump, Vector hookFixation)
        {
            if (hookFixation != Vector.Zero)
            {
                if (Player.RopeVelocity == Vector.Zero)
                {
                    var c = 10;
                    var movementOnRope = 
                        hookFixation - new Vector(Player.Size.Width / 2, 0) - Player.LeftTopLocation;
                    Player.RopeVelocity = new Vector(movementOnRope.X / c, movementOnRope.Y / c);
                }
                if (Player.RopeVelocity != Vector.Zero)
                {
                    Move(Player, Player.RopeVelocity);
                    if (Map.CanMove(Player, Player.RopeVelocity))
                    {
                        Player.LeftTopLocation += Player.RopeVelocity;
                    }
                    else
                        Player.RopeVelocity = Vector.Zero;
                }
            }
            else
            {
                Player.RopeVelocity = Vector.Zero;
                Move(Player, 30 * MoveOffset); //по X
                if (needJump && StayOnGround(Player))
                    Jump(Player);
                Player.Velocity += new Vector(0, 10);//gravity

                Move(Player, Player.Velocity);
                if (StayOnGround(Player)) Player.Velocity = new Vector(Player.Velocity.X, 0);
                if (HitTheRoof(Player)) Player.Velocity = new Vector(Player.Velocity.X, 10);
            }
        }

        public void Move(ICreature mover, Vector movement)
        {
            if (Map.CanMove(mover, movement))
                mover.LeftTopLocation += movement;
            else
            {
                var part = new Vector(movement.X / 10, movement.Y / 10);
                for (var i = 0; i < 10; i++)
                    Move(mover, part);
            }
        }

        public void MoveMuchCloseAsCan(ICreature mover, Vector movement)
        {
            var dx = movement.X;
            var dy = movement.Y;
            for (var x = 1; x < dx; x++)
                if (Map.CanMove(mover, new Vector(1, 0)))
                    mover.LeftTopLocation += new Vector(1, 0);
                else
                    break;
            for (var y = 1; y < dy; y++)
                if (Map.CanMove(mover, new Vector(0, 1)))
                    mover.LeftTopLocation += new Vector(0, 1);
                else
                    break;
        }

        public bool StayOnGround(ICreature mover) => !Map.CanMove(mover, new Vector(0, 10));
        public bool HitTheRoof(ICreature mover) => !Map.CanMove(mover, new Vector(0, -1));
        public void Jump(ICreature mover)
        {
            Player.Velocity += new Vector(0, -70);
        }

        /* методы игрока: Walk, Run, Jump, ShotRope */
    }
}
