using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    bool power = false;
	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerController>().maxSpeed = 10f;
            collision.gameObject.GetComponent<PlayerController>().acc = 1f;
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.tag == "AI") {
            collision.gameObject.GetComponent<AiSphere>().speed = 10f;
            Destroy(this.gameObject);
        }
    }
}
