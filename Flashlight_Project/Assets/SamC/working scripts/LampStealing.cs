using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampStealing : MonoBehaviour
{

    public Transform[] lampLocations;

    public GameObject lamp;

    //use this to start lamp cooldown in other script
    public bool lampStolen;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit player");
            lampStolen = true;
            lamp.transform.parent = null;
            lamp.transform.position = lampLocations[Random.Range(0,lampLocations.Length)].transform.position;
            Debug.Log(lamp.transform.position);
            Debug.Log(lampStolen);
        }
    }
}
