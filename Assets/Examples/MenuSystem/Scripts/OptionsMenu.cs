using UnityEngine.UI;
using ToolsUI;

namespace Sample {

    public class OptionsMenu : SimpleMenu<OptionsMenu> {
        
        public Slider Slider;

        public void OnClick_MagicButtonPressed() {
            AwesomeMenu.Show(Slider.value);
        }

    }
}