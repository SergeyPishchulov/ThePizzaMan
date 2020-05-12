using System.Windows.Forms;

namespace GameNoGame
{
    public partial class MainForm : Form
    {
        private readonly InterfaceManager interfaceManager;

        public MainForm()
        {
            InitializeComponent(); //создание control'ов
            interfaceManager = new InterfaceManager(startControl, exitControl, mapChoosingControl, levelControl);
            interfaceManager.StageChanged += Game_OnStageChanged;

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
            startControl.Configure(interfaceManager);
            startControl.Show();
        }

        private void ShowLevelScreen()
        {
            HideScreens();
            levelControl.Configure(interfaceManager);
            levelControl.Show();
        }

        private void ShowFinishedScreen()
        {
            HideScreens();
            exitControl.Configure(interfaceManager);
            exitControl.Show();
        }

        private void ShowMapChoosingScreen()
        {
            HideScreens();
            mapChoosingControl.Configure(interfaceManager);
            mapChoosingControl.Show();
        }

        private void HideScreens()
        {
            startControl.Hide();
            levelControl.Hide();
            exitControl.Hide();
            mapChoosingControl.Hide();
        }
    }
}