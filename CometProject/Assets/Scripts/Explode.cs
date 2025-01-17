using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetExplosion2 : MonoBehaviour {

	private float radius = 5.0f;
	private float magnitude = 50.0f;
	private Rigidbody target;


	public Transform explosion;    

	void Start () {	
		target = GetComponent<Rigidbody>();	
	}

	void HitByExplosiveShell( Vector3 direction )
	{
		target.AddExplosionForce (magnitude/2.0f, transform.position, radius, 0f, ForceMode.Impulse);  
		target.AddForce ( direction*magnitude, ForceMode.Impulse ); 

		Instantiate (explosion, transform.position, Quaternion.identity); 
	}

}
