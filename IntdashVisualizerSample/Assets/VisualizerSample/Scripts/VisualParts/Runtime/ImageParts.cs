using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ImageParts : MonoBehaviour
{
    private RawImage rawImage;
    [SerializeField]
    private Vector2? previewSize;
    private Vector2? prevImageRectSize;

    // Start is called before the first frame update
    void Start()
    {
        rawImage = this.GetComponent<RawImage>();
        rawImage.color = Color.clear;
    }

    public Texture2D PreviewTexture { private set; get; }

    public void SetPreviewTexture(Texture2D texture)
    {
        PreviewTexture = texture;
        rawImage.texture = texture;
        rawImage.color = texture == null ? Color.clear : Color.white;
        if (texture == null) return;
        previewSize = new Vector2(texture.width, texture.height);
        FixAspect(rawImage);
    }

    private void Update()
    {
        if (previewSize != null)
        {
            var size = this.transform.parent.GetComponent<RectTransform>().rect.size;
            if (size != prevImageRectSize)
            {
                FixAspect(rawImage, size);
            }
        }
    }

    /// <summary>
    /// Correct the size of the RawImage to fit the aspect ratio.
    /// Current UI size is the standard.
    /// </summary>
    private void FixAspect(RawImage image)
    {
        FixAspect(image, image.transform.parent.GetComponent<RectTransform>().rect.size);
    }
    /// <summary>
    /// Correct the size of the RawImage to fit the aspect ratio.
    /// </summary>
    /// <param name="originalSize">Standard UI size</param>
    private void FixAspect(RawImage image, Vector3 originalSize)
    {
        if (image.texture == null) return;
        prevImageRectSize = originalSize;
        var textureSize = new Vector2(image.texture.width, image.texture.height);

        var heightScale = originalSize.y / textureSize.y;
        var widthScale = originalSize.x / textureSize.x;
        var rectSize = textureSize * Mathf.Min(heightScale, widthScale);

        var anchorDiff = image.rectTransform.anchorMax - image.rectTransform.anchorMin;
        var parentSize = image.transform.parent.GetComponent<RectTransform>().rect.size;
        var anchorSize = parentSize * anchorDiff;

        image.rectTransform.sizeDelta = rectSize - anchorSize;
    }
}
