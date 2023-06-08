using System;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class CarIscpControl : MonoBehaviour
{
    [SerializeField] private Iscp_ControlSubscriber iscpSubscriber;

    private void Start()
    {
        iscpSubscriber.TargetComponent = this;
    }

    public void Move(float steering, float accel, float footbrake, float handbrake)
    {
        GetComponent<CarController>().Move(
                steering,
                accel,
                footbrake,
                handbrake);
    }
}