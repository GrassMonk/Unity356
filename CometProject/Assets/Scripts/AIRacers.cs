using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacers : MonoBehaviour
{
    public Transform target, powerUp;
    private NavMeshAgent agent;
    Vector3 lastPos;
    private float acc; 

    private int players;
    private int mass;
    
    void Start()
    {
        mass = PlayerPrefs.GetInt("Mass");
        players = PlayerPrefs.GetInt("AiNum");
        agent = this.GetComponent<NavMeshAgent>();

        try // sets the target for each AI depending on their tag
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
        try // sets acceleration values depending on selected mass of the player
        {
            switch(mass)
            {
                case 1:
                    if (this.gameObject.name == "StrongAI(Clone)")
                    {
                        agent.acceleration = Random.Range(7.5f, 14f);
                    }
                    else if (this.gameObject.name == "WeakAI(Clone)")
                    {
                        agent.acceleration = Random.Range(5, 14f);
                    }
                    break;
                case 2:
                    if (this.gameObject.name == "StrongAI(Clone)")
                    {
                        agent.acceleration = Random.Range(5f, 12f);
                    }
                    else if (this.gameObject.name == "WeakAI(Clone)")
                    {
                        agent.acceleration = Random.Range(2.5f, 12f);
                    }
                    break;
                case 3:
                    if (this.gameObject.name == "StrongAI(Clone)")
                    {
                        agent.acceleration = Random.Range(4f, 10f);
                    }
                    else if (this.gameObject.name == "WeakAI(Clone)")
                    {
                        agent.acceleration = Random.Range(2.5f, 10f);
                    }
                    break;
            }
            agent.SetDestination(target.position); // if the target can move
            
        }
        catch (UnassignedReferenceException) { }
        //Debug.Log((target.position - agent.transform.position).magnitude); // for debugging
        AIPowerUpPickup PP = (AIPowerUpPickup)GetComponent(typeof(AIPowerUpPickup));
        PP.FindPowerUps();
    }

    // respawn AI racers
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
