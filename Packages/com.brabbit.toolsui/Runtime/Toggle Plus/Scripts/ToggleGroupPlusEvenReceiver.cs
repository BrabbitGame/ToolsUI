using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Tools UI/Toggle Group Plus Even Receiver", 3)]
[RequireComponent(typeof(RectTransform))]

public class ToggleGroupPlusEvenReceiver : MonoBehaviour {
    [SerializeField] TogglePlus toogleOuner = null;

    public void OnToggleGroupPlus_ToggleIsOn(TogglePlus toggle) {
        if(toogleOuner == toggle) {
            gameObject.SetActive(true);
            //Debug.Log($"{gameObject.name}  {toggle}");
        } else {
            gameObject.SetActive(false);
            //Debug.Log($"{gameObject.name}  {toggle}");
        }
        
    }
}
