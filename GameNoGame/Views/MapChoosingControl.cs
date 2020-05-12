using System;
using System.Windows.Forms;

namespace GameNoGame
{
    public partial class MapChoosingControl : UserControl
    {
        public InterfaceManager interfaceManager;

        public MapChoosingControl()
        {
            InitializeComponent();
        }

        public void Configure(InterfaceManager interfaceManager)
        {
            if (this.interfaceManager != null)
                return;

            this.interfaceManager = interfaceManager;

            Back.Click += Back_Click;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            interfaceManager.GoToStartScreen();
        }

        private void Map1_Click(object sender, EventArgs e)
        {
            interfaceManager.LaunchFirstMap();
        }

        private void Map2_Click(object sender, EventArgs e)
        {
            interfaceManager.LaunchSecondMap();
        }

        private void Map3_Click(object sender, EventArgs e)
        {
            interfaceManager.LaunchThirdMap();
        }

        private void Map4_Click(object sender, EventArgs e)
        {
            interfaceManager.LaunchFourthMap();
        }
    }
}
