using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamponoff : MonoBehaviour
{
    public GameObject lampshade;
    public Material replacemat;

    public bool triggered, portal;

    private void Update()
    {
        if (triggered && !portal)
        {
            Trigger();
        }

        if (triggered && portal)
        {
            GetComponent<Collider>().isTrigger = true;
        }
    }

    private void Trigger()
    {
        Light[] lights;

        lights = GetComponentsInChildren<Light>();

        foreach (Light lighting in lights)
        {
            lighting.enabled = false;
        }

        lampshade.GetComponent<MeshRenderer>().material = replacemat;
    }
}
