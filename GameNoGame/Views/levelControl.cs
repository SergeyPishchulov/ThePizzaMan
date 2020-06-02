using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameNoGame
{
    public partial class LevelControl : UserControl
    {
        public InterfaceManager interfaceManager;

        private Image playerImage;
        public CreatureAnimation playerAnimation;
        public Player player;
        public Image monsterImage;
        public CreatureAnimation monsterAnimation;
        public Monster monster;
        private Game game;
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
        }

        public void Configure(InterfaceManager interfaceManager)
        {
            this.interfaceManager = interfaceManager;
            timer.Start();
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
                if (player.HookFixation == Vector.Zero && game.Map.IsInPlatform(hookFixation) &&
                    hookFixation.Y < player.LeftTopLocation.Y)
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
            game = new Game(levelNumber);

            playerImage = Image.FromFile("Sprites\\Pizza2.png");
            monsterImage = Image.FromFile("Sprites\\Monster1.png");

            playerAnimation = new CreatureAnimation(
                game.Player,
                Frames.IdleFrames, Frames.RunFrames, Frames.JumpFrames, Frames.DeathFrames,
                playerImage);
            player = (Player)playerAnimation.Creature;

            monsterAnimation = new CreatureAnimation(
                game.Monster,
                Frames.IdleFrames, Frames.RunFrames, Frames.JumpFrames, Frames.DeathFrames,
                monsterImage);
            monster = (Monster)monsterAnimation.Creature;
        }

        private void Update(object sender, EventArgs e)
        {
            if (game.Finished)
            {
                interfaceManager.ChooseMap();
                timer.Stop();
            }

            game.OnTick(playerAnimation.MoveOffset, playerAnimation.IsJumping, player.HookFixation);
            Invalidate();

        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            playerAnimation.PlayAnimation(g);
            monsterAnimation.PlayAnimation(g);

            game.Map.DrawMap(g, levelNumber);
            g.DrawString($"{levelNumber}", new Font("Arial", 16),
                                new SolidBrush(Color.Black), new PointF(1400, 3));
            g.DrawString($"Health: {player.Health}", new Font("Arial", 16, FontStyle.Bold),
                                new SolidBrush(Color.Black), new PointF(3, 25));
            g.DrawString($"Scores: {game.Scores}", new Font("Arial", 16, FontStyle.Bold),
                                new SolidBrush(Color.Black), new PointF(3, 48));
            g.DrawString("Finish", new Font("Arial", 16, FontStyle.Bold),
                                new SolidBrush(Color.Black), new PointF(1300, 50));
        }
    }
}
