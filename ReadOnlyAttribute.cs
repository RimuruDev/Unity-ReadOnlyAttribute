using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace RimuruDev
{
    public sealed class ReadOnlyAttribute : PropertyAttribute { }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public sealed class ReadOnlyPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SetGUIEnabled(isVisible: false);
            DrawPropertyField(position, property, label);
            SetGUIEnabled(isVisible: true);
        }

        private static void SetGUIEnabled(bool isVisible) =>
            GUI.enabled = isVisible;

        private static void DrawPropertyField(Rect position, SerializedProperty property, GUIContent label) =>
            EditorGUI.PropertyField(position, property, label);
    }
#endif
}
