using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float ZoomSpeed = 100.0f;
    float moveSpeed=10.0f;

    

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 Position = transform.position;

        Position.x += hor * Time.deltaTime * moveSpeed;
        Position.z += ver * Time.deltaTime * moveSpeed;

        transform.position = Position;
        Zoom();
    }

    void Zoom()
    {
         float distance = transform.position.y+(Input.GetAxis("Mouse ScrollWheel")  *-1* Time.deltaTime * ZoomSpeed);
        if(distance!=10&&distance>10)
        {
            Vector3 Position = transform.position;

            Position.y = distance;

            transform.position = Position;

        }
    }

}
