using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public AudioClip[] Audiopool;

    public void Playsound(int poolnumber, float volume, float spaceblend)
    {
        GameObject go = new GameObject("Audio: " + Audiopool[poolnumber].name);
        go.transform.position = this.transform.position;
        go.transform.parent = this.transform;

        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = Audiopool[poolnumber];
        source.volume = volume;
        source.spatialBlend = spaceblend;
        source.Play();
        Destroy(go, Audiopool[poolnumber].length);
    }


    //        GameObject.FindGameObjectWithTag("Player").transform.GetComponentInChildren<Audiomanager>().Playsound(0, 0.2f, 0);        // Use this as an example for using the audio manager

}
