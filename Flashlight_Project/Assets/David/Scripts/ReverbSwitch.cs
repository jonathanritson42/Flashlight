using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbSwitch : MonoBehaviour
{
    public int ReverbZone;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<LocalAudioController>().SwitchReverb(ReverbZone);
        }
    }



}
