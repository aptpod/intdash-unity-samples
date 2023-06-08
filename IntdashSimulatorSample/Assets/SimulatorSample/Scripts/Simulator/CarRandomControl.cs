using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class CarRandomControl : MonoBehaviour
{
    public float UpdateRate = 0.5f;
    private float _UpdateRate;

    private float elapsedTime = 0;
    private float targetTime = 0;

    public float Steering = 0;
    public float Accel = 0;
    public float Footbrake = 0;
    public float Handbrake = 0;

    private CarController controller;

    private void Start()
    {
        controller = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UpdateRate != _UpdateRate)
        {
            _UpdateRate = UpdateRate;
            this.targetTime = 1f / _UpdateRate;
            this.elapsedTime = 0f;
        }

        if (UpdateRate <= 0) return;

        elapsedTime += Time.deltaTime;

        if (this.elapsedTime > this.targetTime)
        {
            this.elapsedTime -= this.targetTime;

            Steering = Random.Range(-1, 1);
            Accel = Random.Range(-1, 1);
        }

        if (controller != null)
        {
            controller.Move(Steering, Accel, Footbrake, Handbrake);
        }
    }
}
