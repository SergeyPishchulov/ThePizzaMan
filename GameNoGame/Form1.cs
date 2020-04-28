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
        public Image creatureImage;
        public CreatureAnimation animation;
        public Game game;
        public Vector gratity = new Vector(0, 10);
        private bool Space;

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
            animation.MoveOffset = Vector.Zero;
            //animation.JumpOffset = Vector.Zero;

            animation.IsMoving = false;
            animation.IsJumping = false;
            animation.SetAnimation(0);
        }

        public void OnClick(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Left)
            {
                var hookFixation = new Vector(e.Location.X, e.Location.Y);
                if (animation.HookFixation == Vector.Zero && game.Map.IsInPlatform(hookFixation))
                    animation.HookFixation = hookFixation;
                else
                    animation.HookFixation = Vector.Zero;
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                animation.MoveOffset = new Vector(-1, 0);
                animation.IsMoving = true;
                animation.Flip = -1;
                animation.SetAnimation(0);
            }

            if (e.KeyCode == Keys.D)
            {
                animation.MoveOffset = new Vector(1, 0);
                animation.IsMoving = true;
                animation.Flip = 1;
                animation.SetAnimation(0);
            }

            if (e.KeyCode == Keys.Space)
            {
                //animation.JumpOffset = new Vector(0, -30);
                animation.IsJumping = true;
                animation.SetAnimation(0);
            }
        }


        public void Init()
        {
            creatureImage = new Bitmap(
                Path.Combine(new DirectoryInfo(
                    Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Sprites\\Pizza1.png"));

            animation = new CreatureAnimation(new Player(new Vector(250, 480), new Size(128, 128)),
                Frames.IdleFrames,
                Frames.RunFrames,
                Frames.AttackFrames,
                Frames.DeathFrames, creatureImage);

            game = new Game(new Map(new List<Rectangle>() {
                new Rectangle(new Vector(0, 700), new Size(1500, 300)),
                new Rectangle(new Vector(700, 100), new Size(100, 100)),
                new Rectangle(new Vector(0, 300), new Size(1500,20)),
                new Rectangle(new Vector(200, 20), new Size(100,100)),
                (Player)animation.Creature
            }), (Player)animation.Creature);

            timer1.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            //if (animation.IsMoving)
            //    game.Move(animation.Creature, animation.MoveOffset);

            //if (animation.IsJumping)
            //    game.Jump(animation.Creature, animation.JumpOffset);

            //game.Move(animation.Creature, gratity);
            game.OnTick(animation.MoveOffset, animation.IsJumping, animation.HookFixation);
            Invalidate();
            //animation.MoveOffset = Vector.Zero;
            //animation.JumpOffset = Vector.Zero;
        }


        private void OnPaint(object sender, PaintEventArgs e)
        {
            var rectangle1 = new System.Drawing.Rectangle(
                game.Map.MapObjects[0].LeftTopLocation.X,
                game.Map.MapObjects[0].LeftTopLocation.Y,
                game.Map.MapObjects[0].Size.Width, game.Map.MapObjects[0].Size.Height);

            var rectangle2 = new System.Drawing.Rectangle(
                game.Map.MapObjects[1].LeftTopLocation.X,
                game.Map.MapObjects[1].LeftTopLocation.Y,
                game.Map.MapObjects[1].Size.Width, game.Map.MapObjects[1].Size.Height);

            var rectangle3 = new System.Drawing.Rectangle(
                game.Map.MapObjects[2].LeftTopLocation.X,
                game.Map.MapObjects[2].LeftTopLocation.Y,
                game.Map.MapObjects[2].Size.Width, game.Map.MapObjects[2].Size.Height);

            var rectangle4 = new System.Drawing.Rectangle(
                game.Map.MapObjects[3].LeftTopLocation.X,
                game.Map.MapObjects[3].LeftTopLocation.Y,
                game.Map.MapObjects[3].Size.Width, game.Map.MapObjects[3].Size.Height);


            Graphics g = e.Graphics;
            animation.PlayAnimation(g);

            g.DrawImage(new Bitmap(
            Path.Combine(new DirectoryInfo(
                    Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Sprites\\Platform.png")), rectangle1);

            g.DrawImage(new Bitmap(
            Path.Combine(new DirectoryInfo(
                    Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Sprites\\Platform.png")), rectangle2);

            g.DrawImage(new Bitmap(
            Path.Combine(new DirectoryInfo(
                    Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Sprites\\OneBuilding.png")), rectangle3);

            g.DrawImage(new Bitmap(
            Path.Combine(new DirectoryInfo(
                    Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Sprites\\OneBuilding.png")), rectangle4);
        }
    }
}