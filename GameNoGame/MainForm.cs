using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameNoGame
{
    public partial class MainForm : Form
    {
        public Game game; 

        public MainForm()
        {
            InitializeComponent();

            game = new Game();
            game.StageChanged += Game_OnStageChanged;

            ShowStartScreen();
        }

        private void Game_OnStageChanged(GameStage stage)
        {
            switch (stage)
            {
                case GameStage.Level:
                    ShowLevelScreen();
                    break;
                case GameStage.Finished:
                    ShowFinishedScreen();
                    break;
                case GameStage.NotStarted:
                default:
                    ShowStartScreen();
                    break;
            }
        }

        private void ShowStartScreen()
        {
            HideScreens();
            startControl.Configure(game);
            startControl.Show();
        }

        private void ShowLevelScreen()
        {
            HideScreens();
            battleControl.Configure(game);
            battleControl.Show();
        }

        private void ShowFinishedScreen()
        {
            HideScreens();
            finishedControl.Configure(game);
            finishedControl.Show();
        }

        private void HideScreens()
        {
            startControl.Hide();
            levelControl.Hide();
        }
    }
}
