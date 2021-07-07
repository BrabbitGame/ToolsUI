using ToolsUI;

namespace Sample {

    public class GameMenu : SimpleMenu<GameMenu> {

        public override void OnClick_BackPressed() {
            PauseMenu.Show();
        }

    }
}