using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPowerUpPickup : MonoBehaviour {

    public float radius;
    [Range(0,360)]
    public float angle;

    public LayerMask PowerUp;
    public LayerMask obstacle;

    [HideInInspector]
    public List<Transform> PowerUps = new List<Transform>();

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("FindPowerUpsWithDelay", .2f);
    }

    IEnumerator FindPowerUpsWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindPowerUps();
        }
    }

    public void FindPowerUps()
    {
        PowerUps.Clear();
        Collider[] ValidPowerUps = Physics.OverlapSphere(transform.position, radius, PowerUp);

        for (int i = 0; i < ValidPowerUps.Length; i++)
        {
            Transform Power = ValidPowerUps[i].transform;
            Vector3 PowerUpDir = (Power.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, PowerUpDir) < angle / 2)
            {
                float dist = Vector3.Distance(transform.position, Power.position);
                if (Power.tag == "Power" && !Physics.Raycast(transform.position, PowerUpDir, dist, obstacle))
                {
                    agent.SetDestination(Power.position);
                    PowerUps.Add(Power);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if(!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
