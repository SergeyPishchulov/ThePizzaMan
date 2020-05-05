using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameNoGame
{
    public partial class StartControl : UserControl
    {
        public Game game;

        public StartControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;

            startButton.Click += StartButton_Click;
            ExitButton.Click += ExitButton_Click;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            game.ChooseMap();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            game.Exit();
        }
    }
}
