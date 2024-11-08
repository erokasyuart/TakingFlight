/// <summary>
/// This script is used to control the player's movement on mobile devices using the accelerometer.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileTilt : MonoBehaviour
{
    //rotate on the z axis based on the tilt
    public float speed = 20.0f;
    public float zRange = 40.0f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        zRange = Input.acceleration.x * speed;
        transform.localRotation = Quaternion.Euler(0, 0, -zRange);
    }

}
