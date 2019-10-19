using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float speed = 1f;
    public float dist = 3f;
    private float randomOffset;
    Vector3 pos;
	// Use this for initialization
	void Start () {
        randomOffset = Random.Range(0f, 2f);
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        pos.z = Mathf.Sin(Time.time * speed + randomOffset) * dist;
        transform.position = pos;
	}
}
