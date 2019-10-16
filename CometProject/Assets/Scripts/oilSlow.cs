using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSlow : MonoBehaviour {

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider playerCol)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.AddForce(-rb.velocity * 50.0f);
    }

    private void OnTriggerExit(Collider playerCol) // destroy on exit
    {
        Destroy(gameObject);
    }
}
