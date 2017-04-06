using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarController : MonoBehaviour
{

    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    public Transform CenterOfMass;

    private float turnRadius = 6f;
    private float torque = 5000f;
    private float brakeTorque = 500f;

    public float idealRPM = 500f;
    public float maxRPM = 1000f;

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = CenterOfMass.localPosition;
    }

    void FixedUpdate()
    {
        float scaledTorque = Input.GetAxis("Vertical") * torque;

        if (wheelRL.rpm < idealRPM)
        {
            scaledTorque = Mathf.Lerp(scaledTorque / 10f, scaledTorque, wheelRL.rpm / idealRPM);
        }
        else
        {
            scaledTorque = Mathf.Lerp(scaledTorque, 0, (wheelRL.rpm - idealRPM) / (maxRPM - idealRPM));
        }

        wheelFL.steerAngle = Input.GetAxis("Horizontal") * turnRadius;
        wheelFR.steerAngle = Input.GetAxis("Horizontal") * turnRadius;

        wheelRR.motorTorque = scaledTorque;
        wheelRL.motorTorque = scaledTorque;

        if (Input.GetKey("space"))
        {
            wheelFR.brakeTorque = brakeTorque;
            wheelFL.brakeTorque = brakeTorque;
            wheelRR.brakeTorque = brakeTorque;
            wheelRL.brakeTorque = brakeTorque;
        }
        else
        {
            wheelFR.brakeTorque = 0;
            wheelFL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
            wheelRL.brakeTorque = 0;
        }
    }
}
