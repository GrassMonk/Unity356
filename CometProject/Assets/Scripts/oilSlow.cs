using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oilSlow : MonoBehaviour {

    private GameObject player;
    private Collider playerCol;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCol = player.GetComponent<Collider>();
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
