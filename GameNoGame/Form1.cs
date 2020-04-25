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

        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 30;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnKeyDown);
            KeyUp += new KeyEventHandler(OnKeyUp);

            Init();
        }
         
        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            animation.offset = new Vector(0, 0);
            animation.IsMoving = false;
            animation.SetAnimation(0);
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    animation.offset = new Vector(-10, 0);
                    animation.IsMoving = true;
                    animation.Flip = -1;
                    animation.SetAnimation(0);
                    break;

                case Keys.D:
                    animation.offset = new Vector(10, 0);
                    animation.IsMoving = true;
                    animation.Flip = 1;
                    animation.SetAnimation(0);
                    break;

                case Keys.Space:
                    animation.offset = new Vector(0, -30);
                    animation.IsJumping = true;
                    animation.SetAnimation(0);
                    break;
            }
        }

        public void Init()
        {
            creatureImage = new Bitmap(
                Path.Combine(new DirectoryInfo(
                    Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Sprites\\Pizza1.png"));

            animation = new CreatureAnimation(new Player(new Vector(100, 480), new Size(128, 128)),
                Frames.IdleFrames,
                Frames.RunFrames,
                Frames.AttackFrames,
                Frames.DeathFrames, creatureImage);

            game = new Game(new Map(new List<Rectangle>() {
                new Rectangle(new Vector(150, 700), new Size(1500, 300)),
                new Rectangle(new Vector(1600, 700), new Size(1000, 300)),
                new Rectangle(new Vector(600, 400), new Size(220, 340)),
                (Player)animation.Creature
            }), (Player)animation.Creature);

            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            if (animation.IsMoving)
                game.Move(animation.Creature, animation.offset);

            if (animation.IsJumping)
                game.Jump(animation.Creature, animation.offset);

            game.Move(animation.Creature, gratity);

            Invalidate();
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
        }
    }
}
