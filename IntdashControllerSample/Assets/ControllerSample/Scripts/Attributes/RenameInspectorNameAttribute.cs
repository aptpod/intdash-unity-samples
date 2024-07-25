using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class RenameInspectorNameAttribute : PropertyAttribute
{
    public readonly string Value;

    public RenameInspectorNameAttribute(string value)
    {
        Value = value;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(RenameInspectorNameAttribute))]
public class RenameInspectorNameDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var newLabel = attribute as RenameInspectorNameAttribute;
        EditorGUI.PropertyField(position, property, new GUIContent(newLabel.Value), true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, true);
    }
}
#endif