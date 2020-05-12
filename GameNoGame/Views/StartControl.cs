using System;
using System.Windows.Forms;

namespace GameNoGame
{
    public partial class StartControl : UserControl
    {
        public InterfaceManager interfaceManager;

        public StartControl()
        {
            InitializeComponent();
        }

        public void Configure(InterfaceManager interfaceManager)
        {
            if (this.interfaceManager != null)
                return;

            this.interfaceManager = interfaceManager;

            startButton.Click += StartButton_Click;
            ExitButton.Click += ExitButton_Click;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            interfaceManager.ChooseMap();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            interfaceManager.Exit();
        }
    }
}
