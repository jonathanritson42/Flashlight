﻿using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class enemymovement : MonoBehaviour
{
    public bool patrol, navmesh, speedonplayerdist;
    public float notnavspeed;
    public GameObject body, player;
    public GameObject[] Goto_points;
    private NavMeshAgent agent;
    private int pointno;
    public static bool spiderrun;
    public GameObject torch;
    private float navmeshspeed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        navmeshspeed = agent.speed;

    }

    // Update is called once per frame
    void Update()
    {        
        if (!patrol)
        {
            if (navmesh)
            {
                if (spiderrun)
                {
                    float dist = Vector3.Distance(body.transform.position, torch.transform.position);

                    if (dist > 0.1f)
                    {
                        agent.speed = navmeshspeed * 2;
                        agent.SetDestination(torch.transform.position);
                    }
                    else
                    {
                        agent.speed = navmeshspeed;
                        spiderrun = false;
                    }
                }
                else 
                {
                    float dist = Vector3.Distance(body.transform.position, player.transform.position);

                    if (speedonplayerdist) agent.speed = dist; agent.acceleration = dist;

                    if (dist > 2f) agent.SetDestination(player.transform.position);

                    body.transform.position = this.transform.position;      // just in case
                    body.transform.rotation = this.transform.rotation;
                }
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
            if (pointno == Goto_points.Length)
            {
                Destroy(this.gameObject);
                Destroy(this);

            }
            else
            {
                float dist = Vector3.Distance(body.transform.position, Goto_points[pointno].transform.position);

                if (dist <= 1)       // Distance to point before moving on.
                {
                    if (pointno < Goto_points.Length)
                    {
                        pointno++;
                    }

                }

                //if(pointno > (Goto_points.Length - 1))
                //{
                //    pointno = 0;
                //}

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
}
