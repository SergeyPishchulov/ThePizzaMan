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
        public CreatureAnimation creature;


        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 40;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnKeyDown);
            KeyUp += new KeyEventHandler(OnKeyUp);

            Init();
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            creature.offset = new Vector(0, 0);
            creature.IsMoving = false;
            creature.SetAnimation(0);
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    creature.offset = new Vector(0, -1);
                    creature.IsMoving = true;
                    creature.SetAnimation(0);
                    break;

                case Keys.S:
                    creature.offset = new Vector(0, 1);
                    creature.IsMoving = true;
                    creature.SetAnimation(0);
                    break;

                case Keys.A:
                    creature.offset = new Vector(-1, 0);
                    creature.IsMoving = true;
                    creature.Flip = -1;
                    creature.SetAnimation(0);
                    break;

                case Keys.D:
                    creature.offset = new Vector(1, 0);
                    creature.IsMoving = true;
                    creature.Flip = 1;
                    creature.SetAnimation(0);
                    break;

                case Keys.Space:
                    creature.offset = new Vector(0, 0);
                    creature.IsMoving = false;
                    creature.SetAnimation(2);
                    break;
            }
        }

        public void Init()
        {
            creatureImage = new Bitmap(
                Path.Combine(new DirectoryInfo(
                    Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Pizza1.png"));

            creature = new CreatureAnimation(new Player(new Vector(200, 500)),
                Frames.IdleFrames,
                Frames.RunFrames,
                Frames.AttackFrames,
                Frames.DeathFrames, creatureImage);
            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            if (creature.IsMoving)
                creature.Creature.Move(creature.offset);

            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            creature.PlayAnimation(g);
        }
    }
}
