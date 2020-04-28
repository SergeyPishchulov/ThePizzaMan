using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameNoGame
{
    public partial class Form1 : Form
    {
        public Image playerImage;
        public CreatureAnimation playerAnimation;

        public Image monsterImage;
        public CreatureAnimation monsterAnimation;

        public Game game;
        public int levelNumber;
        public Vector gratity = new Vector(0, 10);
        public List<System.Drawing.Rectangle> FormObjects { get; private set; }

        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 10;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnKeyDown);
            KeyUp += new KeyEventHandler(OnKeyUp);
            MouseClick += new MouseEventHandler(OnClick);
            
            Init();
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
                if (playerAnimation.HookFixation == Vector.Zero && game.Map.IsInPlatform(hookFixation))
                {
                    playerAnimation.HookFixation = hookFixation;
                    playerAnimation.SetAnimation(3);
                }
                else
                {
                    playerAnimation.HookFixation = Vector.Zero;
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
            playerImage = new Bitmap(Path.Combine(new DirectoryInfo(
                    Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Sprites\\Pizza1.png"));

            monsterImage = new Bitmap(Path.Combine(new DirectoryInfo(
                    Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Sprites\\Monster1.png"));

            playerAnimation = new CreatureAnimation(
                new Player(new Vector(250, 480), new Size(128, 128)),
                Frames.IdleFrames, Frames.RunFrames, Frames.JumpFrames, Frames.DeathFrames,
                playerImage);

            monsterAnimation = new CreatureAnimation(
                new Monster(new Vector(0, 0), new Size(128, 128)),
                Frames.IdleFrames, Frames.RunFrames, Frames.JumpFrames, Frames.DeathFrames,
                monsterImage);

            levelNumber = 1;
            game = new Game(new Map(levelNumber,
                (Player)playerAnimation.Creature,
                (Monster)monsterAnimation.Creature), (Player)playerAnimation.Creature);

            timer1.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            game.OnTick(playerAnimation.MoveOffset,
                        playerAnimation.IsJumping,
                        playerAnimation.HookFixation);

            game.Move(monsterAnimation.Creature, gratity);
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            playerAnimation.PlayAnimation(g);
            monsterAnimation.PlayAnimation(g);
            game.Map.DrawMap(g, levelNumber);
        }
    }
}