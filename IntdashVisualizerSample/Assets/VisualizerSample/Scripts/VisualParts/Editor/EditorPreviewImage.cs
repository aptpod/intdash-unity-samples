using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class EditorPreviewImage : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var script = target as ITexture2D;

        var texture = script.Texture;
        if (texture != null)
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.LabelField("Size:", $"{texture.width}x{texture.height}");
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.UpperCenter;
            EditorGUILayout.LabelField(new GUIContent(texture), style, GUILayout.MaxWidth(texture.width), GUILayout.MaxHeight(texture.height), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            EditorGUILayout.EndVertical();
        } 
    }
}


[CustomEditor(typeof(Iscp_JPEGSubscriber))]
public class ISCP_EditorPreviewImage : EditorPreviewImage { }
