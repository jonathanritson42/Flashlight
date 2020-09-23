using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class enemymovement : MonoBehaviour
{
    public bool patrol, patrolloop, navmesh, speedonplayerdist;
    public float notnavspeed;
    public GameObject body, player;
    public GameObject[] Goto_points;
    private NavMeshAgent agent;
    private int pointno;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (!patrol)
        {
            if (navmesh)
            {
                float dist = Vector3.Distance(body.transform.position, player.transform.position);

                if (speedonplayerdist) agent.speed = dist; agent.acceleration = dist;

                agent.SetDestination(player.transform.position);

                body.transform.position = this.transform.position;      // just in case
                body.transform.rotation = this.transform.rotation;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, player.transform.position, notnavspeed);

                body.transform.position = this.transform.position;      // just in case
                body.transform.rotation = this.transform.rotation;

            }
        }
        else
        {
            float dist = Vector3.Distance(body.transform.position, Goto_points[pointno].transform.position);

            if (dist <= 5)       // Distance to point before moving on.
            {
                pointno++;
            }

            if(pointno > (Goto_points.Length - 1))
            {
                pointno = 0;
            }

            if (navmesh)
            {
                float playerdist = Vector3.Distance(body.transform.position, player.transform.position);

                if (speedonplayerdist) agent.speed = playerdist;

                agent.SetDestination(Goto_points[pointno].transform.position);
            }
            else 
            {
                var lookPos = Goto_points[pointno].transform.position - transform.position;
                lookPos.x = 0;
                transform.rotation = Quaternion.LookRotation(lookPos);
                transform.position = Vector3.Lerp(transform.position, Goto_points[pointno].transform.position, notnavspeed);
            }
        }
    }
}
