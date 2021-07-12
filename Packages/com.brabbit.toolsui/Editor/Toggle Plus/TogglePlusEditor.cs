using UnityEditor.SceneManagement;
using UnityEngine.UI;

namespace UnityEditor.UI {
    [CustomEditor(typeof(TogglePlus), true)]
    [CanEditMultipleObjects]
    /// <summary>
    /// Custom Editor for the Toggle Component.
    /// Extend this class to write a custom editor for a component derived from Toggle.
    /// </summary>
    public class TogglePlusEditor : SelectableEditor {
        SerializedProperty m_OnValueChangedProperty;
        SerializedProperty m_TransitionProperty;
        SerializedProperty m_GraphicProperty;
        SerializedProperty m_GroupProperty;
        SerializedProperty m_IsOnProperty;
        SerializedProperty m_IdProperty;

        protected override void OnEnable() {
            base.OnEnable();

            m_TransitionProperty = serializedObject.FindProperty("toggleTransition");
            m_GraphicProperty = serializedObject.FindProperty("graphic");
            m_GroupProperty = serializedObject.FindProperty("m_Group");
            m_IsOnProperty = serializedObject.FindProperty("m_IsOn");
            m_OnValueChangedProperty = serializedObject.FindProperty("onValueChanged");
            m_IdProperty = serializedObject.FindProperty("m_id");
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            EditorGUILayout.Space();

            serializedObject.Update();
            TogglePlus toggle = serializedObject.targetObject as TogglePlus;
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(m_IdProperty);
            EditorGUILayout.PropertyField(m_IsOnProperty);
            if (EditorGUI.EndChangeCheck()) {
                EditorSceneManager.MarkSceneDirty(toggle.gameObject.scene);
                ToggleGroupPlus group = m_GroupProperty.objectReferenceValue as ToggleGroupPlus;

                toggle.isOn = m_IsOnProperty.boolValue;

                if (group != null && group.isActiveAndEnabled && toggle.IsActive()) {
                    if (toggle.isOn || (!group.AnyTogglesOn() && !group.allowSwitchOff)) {
                        toggle.isOn = true;
                        group.NotifyToggleOn(toggle);
                    }
                }
            }
            EditorGUILayout.PropertyField(m_TransitionProperty);
            EditorGUILayout.PropertyField(m_GraphicProperty);
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(m_GroupProperty);
            if (EditorGUI.EndChangeCheck()) {
                EditorSceneManager.MarkSceneDirty(toggle.gameObject.scene);
                ToggleGroupPlus group = m_GroupProperty.objectReferenceValue as ToggleGroupPlus;
                toggle.group = group;
            }

            EditorGUILayout.Space();

            // Draw the event notification options
            EditorGUILayout.PropertyField(m_OnValueChangedProperty);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
