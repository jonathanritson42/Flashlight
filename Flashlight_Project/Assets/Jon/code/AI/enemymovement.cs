using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemymovement : MonoBehaviour
{
    public bool patrol, navmesh, speedonplayerdist;
    public float notnavspeed;
    public GameObject body, player;
    public GameObject[] Goto_points;
    private NavMeshAgent agent;
    private int pointno;
    public static bool spiderrun, spidercatch, running;
    private float navmeshspeed;
    public Collider torchbounds;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        navmeshspeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (pausemenu.paused)
        {
            agent.isStopped = true;
            GetComponentInChildren<AudioSource>().Pause();
            return;
        }
        else 
        {
            agent.isStopped = false;
            GetComponentInChildren<AudioSource>().UnPause();

        }

        if (spidercatch)
        {
            agent.speed = navmeshspeed * 2;
            GameObject clone = GameObject.FindGameObjectWithTag("clonetorch");
            agent.SetDestination(clone.transform.position);
        }
        else
        {
            agent.speed = navmeshspeed;
        }

        if (running)
        {
            agent.speed = navmeshspeed * 2;
            agent.SetDestination(Goto_points[0].transform.position);
        }
        else
        {
            agent.speed = navmeshspeed;
        }

        if (!patrol && !spidercatch && !running)
            {
                if (navmesh)
                {
                    if (spiderrun && !spidercatch)
                    {
                        float dist = Vector3.Distance(body.transform.position, Camera.main.transform.position);

                        if (dist > 0.1f)
                        {
                            agent.speed = navmeshspeed * 2;
                            agent.SetDestination(Camera.main.transform.position);
                        }
                        else
                        {
                            agent.speed = navmeshspeed;
                            spiderrun = false;
                        }
                    }
                    else if (!spidercatch)
                    {
                        float dist = Vector3.Distance(body.transform.position, player.transform.position);

                        if (speedonplayerdist) agent.speed = dist; agent.acceleration = dist;

                        if (dist > 2f) agent.SetDestination(player.transform.position);

                        body.transform.position = this.transform.position;      // just in case
                        body.transform.rotation = this.transform.rotation;
                    }
                }
                else if(!spidercatch)
                {
                    transform.position = Vector3.Lerp(transform.position, player.transform.position, notnavspeed);

                    body.transform.position = this.transform.position;      // just in case
                    body.transform.rotation = this.transform.rotation;

                }
        }

        else if (!spidercatch && !running)
        {
                if (pointno == Goto_points.Length)
                {
                    Destroy(this.gameObject);
                    Destroy(this);

                }
                else
                {
                    float dist = Vector3.Distance(body.transform.position, Goto_points[pointno].transform.position);

                    if (dist <= 4)       // Distance to point before moving on.
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

        if (running)
        {
            agent.SetDestination(Goto_points[0].transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "clonetorch")
        {
            spidercatch = false;
        }

        if (other.gameObject.tag == "Player" && other.gameObject.GetComponentInParent<Lamp>().state == LampState.STOLEN)
        {
            other.gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            StartCoroutine(Camera.main.GetComponentInChildren<fadeinout>().fadeandLoadAsyncDeath());
        }

        if (other == player.GetComponent<BoxCollider>())
        {
            spidercatch = true;
            other.GetComponentInParent<Lamp>().Stolen();
        }

        if (other.gameObject.name == "spiderpoint")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other == torchbounds)
        {
            running = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == torchbounds)
        {
            running = false;
        }
    }
}
