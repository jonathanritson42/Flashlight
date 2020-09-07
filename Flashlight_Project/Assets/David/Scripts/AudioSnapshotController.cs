using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSnapshotController : MonoBehaviour
{
    public AudioMixerSnapshot Indoors;
    public AudioMixerSnapshot Outdoors;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Indoors.TransitionTo(0.8f);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Outdoors.TransitionTo(0.8f);
        }
    }
}
