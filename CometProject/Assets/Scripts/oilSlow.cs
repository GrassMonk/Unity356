using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OilSlow : MonoBehaviour {
    
    private void OnTriggerEnter(Collider playerCol)
    {
        if (playerCol.gameObject.tag == "Player")
        {
            Rigidbody rb = playerCol.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(-rb.velocity * 50.0f);
        }
        else if (playerCol.gameObject.tag == "racer0" ||
            playerCol.gameObject.tag == "racer1" ||
            playerCol.gameObject.tag == "racer2" ||
            playerCol.gameObject.tag == "racer3" ||
            playerCol.gameObject.tag == "racer4" ||
            playerCol.gameObject.tag == "racer5" ||
            playerCol.gameObject.tag == "racer6" ||
            playerCol.gameObject.tag == "racer7")
        {
            Rigidbody rb = playerCol.gameObject.GetComponent<Rigidbody>();
            Vector3 vel = playerCol.gameObject.GetComponent<NavMeshAgent>().velocity;
            rb.AddForce(-vel * 50.0f);
        }
    }

    private void OnTriggerExit(Collider playerCol) // destroy on exit
    {
        if (playerCol.gameObject.tag == "Player" ||
            playerCol.gameObject.tag == "racer0" ||
            playerCol.gameObject.tag == "racer1" ||
            playerCol.gameObject.tag == "racer2" ||
            playerCol.gameObject.tag == "racer3" ||
            playerCol.gameObject.tag == "racer4" ||
            playerCol.gameObject.tag == "racer5" ||
            playerCol.gameObject.tag == "racer6" ||
            playerCol.gameObject.tag == "racer7")
            Destroy(gameObject);
    }
}
