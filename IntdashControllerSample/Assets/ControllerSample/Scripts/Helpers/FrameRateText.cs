using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrameRateText : MonoBehaviour
{
    public TMP_Text OutputText;

    private int frameCount;
    private float prevTime;

    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }

    void Update()
    {
        if (OutputText == null) return;

        ++frameCount;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            OutputText.text = string.Format("{0:f1} FPS", frameCount / time);

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }
}
