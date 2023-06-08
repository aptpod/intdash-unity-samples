using UnityEngine;

[RequireComponent(typeof(Camera))]
public class JPEGCamera : MonoBehaviour
{
    public int Width = 1280;
    public int Height = 720;
    private int? _Width, _Height;
    [Range(0, 100)] public int Quality = 50;
    public float FrameRate = 15f;
    private float? _FrameRate;

    private Camera camera_;
    private Texture2D texture;
    private Rect rect;

    public struct OutputData
    {
        public readonly byte[] JpegData;

        public OutputData(byte[] jpegData)
        {
            this.JpegData = jpegData;
        }
    }
    public delegate void OnOutputDataDelegate(OutputData outputData);
    public OnOutputDataDelegate OnOutputData;

    private float elapsedTime = 0;
    private float targetTime = 0;

    private void Start()
    {
        this.camera_ = GetComponent<Camera>();
        this.camera_.enabled = false;
        ResetTexture();
    }

    public void ResetTexture()
    {
        this.texture = new Texture2D(this.Width, this.Height, TextureFormat.RGB24, false);
        this.rect = new Rect(0, 0, this.Width, this.Height);
        this.texture.Apply();
        this.camera_.targetTexture = new RenderTexture(this.Width, this.Height, 24);
    }

    private void Update()
    {
        if (Width < 10 || Height < 10) return;

        if (Width != _Width || Height != _Height)
        {
            _Width = Width;
            _Height = Height;
            ResetTexture();
        }

        if (FrameRate != _FrameRate)
        {
            _FrameRate = FrameRate;
            this.targetTime = 1f / FrameRate;
            this.elapsedTime = 0f;
        }

        if (this.FrameRate <= 0) return;

        this.elapsedTime += Time.deltaTime;

        if (this.elapsedTime > this.targetTime)
        {
            this.elapsedTime -= this.targetTime;
            this.camera_.Render();
            RenderTexture.active = this.camera_.targetTexture;
            this.texture.ReadPixels(this.rect, 0, 0);
            var data = this.texture.EncodeToJPG(this.Quality);
            OnOutputData?.Invoke(new OutputData(data));
        }
    }
}