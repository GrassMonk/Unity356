using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Controller : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    private Transform camTran;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        camTran = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        bool gyro = PlayerPrefs.GetInt("Gyro") != 0;
        float moveHorizontal, moveVertical;
        if (gyro == false)
        {
            moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
        }
        else
        {
            moveHorizontal = Input.acceleration.x;
            moveVertical = Input.acceleration.y;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical );
        
        // rotate direction based on camera
        Vector3 dir = camTran.TransformDirection(movement);
        dir.Set(dir.x, 0, dir.z);
        dir = dir.normalized * movement.magnitude;

        rb.AddForce(dir * speed);
    }
}
