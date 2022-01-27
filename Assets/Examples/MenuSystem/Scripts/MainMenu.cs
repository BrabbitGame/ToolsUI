using UnityEngine;
using ToolsUI;

namespace Sample {

    public class MainMenu : SimpleMenu<MainMenu> {

        public void OnClick_PlayPressed() {
            GameMenu.Show();
        }

        public void OnClick_OptionsPressed() {
            OptionsMenu.Show();
        }

        public override void OnClick_BackPressed() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}