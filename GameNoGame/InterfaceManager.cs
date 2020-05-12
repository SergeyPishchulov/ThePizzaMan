using System;
using System.Windows.Forms;

namespace GameNoGame
{
    public class InterfaceManager
    {
        public GameStage Stage { get; set; } = GameStage.NotStarted;
        public event Action<GameStage> StageChanged;

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
