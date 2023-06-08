using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSensor : MonoBehaviour
{
    public float SamplingRate = 10f;
    private float? _SamplingRate;

    // MEMO: Might need to go from position and rotation to NMEA or other values.
    public struct OutputData
    {
        public readonly Vector3 Position;
        public readonly Vector3 Rotation;

        public OutputData(Vector3 position, Vector3 rotation)
        {
            this.Position = position;
            this.Rotation = rotation;
        }
    }
    public delegate void OnOutputDataDelegate(OutputData outputData);
    public OnOutputDataDelegate OnOutputData;

    private float elapsedTime = 0;
    private float targetTime = 0;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (SamplingRate != _SamplingRate)
        {
            _SamplingRate = SamplingRate;
            this.targetTime = 1f / SamplingRate;
            this.elapsedTime = 0f;
        }

        if (SamplingRate <= 0) return;

        elapsedTime += Time.deltaTime;

        if (this.elapsedTime > this.targetTime)
        {
            this.elapsedTime -= this.targetTime;
            // MEMO: Might need to go from position and rotation to NMEA or other values.
            var data = new OutputData(this.transform.position, this.transform.eulerAngles);
            OnOutputData?.Invoke(data);
        }
    }
}
