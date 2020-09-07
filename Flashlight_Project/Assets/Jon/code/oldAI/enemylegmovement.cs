using DitzelGames.FastIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemylegmovement : MonoBehaviour
{
    public GameObject[] legppoints, legtargets, legbonepoints;
    private float[] legdist;
    public float legmovedist;
    private GameObject[] temporaryposition = new GameObject[] {};
    private GameObject[] legoriginpoints = new GameObject[] { };

    public AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        temporaryposition = new GameObject[legbonepoints.Length];
        legoriginpoints = new GameObject[legtargets.Length];

        for (int i = 0; i < legbonepoints.Length; i++)
        {
            legtargets[i].transform.position = legppoints[i].transform.position;
            temporaryposition[i] = new GameObject("Temp_legpos" + i);
            temporaryposition[i].transform.position = legtargets[i].transform.position;

            legoriginpoints[i] = new GameObject("Leg_originpoint" + i);
            legoriginpoints[i].transform.position = legtargets[i].transform.position;
            legoriginpoints[i].transform.parent = this.gameObject.transform;
        }

        legdist = new float[legbonepoints.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < legdist.Length; i++)
        {
            legdist[i] = Vector3.Distance(legppoints[i].transform.position, legtargets[i].transform.position);

            if (legdist[i] > Random.Range((legmovedist/3), (legmovedist*3))) // distance
            {
                //legppoints[i].transform.position = Vector3.Lerp(legppoints[i].transform.position, legtargets[i].transform.position, Time.deltaTime * 10);     // Jellyfish mode

                //legppoints[i].transform.position = legtargets[i].transform.position;      // old version

                temporaryposition[i].transform.position = legtargets[i].transform.position;
                AS.Play();
            }
        }

        for (int i = 0; i < legppoints.Length; i++)
        {
            legppoints[i].transform.position = Vector3.Lerp(legppoints[i].transform.position, temporaryposition[i].transform.position, Time.deltaTime * 20);
            legtargets[i].transform.position = Vector3.Lerp(legtargets[i].transform.position, legoriginpoints[i].transform.position, Time.deltaTime * 20);
        }
    }
}
