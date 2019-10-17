using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacers : MonoBehaviour
{
    public Transform target, powerUp;
    private NavMeshAgent agent;
    Vector3 lastPos;
    
    int players = 8;
    
    void Start()
    {
        int noOfAI = PlayerPrefs.GetInt("AiNum");
        agent = this.GetComponent<NavMeshAgent>();
        try
        {
            for(int i = 0; i < players; i++)
            {
                if(gameObject.tag == ("racer" + i))
                {
                    target = GameObject.FindWithTag(("Marker" + i)).GetComponent<Transform>();
                }
                
            }
            
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
        try
        {
            agent.SetDestination(target.position); // if the target can move
        }
        catch (UnassignedReferenceException) { }
        //Debug.Log((target.position - agent.transform.position).magnitude); // for debugging
        AIPowerUpPickup PP = (AIPowerUpPickup)GetComponent(typeof(AIPowerUpPickup));
        PP.FindPowerUps();

    }

    
    void OnTriggerEnter (Collider collision)
    {
        for (int i = 0; i < players; i++)
        {
            if (gameObject.tag == "racer" + (i) && collision.gameObject.tag == "Marker" + (i))
            {
                lastPos = collision.transform.position;
            }
        }

        if(collision.gameObject.tag == "Respawn")
        {
            this.transform.position = lastPos;
        }
    }
    
}
