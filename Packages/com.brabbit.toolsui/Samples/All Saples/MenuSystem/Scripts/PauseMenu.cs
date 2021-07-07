using ToolsUI;

namespace Sample {

    public class PauseMenu : SimpleMenu<PauseMenu> {
        
        public void OnClick_QuitPressed() {
            Hide();
            Destroy(this.gameObject); // This menu does not automatically destroy itself

            GameMenu.Hide();
        }

    }
}