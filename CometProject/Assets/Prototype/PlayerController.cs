using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f;
    public float maxSpeed = 5.0f;
    public float acc = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            speed += acc;
        if (Input.GetKey(KeyCode.S))
            speed -= acc;

        if (speed > maxSpeed)
            speed = maxSpeed;

        if (speed < -maxSpeed)
            speed = -maxSpeed;

        float mVz = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float mVx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(mVx, 0, mVz);
    }

}
