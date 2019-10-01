using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Controller : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    float dirX;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
        //float moveHorizontal = Input.acceleration.x;
        //float moveVertical = Input.acceleration.y;

        Vector3 movement = new Vector3(moveVertical, 0.0f, -moveHorizontal);

        rb.AddForce(movement * speed);
    }
}
