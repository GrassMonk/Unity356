using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PowerUp : MonoBehaviour {

    public bool power = true;
    void OnTriggerEnter(Collider collision)
    {
        /*
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<PlayerController>().maxSpeed = 10f;
            collision.gameObject.GetComponent<PlayerController>().acc = 1f;
            
        }
        */

        if (collision.gameObject.tag == "racer1" || collision.gameObject.tag == "racer2" || collision.gameObject.tag == "racer3" || collision.gameObject.tag == "racer4")
        {
            power = false;
            collision.gameObject.GetComponent<NavMeshAgent>().acceleration += 10f;
        }
        Destroy(this.gameObject);
    }
}
