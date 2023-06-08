using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureUtils
{
    public static RenderTexture GenerateTexture2D(Vector2? size = null)
    {
        RenderTexture texture;
        if (size == null) texture = new RenderTexture(Display.main.renderingWidth, Display.main.renderingHeight, 0);
        else
        {
            var s = size.Value;
            var dW = Display.main.renderingWidth;
            var dH = Display.main.renderingHeight;
            if (s.x <= 0f) s.x = dW;
            if (s.y <= 0f) s.y = dH;
            if (s.x < dW && s.y < dH)
            {
                var ratio = s.x < s.y ? dW / s.x : dH / s.y;
                s *= ratio;
            }
            texture = new RenderTexture((int)s.x, (int)s.y, 0);
        }
        texture.dimension = UnityEngine.Rendering.TextureDimension.Tex2D;
        texture.Create();
        return texture;
    }
}
