using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampStealing : MonoBehaviour
{

    public Transform[] lampLocations;

    private GameObject lamp;

    //use this to start lamp cooldown in other script
    public bool lampStolen;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit player");
            lampStolen = true;
            lamp = GameObject.Find("Lamp");
            lamp.transform.parent = null;
            lamp.transform.position = lampLocations[Random.Range(0,lampLocations.Length)].transform.position;
            Debug.Log(lamp.transform.position);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //if()
            lampStolen = false; 
        }
    }
}
