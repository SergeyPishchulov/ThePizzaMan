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
    public partial class MapChoosingControl : UserControl
    {
        public Game game;

        public MapChoosingControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;

            Back.Click += Back_Click;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            game.GoToStartScreen();
        }

        private void Map1_Click(object sender, EventArgs e)
        {

        }

        private void Map2_Click(object sender, EventArgs e)
        {

        }

        private void Map3_Click(object sender, EventArgs e)
        {

        }

        private void Map4_Click(object sender, EventArgs e)
        {

        }
    }
}
