using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class enemymovement : MonoBehaviour
{
    public bool patrol, patrolloop, navmesh;
    public float speed;
    public GameObject body;
    public GameObject[] Goto_points;
    private NavMeshAgent agent;
    private GameObject player;
    private int pointno;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponentInChildren<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (!patrol)
        {
            if (navmesh)
            {
                agent.SetDestination(player.transform.position);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, player.transform.position, speed);
                transform.LookAt(player.transform);
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
                agent.SetDestination(Goto_points[pointno].transform.position);
            }
            else 
            {
                var lookPos = Goto_points[pointno].transform.position - transform.position;
                lookPos.x = 0;
                transform.rotation = Quaternion.LookRotation(lookPos);
                transform.position = Vector3.Lerp(transform.position, Goto_points[pointno].transform.position, speed);
            }
        }
    }
}
