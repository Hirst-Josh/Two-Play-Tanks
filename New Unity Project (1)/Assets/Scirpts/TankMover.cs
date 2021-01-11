using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;
using XboxCtrlrInput;


public class TankMover : MonoBehaviour
{
    PlayerControlls inputActions;
    public float Forwardspeed1;
    public float Forwardspeed2;
    public float Forwardspeed3;
    public float Backwardspeed1;
    public float TurnRate1;
    public float TurnRate2;
    public float TurnRate3;
    public bool Gear1;
    public bool Gear2;
    public bool Gear3;
    public bool forward;
    public bool backward;
    public bool left;
    public bool right;
    public bool brake;
    public Image image;

    public Transform centerOfGravity;
    public float idealRPM = 500f;
    public float maxRPM = 1000f;

    public float turnRadius = 12f;
    public float torque = 50;
    public float brakeTorque = 100f;

    public float AntiRoll = 20000.0f;

    public enum DriveMode { Front, Rear, All };
    public DriveMode driveMode = DriveMode.Rear;

    public Text speedText;



    float scaledTorque;


    public void Awake()
    {

        Gear1 = true;
        Forwardspeed1 =1000;
        TurnRate1 = 50;
        Forwardspeed2 = 10;
        TurnRate2 = 2;
        Forwardspeed3 = 14;
        TurnRate3 = 1;
        Backwardspeed1 = -25;
    }

    public WheelCollider wheelFR;
    public WheelCollider wheelFL;
    public WheelCollider wheelRR;
    public WheelCollider wheelRL;



    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfGravity.localPosition;
    }


    public float Speed()
    {
        return wheelRR.radius * Mathf.PI * wheelRR.rpm * 60f / 1000f;
    }

    public float Rpm()
    {
        return wheelRL.rpm;
    }


    void OnEnable()
    {
       // inputActions.Gameplay.Enable();
    }


    public void GetInput()
    {
        //m_horizontalInput = Input.GetAxis("Horizontal1");
        //m_verticalInput = Input.GetAxis("Vertical1");
    }

    void FixedUpdate()
    {

        // if (speedText != null)
        //   speedText.text = "Speed: " + Speed().ToString("f0") + " km/h";

        //Debug.Log ("Speed: " + (wheelRR.radius * Mathf.PI * wheelRR.rpm * 60f / 1000f) + "km/h    RPM: " + wheelRL.rpm);

        float scaledTorque = XCI.GetAxis(XboxAxis.LeftStickY, XboxController.First) * Forwardspeed1;


        if (wheelRL.rpm < idealRPM)
            scaledTorque = Mathf.Lerp(scaledTorque / 10f, scaledTorque, wheelRL.rpm / idealRPM);
        else
            scaledTorque = Mathf.Lerp(scaledTorque, 0, (wheelRL.rpm - idealRPM) / (maxRPM - idealRPM));

     //   DoRollBar(wheelFR, wheelFL);
     //   DoRollBar(wheelRR, wheelRL);



        wheelFR.steerAngle = XCI.GetAxis(XboxAxis.LeftStickX, XboxController.First) * TurnRate1;
        wheelFL.steerAngle = XCI.GetAxis(XboxAxis.LeftStickX, XboxController.First) * TurnRate1;

        wheelFR.motorTorque = driveMode == DriveMode.Rear ? 0 : scaledTorque;
        wheelFL.motorTorque = driveMode == DriveMode.Rear ? 0 : scaledTorque;
        wheelRR.motorTorque = driveMode == DriveMode.Front ? 0 : scaledTorque;
        wheelRL.motorTorque = driveMode == DriveMode.Front ? 0 : scaledTorque;

        if (brake == true)
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

        void DoRollBar(WheelCollider WheelL, WheelCollider WheelR)
        {
            WheelHit hit;
            float travelL = 1.0f;
            float travelR = 1.0f;

            bool groundedL = WheelL.GetGroundHit(out hit);
            if (groundedL)
                travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;

            bool groundedR = WheelR.GetGroundHit(out hit);
            if (groundedR)
                travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;

            float antiRollForce = (travelL - travelR) * AntiRoll;

            if (groundedL)
                GetComponent<Rigidbody>().AddForceAtPosition(WheelL.transform.up * -antiRollForce,
                                             WheelL.transform.position);
            if (groundedR)
                GetComponent<Rigidbody>().AddForceAtPosition(WheelR.transform.up * antiRollForce,
                                             WheelR.transform.position);
        }
    }





}
