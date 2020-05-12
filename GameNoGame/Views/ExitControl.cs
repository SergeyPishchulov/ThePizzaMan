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
        public InterfaceManager interfaceManager;

        public ExitControl()
        {
            InitializeComponent();
        }

        public void Configure(InterfaceManager interfaceManager)
        {
            if (this.interfaceManager != null)
                return;

            this.interfaceManager = interfaceManager;

            YESButton.Click += YESButton_Click;
            NOButton.Click += NOButton_Click;
        }

        private void YESButton_Click(object sender, EventArgs e)
        {
            interfaceManager.CloseForm();
        }

        private void NOButton_Click(object sender, EventArgs e)
        {
            interfaceManager.GoToStartScreen();
        }
    }
}
