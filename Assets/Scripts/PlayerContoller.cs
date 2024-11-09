using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private float speed = 15.0f;
    //public float zRange = 40.0f;
    private float turnSpeed = 25.0f;
    private float tiltSenstivity = 25.0f;
    private Quaternion targetRotation;
    private Rigidbody rb;
    [SerializeField]private Camera mainCamera;

    private float maxYaw = 30.0f;
    private float bankSmooth = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetRotation = transform.rotation;
    }

    void Update()
    {
        //zRange = Input.acceleration.x * speed;

        if (transform.position.y < 30)
        {
            GoalManager.Instance.ShowScore("TOO BAD", "You got too low to the ground!");
        }
        else if (transform.position.y > 70)
        {
            GoalManager.Instance.ShowScore("TOO BAD", "You flew too close to the sun!");
        }
        else if (transform.position.x < -40 || transform.position.x > 40)
        {
            GoalManager.Instance.ShowScore("TOO BAD", "You flew too far off course!");
        }

        float tiltX = Mathf.Clamp(-Input.acceleration.x * tiltSenstivity, -1, 1);
        float tiltY = Mathf.Clamp(Input.acceleration.y * tiltSenstivity, -1, 1);
        float yaw = -tiltX * maxYaw;
        float pitch = tiltY * maxYaw;
        float roll = -tiltX * 10f;

        targetRotation = Quaternion.Euler(pitch, yaw, roll);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * bankSmooth);
        
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
