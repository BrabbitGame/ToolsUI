using UnityEngine;
using UnityEngine.UI;

namespace Sample {

    public class ToggleGroupEvenReceiver : MonoBehaviour {
        [SerializeField] TogglePlus toogleOuner = null;

        public void OnToggleGroup_ToggleIsOn(TogglePlus toggle) {
            if (toogleOuner == toggle) {
                gameObject.SetActive(true);
                Debug.Log($"{gameObject.name}  {toggle}");
            } else {
                gameObject.SetActive(false);
                Debug.Log($"{gameObject.name}  {toggle}");
            }

        }
    }
}
