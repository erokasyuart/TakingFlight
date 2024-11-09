/// <summary>
/// Controls the player's movement and camera follow
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private float speed = 15.0f;
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
        BoundsCheck();
        PlayerMovement();
        CameraFollow();
    }

    /// <summary>
    /// Makes the camera follow the player
    /// </summary>
    private void CameraFollow()
    {
        mainCamera.transform.position = Vector3.Lerp(
            mainCamera.transform.position,
            new Vector3(transform.position.x, transform.position.y + 3, transform.position.z - 10),
            Time.deltaTime * 3.0f
        );
    }

    /// <summary>
    /// Checks if the player is out of bounds
    /// </summary>
    private void BoundsCheck()
    {
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
    }

    /// <summary>
    /// Handles the player's movement with having a gliding effect using the accelerometer
    /// </summary>
    private void PlayerMovement()
    {
        float tiltX = Mathf.Clamp(-Input.acceleration.x * tiltSenstivity, -1, 1);
        float tiltY = Mathf.Clamp(Input.acceleration.y * tiltSenstivity, -1, 1);
        float yaw = -tiltX * maxYaw;
        float pitch = tiltY * maxYaw;
        float roll = -tiltX * 10f;
        targetRotation = Quaternion.Euler(pitch, yaw, roll);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * bankSmooth);
        rb.velocity = transform.forward * speed;
    }
}
