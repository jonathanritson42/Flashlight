
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oldtexttrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject subtitlego;
    public AudioClip[] audiolines;
    public string[] Subtitles;
    private int subpos;

    private int curaudioline;
    private bool once;

    private Text PC_subtitles;
    private int textlength;
    private string curText;

    public float text_speed = 0.1f;

    public float change_delay = 0.1f;

    public float Start_delay = 0;

    private int letter;

    public GameObject[] prevtext;       // delete old trigger if not finnished.

    private void Awake()
    {
        PC_subtitles = subtitlego.GetComponent<Text>();
        subpos = 0;

        PC_subtitles.text = "";
    }

    private void Update()
    {
        //print(curaudioline);
        //print(once);

        if (!audioSource.isPlaying && curaudioline - 1 < audiolines.Length && once == true)
        {
            curaudioline++;
            audioSource.clip = audiolines[curaudioline];
            audioSource.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (once == true)
        {
            StopAllCoroutines();
            Destroy(this.gameObject);
        }

        if (other.gameObject.name == "PC" || other.gameObject.tag == "Player")
        {
            StopCoroutine(Textdisplay());
            audioSource.Stop();

            if (prevtext.Length > 0)
            {
                for (int i = 0; i < prevtext.Length; i++)
                {
                    if (prevtext[i] != null)
                    {
                        Destroy(prevtext[i]);
                    }
                }
            }

            curText = Subtitles[subpos];
            this.gameObject.GetComponent<Collider>().enabled = false;

            textlength = curText.Length;

            PC_subtitles.text = "";

            letter = 0;

            subpos = 0;
            curaudioline = 0;

            audioSource.clip = audiolines[curaudioline];

            StartCoroutine(Textdisplay());
        }
    }

    IEnumerator Textdisplay()
    {
        yield return new WaitForSeconds(Start_delay);

        audioSource.Play();

        once = true;

        PC_subtitles.text = "";

        for (float i = 0; i < textlength; i++)
        {
            PC_subtitles.text += curText[letter];
            letter++;
            yield return new WaitForSeconds(text_speed);
        }

        yield return new WaitForSeconds(change_delay);

        next();
        StopCoroutine(Textdisplay());
    }

    IEnumerator End()
    {

        yield return new WaitForSeconds(change_delay);

        yield return new WaitForSeconds(1);  // change this dependednt on usecase

        PC_subtitles.text = "";

        letter = 0;
        subpos = 0;
        once = false;

        Destroy(this.gameObject);

        StopCoroutine(End());
    }

    void next()
    {
        subpos++;

        if (subpos == Subtitles.Length)
        {
            StartCoroutine(End());
        }

        else
        {
            curText = Subtitles[subpos];
            textlength = curText.Length;
            letter = 0;

            StartCoroutine(Textdisplay());
        }
    }
}
