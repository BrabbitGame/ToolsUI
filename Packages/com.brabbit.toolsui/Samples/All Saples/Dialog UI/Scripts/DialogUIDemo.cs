using ToolsUI;
using UnityEngine;

namespace Sample {

    public class DialogUIDemo : MonoBehaviour {

        [SerializeField] private DialogUI dialogPrefab = null;

        void Start() {

            // Activate the GameObject present in the scene
            DialogUI.Instance
                .SetTitle("Message 1")
                .SetMessage("Hello!")
                .SetButtonColor(PaletteColor.Green)
                .OnClose((bool positive, bool negative) => Debug.Log($"pos:{positive}   neg{negative}")) // if not declared no action is take after the Yes/No Click
                .Show();


            // Activate the GameObject present in the scene
            DialogUI.Instance
                .SetTitle("Message 2")
                .SetMessage("Hello Again :)")
                .SetButtonColor(PaletteColor.Magenta)
                .SetButtonText("ok :)")
                .Show();


            // Activate the GameObject present in the scene
            DialogUI.Instance
                .SetTitle("Message 3")
                .SetMessage("Bye!")
                .SetFadeInDuration(2f)
                .SetButtonColor(PaletteColor.Red)
                .Show();


            // Auto create Two Buttons Dialog,  from prefab, and auto destroy, whit OnClose Action
            DialogUI
                .Instantiate(dialogPrefab)
                .IsAutoDestroy(true)        // if not declared is the default
                .SetDialogType(DialogType.TwoButtons)
                .SetTitle("Titel.......")
                .SetMessage("Message.\nQuestion ?")
                .SetButtonText("Yes :)", "No")
                .SetButtonColor(PaletteColor.Green, PaletteColor.Red)
                .OnClose(OnDialogClick)     // if not declared no action is take after the Yes/No Click
                .Show();

        }

        public void OnDialogClick(bool positive, bool negative) {
            Debug.Log($"pos:{positive}   neg{negative}");
        }

    }
}

