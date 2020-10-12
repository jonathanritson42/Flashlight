using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject spider;
    public AudioSource AS;

    private bool triggered;

    private void Start()
    {
        spider.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (triggered)
        {
            triggered = false;

            AS.Play();

            StartCoroutine(volume());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            spider.gameObject.SetActive(true);

            if (AS == null) Destroy(this.gameObject);

            triggered = true;

            GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator volume()
    {
        float vol = 0;

        while (vol < 0.2)
        {
            AS.volume = vol;

            vol += 0.001f;
            yield return new WaitForSeconds(0.0001f);

        }
    }
}
