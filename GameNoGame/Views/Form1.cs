using System.Windows.Forms;

namespace GameNoGame
{
    public partial class Form1 : Form
    {
        private Game game;

        public Form1()
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
                case GameStage.MapChoosing:
                    ShowMapChoosingScreen();
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
            startControl1.Configure(game);
            startControl1.Show();
        }

        private void ShowLevelScreen()
        {
            HideScreens();
            //levelControl.Configure(game);
           // levelControl.Show();
        }

        private void ShowFinishedScreen()
        {
            HideScreens();
            exitControl1.Configure(game);
            exitControl1.Show();
        }

        private void ShowMapChoosingScreen()
        {
            HideScreens();
            mapChoosingControl1.Configure(game);
            mapChoosingControl1.Show();
        }

        private void HideScreens()
        {
            startControl1.Hide();
            //levelControl.Hide();
            exitControl1.Hide();
        }
    }
}