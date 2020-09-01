using DitzelGames.FastIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemylegmovement : MonoBehaviour
{
    public GameObject[] legppoints, legtargets, legbonepoints;
    private float[] legdist;
    public float legmovedist;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < legbonepoints.Length; i++)
        {
            legtargets[i].transform.position = legppoints[i].transform.position;
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

                legppoints[i].transform.position = legtargets[i].transform.position;
            }
        }
    }
}
