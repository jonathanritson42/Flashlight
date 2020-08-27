using DitzelGames.FastIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymoveleg : MonoBehaviour
{
    public GameObject[] legppoints, legtargets, legbonepoints;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < legbonepoints.Length; i++)
        {
            legtargets[i].transform.position = legppoints[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
