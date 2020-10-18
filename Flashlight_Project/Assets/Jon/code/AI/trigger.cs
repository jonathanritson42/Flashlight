using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject spider;
    public AudioSource audioSource;

    private bool triggered, once;

    float vol = 0;

    private void Start()
    {
        spider.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (pausemenu.paused)
        {
            if (audioSource != null) audioSource.Pause();
        }
        else 
        {
            if (audioSource != null) audioSource.UnPause();
        }

        if (triggered)
        {
            triggered = false;

            if(audioSource != null) audioSource.Play();

            spider.gameObject.SetActive(true);

            if(!once && audioSource != null)  StartCoroutine(volume());

            GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>())
        {
            triggered = true;
        }
    }

    IEnumerator volume()
    {
        once = true;

        while (vol < 0.2)
        {
            audioSource.volume = vol;

            vol += 0.001f;
            yield return new WaitForSeconds(0.0001f);
        }

        StopCoroutine(volume());
    }
}
