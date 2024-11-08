using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float speed = 2.0f;
    //public float zRange = 40.0f;
    public float tiltSenstivity = 15.0f;
    public Rigidbody rb;
    public Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //zRange = Input.acceleration.x * speed;

        float tiltX = Input.acceleration.x * tiltSenstivity;
        float tiltY = Input.acceleration.y * tiltSenstivity;

        Quaternion targetRotation = Quaternion.Euler(tiltY, 0, -tiltX);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10.0f);
        rb.velocity = transform.forward * speed;
        CameraFollow();
    }

    private void CameraFollow()
    {
        mainCamera.transform.position = Vector3.Lerp(
            mainCamera.transform.position,
            new Vector3(transform.position.x, transform.position.y + 3, transform.position.z - 10),
            Time.deltaTime * 3.0f
        );
    }
}
