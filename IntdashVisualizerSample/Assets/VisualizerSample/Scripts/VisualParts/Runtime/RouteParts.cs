using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class RouteParts : MonoBehaviour
{
    public float RenderingInterval = 0.09f;

    public Color RouteColor = Color.yellow;
    private Color? _RouteColor;

    public float PointScale = 0.75f;
    private float? _PointScale;

    public int MaxCashingPointLength = 1000000;
    private int? _MaxCashingPointLength;

    public bool IsHidden = false;
    private bool? _IsHidden = null;

    private ParticleSystem particle;
    private ParticleSystem.MainModule particleMain;
    private ParticleSystemRenderer particleRenderer;

    private List<ParticleSystem.EmitParams> emitPoints = new List<ParticleSystem.EmitParams>();
    private object pointLock = new object();

    private long prevTime = 0;

    private void Awake()
    {
        particle = this.gameObject.GetComponent<ParticleSystem>();
        particleMain = particle.main;

        var emissionModule = particle.emission;
        emissionModule.enabled = true;
        var shapeModule = particle.shape;
        shapeModule.enabled = false;

        var collisionModule = particle.collision;
        collisionModule.enabled = true;
        collisionModule.mode = ParticleSystemCollisionMode.Collision3D;

        particleMain.playOnAwake = false;
        particleMain.loop = true;
        particleMain.prewarm = true;
        particleMain.simulationSpace = ParticleSystemSimulationSpace.World;
        particleMain.startSpeed = 0; // Hold stationary.
        particleMain.startLifetime = 0;
        particleMain.ringBufferMode = ParticleSystemRingBufferMode.PauseUntilReplaced;
        particle.Pause(); // Always pause and disable lifetime.

        particleRenderer = particle.GetComponent<ParticleSystemRenderer>();
        particleRenderer.renderMode = ParticleSystemRenderMode.Mesh;
        particleRenderer.SetMeshes(new Mesh[] { Resources.GetBuiltinResource<Mesh>("Cube.fbx") });
        particleRenderer.material = new Material(Shader.Find("Transparent/Diffuse"));

        particleRenderer.alignment = ParticleSystemRenderSpace.Local; // Billboard Disable
    }

    // Update is called once per frame
    void Update()
    {
        bool isUpdated = false;
        ParticleSystem.EmitParams[] points = null;
        lock (pointLock)
        {
            if (emitPoints.Count > 0)
            {
                points = emitPoints.ToArray();
                emitPoints.Clear();
            }
        }

        if (points != null)
        {
            foreach (var point in points)
            {
                particle.Emit(point, 1);
            }
        }

        if (_RouteColor != RouteColor)
        {
            _RouteColor = RouteColor;
            particleRenderer.material.color = RouteColor;
            isUpdated = true;
        }

        if (_MaxCashingPointLength != MaxCashingPointLength)
        {
            _MaxCashingPointLength = MaxCashingPointLength;
            particleMain.maxParticles = MaxCashingPointLength;
        }

        if (_IsHidden != IsHidden)
        {
            _IsHidden = IsHidden;
            isUpdated = true;
        }

        if (_PointScale != PointScale)
        {
            _PointScale = PointScale;
            isUpdated = true;
        }

        if (isUpdated)
        {
            UpdateParticles();
        }
    }

    private void UpdateParticles(bool isHidden = false)
    {
        var particles = GetParticles();
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].startColor = RouteColor;
            particles[i].startSize = isHidden ? 0 : PointScale;
        }
        SetParticles(particles);
    }

    public ParticleSystem.Particle[] GetParticles()
    {
        var points = new ParticleSystem.Particle[particle.particleCount];
        particle.GetParticles(points);
        return points;
    }

    public void SetParticles(ParticleSystem.Particle[] particles)
    {
        particle.SetParticles(particles);
    }

    public void AddPoint(Vector3 point, long time)
    {
        var diff = (time - prevTime).TicksToSeconds();
        if (diff < RenderingInterval) return;
        prevTime = time;
        var param = new ParticleSystem.EmitParams();
        param.position = point;
        param.rotation3D = Vector3.zero;
        param.startSize = IsHidden ? 0 : PointScale;
        param.startLifetime = 0;
        lock (pointLock)
        {
            emitPoints.Add(param);
        }
    }

    public void Clear()
    {
        particle.Clear(true);
    }

    private void OnEnable()
    {
        particle.Pause();
    }

    private void OnDisable()
    {
        particle.Stop();
    }
}
