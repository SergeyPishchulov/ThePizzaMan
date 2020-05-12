using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameNoGame
{
    public partial class LevelControl : UserControl
    {
        public InterfaceManager interfaceManager;

        public Image playerImage;
        public CreatureAnimation playerAnimation;
        public Player player;
        public Image monsterImage;
        public CreatureAnimation monsterAnimation;
        public Monster monster;
        public Game game;
        public int levelNumber;

        public List<System.Drawing.Rectangle> FormObjects { get; private set; }

        public LevelControl()
        {
            InitializeComponent();

            timer.Interval = 10;
            timer.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnKeyDown);
            KeyUp += new KeyEventHandler(OnKeyUp);
            MouseClick += new MouseEventHandler(OnClick);
            //Init();

        }

        public void Configure(InterfaceManager interfaceManager)
        {
            if (this.interfaceManager != null)
                return;

            this.interfaceManager = interfaceManager;
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            playerAnimation.MoveOffset = Vector.Zero;
            playerAnimation.IsMoving = false;
            playerAnimation.IsJumping = false;
            playerAnimation.SetAnimation(0);
        }

        public void OnClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var hookFixation = new Vector(e.Location.X, e.Location.Y);
                if (player.HookFixation == Vector.Zero && game.Map.IsInPlatform(hookFixation))
                {
                    player.HookFixation = hookFixation;
                    playerAnimation.SetAnimation(3);
                }
                else
                {
                    player.HookFixation = Vector.Zero;
                    playerAnimation.SetAnimation(0);
                }
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.R:
                    Init();
                    break;

                case Keys.A:
                    playerAnimation.MoveOffset = new Vector(-1, 0);
                    playerAnimation.IsMoving = true;
                    playerAnimation.Flip = -1;
                    playerAnimation.SetAnimation(1);
                    break;

                case Keys.D:
                    playerAnimation.MoveOffset = new Vector(1, 0);
                    playerAnimation.IsMoving = true;
                    playerAnimation.Flip = 1;
                    playerAnimation.SetAnimation(1);
                    break;

                case Keys.Space:
                    playerAnimation.IsJumping = true;
                    playerAnimation.SetAnimation(2);
                    break;
            }
        }

        public void Init()
        {
            playerImage = Properties.Resources.Pizza1;
            monsterImage = Properties.Resources.Monster1;

            playerAnimation = new CreatureAnimation(
                new Player(new Vector(250, 480), new Size(128, 128)),
                Frames.IdleFrames, Frames.RunFrames, Frames.JumpFrames, Frames.DeathFrames,
                playerImage);
            player = (Player)playerAnimation.Creature;

            monsterAnimation = new CreatureAnimation(
                new Monster(new Vector(0, 0), new Size(128, 128)),
                Frames.IdleFrames, Frames.RunFrames, Frames.JumpFrames, Frames.DeathFrames,
                monsterImage);
            monster = (Monster)monsterAnimation.Creature;

            //levelNumber = 2;
            game = new Game(new Map(levelNumber, player, monster), player, monster);

            timer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            game.OnTick(playerAnimation.MoveOffset, playerAnimation.IsJumping, player.HookFixation);
            Invalidate();
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            playerAnimation.PlayAnimation(g);
            monsterAnimation.PlayAnimation(g);

            game.Map.DrawMap(g, levelNumber);
            g.DrawString($"Номер карты: {levelNumber}", new Font("Arial", 16),
                                new SolidBrush(Color.Black), new PointF(3, 3));
            g.DrawString($"Health: {player.Health}", new Font("Arial", 16, FontStyle.Bold),
                                new SolidBrush(Color.Black), new PointF(3, 25));
        }
    }
}
