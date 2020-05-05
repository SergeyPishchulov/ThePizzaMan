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
    public partial class ExitControl : UserControl
    {
        public Game game;

        public ExitControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;

            YESButton.Click += YESButton_Click;
            NOButton.Click += NOButton_Click;
        }

        private void YESButton_Click(object sender, EventArgs e)
        {
            game.CloseForm();
        }

        private void NOButton_Click(object sender, EventArgs e)
        {
            game.GoToStartScreen();
        }
    }
}
