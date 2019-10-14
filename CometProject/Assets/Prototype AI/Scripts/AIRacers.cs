using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacers : MonoBehaviour
{
    public Transform target, powerUp;
    private NavMeshAgent agent;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        try
        {
            target = GameObject.Find("waypointMarker").GetComponent<Transform>();
        }
        catch (System.NullReferenceException e)
        {
            // Debug.Log(e.Message);
        }
        // agent.SetDestination( target.position ); // if the target is static
    }


    void Update()
    {
        //transform.LookAt(target);
        agent.SetDestination(target.position); // if the target can move
        //Debug.Log((target.position - agent.transform.position).magnitude); // for debugging
        AIPowerUpPickup PP = (AIPowerUpPickup)GetComponent(typeof(AIPowerUpPickup));
        PP.FindPowerUps();
        
    }

    /*
    void OnTriggerEnter (Collider collision)
    {
        if(collision.tag == "Marker")
        {
            var localVel = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
            Debug.Log(localVel);
        }
    }
    */
}
