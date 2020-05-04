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
        public Monster Monster;
        public Map Map;
        public int Scores;
        public Vector GravityForce = new Vector(0, 10);
        public GameStage Stage { get; private set; } = GameStage.NotStarted;
        public event Action<GameStage> StageChanged;

        public Game(Map map, Player player, Monster monster)
        {
            Map = map;
            Player = player;
            Monster = monster;
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

        public void OnTick(Vector moveOffset, bool isNeedJump, Vector hookFixation)
        {
            if (hookFixation != Vector.Zero)
                MoveInRope(hookFixation);
            else
                MoveOnGround(moveOffset, isNeedJump);
        }

        private void MoveInRope(Vector hookFixation)
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

        private void MoveOnGround(Vector moveOffset, bool isNeedJump)
        {
            Player.RopeVelocity = Vector.Zero;
            Move(Player, 30 * moveOffset); //по X
            if (isNeedJump && StayOnGround(Player))
                Jump(Player);
            Move(Player, Player.Velocity);
            Move(Monster, Monster.Velocity);
            if (StayOnGround(Player)) Player.Velocity = new Vector(Player.Velocity.X, 0);
            if (HitTheRoof(Player)) Player.Velocity = new Vector(Player.Velocity.X, 10);
        }

        public void Gravity()
        {
            Player.Velocity += GravityForce;
            Monster.Velocity = GravityForce;
        }

        private void Move(ICreature mover, Vector movement)
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

        private void MoveMuchCloseAsCan(ICreature mover, Vector movement)
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

        private bool StayOnGround(ICreature mover) => !Map.CanMove(mover, new Vector(0, 10));
        private bool HitTheRoof(ICreature mover) => !Map.CanMove(mover, new Vector(0, -1));

        private void Jump(ICreature mover)
        {
            Player.Velocity += new Vector(0, -70);
        }

        /* методы игрока: Walk, Run, Jump, ShotRope */
    }
}
