using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamponoff : MonoBehaviour
{
    public GameObject lampshade;
    public Material replacemat;

    public bool triggered;

    private void Update()
    {
        if (triggered)
        {
            Trigger();
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
