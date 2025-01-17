﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Controller : MonoBehaviour {

    public Rigidbody rb;
    public float acceleration;
    public float maxSpeed;
    private Transform camTran;
    Vector3 movement;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        camTran = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        float speed = rb.velocity.magnitude;
        bool gyro = PlayerPrefs.GetInt("Gyro") != 0;
        float moveHorizontal, moveVertical;
        
        if (speed < maxSpeed)
        {
            if (gyro == false)
            {
                moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
                moveVertical = CrossPlatformInputManager.GetAxis("Vertical");

                movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            }
            else
            {
                movement = Quaternion.Euler(90,0,0) * (Input.acceleration);
                
               // moveVertical = Input.acceleration.y * Time.deltaTime;

            }

           

            if (movement.magnitude > 1)
                movement.Normalize();

            // rotate direction based on camera
            Vector3 dir = camTran.TransformDirection(movement);
            dir.Set(dir.x, 0, dir.z);
            dir = dir.normalized * movement.magnitude;

            rb.AddForce(dir * acceleration);
        }
    }
    /*
    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 300, 90), "Measurements");
        GUI.Label(new Rect(20, 40, 300, 20), "BALL SPEED:" + movement);
        
    }
    */
}
