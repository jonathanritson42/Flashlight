using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voicelines : MonoBehaviour
{
    public GameObject AudioMan;

    public int[] Audiopoollines;
    public int[] Scriptpoollines;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            GetComponent<Collider>().enabled = false;

            for (int i = 0; i < Audiopoollines.Length; i++)
            {
                Audiomanager.CurAudiolines.Add(AudioMan.GetComponent<Audiomanager>().Audiopool[Audiopoollines[i]]);
            }

            for (int i = 0; i < Scriptpoollines.Length; i++)
            {
                Audiomanager.Curlines.Add(AudioMan.GetComponent<Audiomanager>().Scriptpool[Scriptpoollines[i]]);
            }

            Destroy(this.gameObject);
        }
    }
}
