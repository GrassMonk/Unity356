using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamFix : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        GameObject.Find("BumpSound").GetComponent<AudioSource>().mute = true;
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GameObject.Find("BumpSound").GetComponent<AudioSource>().mute = false;
    }
}
