using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stering_Car : MonoBehaviour
{
    public float MotorForce, SteerFroce, BreakForce ,v ,h,b,f;
    public WheelCollider FR_L_Wheel, FR_R_Wheel, BC_L_Wheel, BC_R_Wheel;
    public AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        soundEfect();
         v = Input.GetAxis("Vertical") * MotorForce;
         h = Input.GetAxis("Horizontal") * SteerFroce;

       f= BC_L_Wheel.motorTorque = v;
       f= BC_R_Wheel.motorTorque = v;

        FR_L_Wheel.steerAngle = h;
        FR_R_Wheel.steerAngle = h;

        //if (Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.DownArrow))
       /// {
        //    Debug.Log("Weszlo:"+ BC_L_Wheel.brakeTorque);
        //   b= BC_L_Wheel.brakeTorque = BreakForce*5;
        //   b= BC_R_Wheel.brakeTorque = BreakForce*5;
        //    Debug.Log("Weszlo2:" + BC_L_Wheel.brakeTorque);
       // }
      //  else
       // {
      //     b= BC_L_Wheel.brakeTorque = 0;
      //     b= BC_R_Wheel.brakeTorque = 0;
      //  }

        if (Input.GetKeyUp(KeyCode.Space))
        {
          b=  BC_L_Wheel.brakeTorque = 0;
          b=  BC_R_Wheel.brakeTorque = 0;
        }

        if (v < 0)
        {
         b=   BC_L_Wheel.brakeTorque = BC_L_Wheel.brakeTorque +100000;
         b = BC_R_Wheel.brakeTorque = BC_R_Wheel.brakeTorque +100000;
        }
        else if(v==0)
        {
          
            b =  BC_L_Wheel.brakeTorque =1000;
          b=  BC_R_Wheel.brakeTorque =1000;
        }
        else if(v>0)
        {
            b = BC_L_Wheel.brakeTorque = 0;
            b = BC_R_Wheel.brakeTorque = 0;
        }

        if (Input.GetKey(KeyCode.DownArrow)&&Input.GetKey(KeyCode.R))
        {
            b = BC_L_Wheel.brakeTorque = 0;
            b = BC_R_Wheel.brakeTorque = 0;
            v = v - 1000;
            Debug.Log("Wstecny");
        }
    }

    void soundEfect()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {

        }
        else
        {
            audio.pitch = v / 10000;
        }
      
    }
}
