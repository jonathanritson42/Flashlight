using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public GameObject torchpoint;
    public float delaySpeed;
    private float dist;
    public bool usedelay;

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, torchpoint.transform.position);

        if (usedelay)
        {
            // Based on set speed rather than delay
            this.transform.position = Vector3.Lerp(this.transform.position, torchpoint.transform.position, Time.deltaTime * delaySpeed);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, torchpoint.transform.rotation, Time.deltaTime * delaySpeed);
        }
        else
        {
            // Based on distance rather than a set speed of delay
            this.transform.position = Vector3.Lerp(this.transform.position, torchpoint.transform.position, Time.deltaTime * (dist / 2));
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, torchpoint.transform.rotation, Time.deltaTime * (dist / 2));
        }
    }
}