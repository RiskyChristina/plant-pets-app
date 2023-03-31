using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    public int pourThreshold = 45;
    private bool isPouring = false;
    public Transform target;

    private void Start()
    {
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    { 
        if (SystemInfo.supportsGyroscope) 
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }

        return false;
    }

    private void Update()
    {
        transform.LookAt(target);
        //gyro.attitude; //returns a rotation
        if (Input.deviceOrientation == DeviceOrientation.Portrait) 
        {
            transform.rotation = Input.gyro.attitude;
            //transform.LookAt(target);
        }
        
        bool pourCheck = gyro.enabled = true && CalculatePourAngle() < pourThreshold;

        if(isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else 
            {
                EndPour();   
            }
        }

    }

    private void StartPour()
    {
        //empty
    }

    private void EndPour() 
    {
        //empty
    }
    private float CalculatePourAngle()
    { 
        return 0;
    }
    
     //Set Z transform rotation to min=0 and max=45
}