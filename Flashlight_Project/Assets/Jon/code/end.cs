using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{

    bool once;
    float dist;

    public GameObject trigger;

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.gameObject.transform.position, Camera.main.transform.position);

        if (dist > 10 && !once)
        {
            once = true;

            StartCoroutine(doorbell());
        }

        if (once && dist < 2)
        {
            once = false;
            Camera.main.GetComponentInChildren<fadeinout>().fadeflip = true;
            trigger.SetActive(true);

            StartCoroutine(menu());
        }
    }

    IEnumerator doorbell()
    {
        while (once)
        {
            GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(Random.Range(3, 12));
        }
    }

    IEnumerator menu()
    {
        while (Audiomanager.CurAudiolines.Count > 1)
        {
            yield return null;
        }

        yield return new WaitForSeconds(20);

        SceneManager.LoadScene(0);

    }
}
