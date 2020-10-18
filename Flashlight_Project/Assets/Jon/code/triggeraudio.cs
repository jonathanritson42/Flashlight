using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeraudio : MonoBehaviour
{
    public GameObject audiosource;

    private void OnTriggerEnter(Collider other)
    {
        audiosource.GetComponent<AudioSource>().Play();
        Destroy(this);
    }
}
