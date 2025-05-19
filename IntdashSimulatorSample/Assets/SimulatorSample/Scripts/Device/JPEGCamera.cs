using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Camera))]
public class JPEGCamera : MonoBehaviour
{
    private static readonly TextureFormat TEXTURE_FORMAT = TextureFormat.RGB24;

    public int Width = 1280;
    public int Height = 720;
    private int? _Width, _Height;
    [Range(0, 100)] public int Quality = 50;
    public float ScanRate = 15f;
    private float? _ScanRate;

    private Camera targetCamera;
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

    private void Awake()
    {
        this.targetCamera = GetComponent<Camera>();
        this.targetCamera.enabled = false;
    }

    private void Start()
    {
        CheckParameters();
    }

    private void CheckParameters()
    {
        bool resetElapsedTime = false;

        if (ScanRate != _ScanRate)
        {
            _ScanRate = ScanRate;
            targetTime = 1f / ScanRate;
            resetElapsedTime = true;
        }

        if (Width >= 10 && Height >= 10)
        {
            if (Width != _Width || Height != _Height)
            {
                _Width = Width;
                _Height = Height;
                this.texture = new Texture2D(this.Width, this.Height, TEXTURE_FORMAT, false);
                this.rect = new Rect(0, 0, this.Width, this.Height);
                this.texture.Apply();
                this.targetCamera.targetTexture = new RenderTexture(this.Width, this.Height, 24);
                resetElapsedTime = true;
            }
        }

        if (resetElapsedTime)
        {
            elapsedTime = 0;
        }
    }

    private void Update()
    {
        CheckParameters();

        if (Width < 10 || Height < 10) return;
        if (ScanRate <= 0) return;
        elapsedTime += Time.deltaTime;
        if (elapsedTime > targetTime)
        {
            elapsedTime -= targetTime;
            targetCamera.Render();

            AsyncGPUReadback.Request(targetCamera.activeTexture, 0, TEXTURE_FORMAT, (request) =>
            {
                if (request.hasError) return;
                if (texture == null) return;
                texture.LoadRawTextureData(request.GetData<uint>());
                var data = this.texture.EncodeToJPG(this.Quality);
                OnOutputData?.Invoke(new OutputData(data));
            });
        }
    }
}