using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCar : MonoBehaviour
{
    public Transform car;
    public float distance;
    public float height;
    public float rotationDamping;
    public float heightDamping;
    public float zoomRatio;
    public float defaultFOV;

    public float rotation_v;


    void FixedUpdate()
    {
        Vector3 local_velocity = car.InverseTransformDirection(car.GetComponent<Rigidbody>().velocity);
        if (local_velocity.z < -0.5f)
        {
            rotation_v = car.eulerAngles.y + 100;
        }
        else
        {
            rotation_v = car.eulerAngles.y;
        }

        float acceleration = car.GetComponent<Rigidbody>().velocity.magnitude;

        Camera.main.fieldOfView = defaultFOV + acceleration * zoomRatio * Time.deltaTime;

    }

    void LateUpdate()
    {
        float wantedAngle = rotation_v;

        float wantedHeight = car.position.y + height;
        
        float myAngle = transform.eulerAngles.y;
        float myHeigh = transform.position.y;

        myAngle = Mathf.LerpAngle(myAngle, wantedAngle, rotationDamping + Time.deltaTime);
        myHeigh = Mathf.LerpAngle(myHeigh, wantedHeight, heightDamping + Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);

        transform.position = car.position;
        transform.position -= currentRotation * Vector3.forward *distance;

        Vector3 temp = transform.position;
        temp.y = myHeigh;
        temp.x = car.position.x + -5.0f;//temp.x + -3.0f;
        transform.position = temp;

        //transform.LookAt(car);

    }
}
