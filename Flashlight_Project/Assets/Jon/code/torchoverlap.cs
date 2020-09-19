using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchoverlap: MonoBehaviour
{
    public static bool overlap;
    public static GameObject collisionobj;

    private void OnCollisionEnter(Collision collision)
    {
        overlap = true;
        collisionobj = collision.gameObject;
    }

    private void OnCollisionExit(Collision collision)
    {
        overlap = false;
    }
}
