using System;
using System.Windows.Forms;

namespace GameNoGame
{
    public class InterfaceManager
    {
        public GameStage Stage { get; set; } = GameStage.NotStarted;
        public event Action<GameStage> StageChanged;
        private StartControl startControl;
        private ExitControl exitControl;
        private MapChoosingControl mapChoosingControl;
        private LevelControl levelControl;

        public InterfaceManager(StartControl startControl,
            ExitControl exitControl, MapChoosingControl mapChoosingControl, LevelControl levelControl)
        {
            this.startControl = startControl;
            this.exitControl = exitControl;
            this.mapChoosingControl = mapChoosingControl;
            this.levelControl = levelControl;
        }

        public void Start()
        {
            ChangeStage(GameStage.Setup);
        }

        public void ChooseMap()
        {
            ChangeStage(GameStage.MapChoosing);
        }

        public void LaunchFirstMap()
        {
            levelControl.levelNumber = 1;
            levelControl.Init();
            ChangeStage(GameStage.Level);
        }

        public void Exit()
        {
            ChangeStage(GameStage.Finished);
        }

        public void GoToStartScreen()
        {
            ChangeStage(GameStage.NotStarted);
        }

        public void CloseForm()
        {
            Application.Exit();
        }

        private void ChangeStage(GameStage stage)
        {
            Stage = stage;
            StageChanged?.Invoke(stage);
        }
    }
}
