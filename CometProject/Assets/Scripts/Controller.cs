using System.Collections;
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
            /* mobile controls code
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
            */

            // Keyboard controls
            movement = new Vector3();
            if (Input.GetKey(KeyCode.W))
            {
                movement += new Vector3(0, 0, 1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement += new Vector3(0, 0, -1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                movement += new Vector3(-1, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement += new Vector3(1, 0, 0);
            }
            if (Input.GetKey(KeyCode.E))
            {
                GameObject pwrupBtn = GameObject.Find("ActivatePowerUp");
                for (int i = 0; i < pwrupBtn.transform.childCount; i++)
                {
                    if (pwrupBtn.transform.GetChild(i).gameObject.activeSelf == true)
                    {
                        PowerUps pu = GameObject.Find("PowerUp").GetComponent<PowerUps>();
                        if (i == 0)
                            pu.PowerUp1(this.gameObject);
                        else if (i == 1)
                            pu.PowerUp2(this.gameObject);
                        else if (i == 2)
                            pu.PowerUp3(this.gameObject);
                        else if (i == 3)
                            pu.PowerUp4(this.gameObject);
                    }
                }
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
