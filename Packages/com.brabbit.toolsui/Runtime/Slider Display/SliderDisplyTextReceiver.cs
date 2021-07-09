using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

namespace ToolsUI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    
    public class SliderDisplyTextReceiver : MonoBehaviour
    {
        private TextMeshProUGUI textDisplayValue = null;

        private void Awake() {
            Slider slider = GetComponentInParent<Slider>();
            slider.onValueChanged.AddListener(( i ) => ValueChanged( i ));

            textDisplayValue = GetComponent<TextMeshProUGUI>();
            textDisplayValue.text = slider.value.ToString(); 
        }

        void ValueChanged(float value){
            textDisplayValue.text = value.ToString();
        }

#if UNITY_EDITOR

        [MenuItem("GameObject/UI/Tools UI/Slider Display", false, 10)]
        static void CreateSliderDisplay(MenuCommand menuCommand){
            GameObject go = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<Object>("Packages/com.brabbit.toolsui/Runtime/Slider Display/SliderDisplay.prefab"));
            PrefabUtility.UnpackPrefabInstance(go, PrefabUnpackMode.Completely, InteractionMode.UserAction);
            go.name = "SliderDisplay";

            // reperente if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
#endif      

    }
}
