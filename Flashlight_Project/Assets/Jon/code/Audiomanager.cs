using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audiomanager : MonoBehaviour
{
    public GameObject subtitlego;
    private AudioSource AS;

    public AudioClip[] Audiopool;
    public string[] Scriptpool;

    public static List<AudioClip> CurAudiolines = new List<AudioClip>();
    public static List<string> Curlines = new List<string>();

    private Text PC_subtitles;
    private int textlength;
    private string curText;
    private int letter;

    public float text_speed;
    public float change_delay;
    public float Start_delay;

    private bool playing;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
        PC_subtitles = subtitlego.GetComponent<Text>();
    }

    private void Update()
    {
        if (pausemenu.paused)
        {
            AS.Pause();
        }
        else if (!pausemenu.paused)
        {
            AS.UnPause();
        }


        if (CurAudiolines.Count > 0 && !playing)
        {
            playing = true;

            AS.clip = CurAudiolines[0];
            AS.Play();
            curText = Curlines[0];
            StartCoroutine(Textdisplay());
        }
    }

    IEnumerator Textdisplay()
    {
        yield return new WaitForSeconds(Start_delay);

        PC_subtitles.text = "";
        textlength = curText.Length;
        letter = 0;

        for (float i = 0; i < textlength; i++)
        {
            PC_subtitles.text += curText[letter];
            letter++;
            yield return new WaitForSeconds(text_speed);

            while (pausemenu.paused)
            {
                yield return null;
            }
        }

        yield return new WaitForSeconds(change_delay);

        while (pausemenu.paused)
        {
            yield return null;
        }

        StartCoroutine(next());
        StopCoroutine(Textdisplay());
        
    }

    IEnumerator next()
    {
        while (AS.isPlaying)
        {
            yield return null;
        }

        Curlines.Remove(Curlines[0]);
        CurAudiolines.Remove(CurAudiolines[0]);

        if (Curlines.Count == 0)
        {
            PC_subtitles.text = "";
            playing = false;
        }

        else
        {
            curText = Curlines[0];
            textlength = curText.Length;

            AS.clip = CurAudiolines[0];
            AS.Play();
            StartCoroutine(Textdisplay());
        }
    }

}
