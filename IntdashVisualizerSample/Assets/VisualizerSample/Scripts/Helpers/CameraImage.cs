using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class CameraImage : MonoBehaviour
{
    public Camera TargetCamera;
    private Camera prevCamera;
    public float RefreshRate = 15;
    private float? _RefreshRate;
    private float refreshTime;

    private RawImage rawImage;
    private Vector2? prevImageSize;

    // Start is called before the first frame update
    void Start()
    {
        TargetCamera.enabled = false;
        rawImage = this.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_RefreshRate != RefreshRate)
        {
            _RefreshRate = RefreshRate;
            refreshTime = 0;
        }

        RefreshContent();
    }

    private void UpdateTexture(Vector2 size)
    {
        var texture = RenderTextureUtils.GenerateTexture2D(size);
        TargetCamera.targetTexture = texture;
        prevCamera = TargetCamera;
        rawImage.texture = texture;
        if (rawImage.color != Color.white)
        {
            rawImage.color = Color.white;
        }
    }

    private void RefreshContent()
    {
        refreshTime -= Time.deltaTime;
        if (refreshTime <= 0)
        {
            refreshTime = 1f / RefreshRate;

            var size = rawImage.transform.parent.GetComponent<RectTransform>().rect.size;
            if (prevImageSize != size || prevCamera != TargetCamera)
            {
                prevImageSize = size;
                UpdateTexture(size);
            }

            TargetCamera.Render();
        }
    }
}
