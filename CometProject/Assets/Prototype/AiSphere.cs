using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSphere : MonoBehaviour {

    private Transform PlayerPos;
    private Rigidbody SphereBody;
    private GameObject player;
    public float speed;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        PlayerPos = player.GetComponent<Transform>();
        SphereBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 chase = PlayerPos.position - this.transform.position;
        float avoidAngle = Vector3.Angle(chase, this.transform.forward);
        float playerSpd = player.GetComponent<PlayerController>().speed;
        if (playerSpd > 0) {
            chase.y = 0;
            this.transform.rotation = Quaternion.LookRotation(chase);
            SphereBody.velocity = transform.TransformDirection(Vector3.forward * speed);
        }
    }
}
