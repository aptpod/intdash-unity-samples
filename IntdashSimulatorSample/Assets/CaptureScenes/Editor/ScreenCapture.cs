using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// Converts the selected camera's video to PNG.
/// </summary>
[ExecuteInEditMode]
public class ScreenCapture : EditorWindow
{
    [MenuItem("Tools/Screen Capture")]
    static void OpenWindow()
    {
        var capture = EditorWindow.GetWindow<ScreenCapture>(true);
        if (Selection.activeGameObject is GameObject obj)
        {
            var camera = obj.GetComponent<Camera>();
            if (camera == null) return;
            capture.resolution = new Vector2(camera.pixelWidth, camera.pixelHeight);
        }
    }

    private Vector2 resolution = new Vector2(7680, 4320);

    private void OnGUI()
    {
        resolution = EditorGUILayout.Vector2Field("Resolution", resolution);

        if (GUILayout.Button("Capture"))
        {
            if (Selection.activeGameObject is GameObject obj)
            {
                var camera = obj.GetComponent<Camera>();
                if (camera != null)
                {
                    Capture(camera);
                    return;
                }
            }
            EditorUtility.DisplayDialog("No camera selected", "Please select camera.", "OK");
        }
    }

    void Capture(Camera camera)
    {
        var width = (int)resolution.x;
        var height = (int)resolution.y;
        var render = new RenderTexture(width, height, 24);
        var texture = new Texture2D(width, height, TextureFormat.RGB24, false);

        RenderTexture prevTexture = null;
        try
        {
            prevTexture = camera.targetTexture;
            camera.targetTexture = render;
            camera.Render();

            RenderTexture.active = render;
            texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            texture.Apply();
        }
        finally
        {
            camera.targetTexture = prevTexture;
            RenderTexture.active = null;
        }

        File.WriteAllBytes(
            $"{Application.dataPath}/camera.png",
            texture.EncodeToPNG());
    }
}
