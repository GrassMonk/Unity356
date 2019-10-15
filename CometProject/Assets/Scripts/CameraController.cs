using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 camDir;
    public float cameraStickiness = 10.0f;
    public float cameraRotationSpeed = 5.0f;

    // Update is called once per frame
    void FixedUpdate ()
    {
        Vector3 lookAtThis;
        camDir = Vector3.Normalize(player.GetComponent<Rigidbody>().velocity) * 5;
        camDir.y = -2.0f;
        if (camDir.x == 0)
        {
            camDir.x = 5;
        }
        lookAtThis = player.transform.position;
        lookAtThis.y += 2f;
        lookAtThis -= camDir;
        transform.position = Vector3.Slerp(transform.position, lookAtThis, cameraStickiness * Time.fixedDeltaTime); ;
        Quaternion lookRotation = Quaternion.LookRotation(camDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, cameraRotationSpeed*Time.deltaTime);
	}
}
