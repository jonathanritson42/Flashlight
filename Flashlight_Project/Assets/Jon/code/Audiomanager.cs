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
        for (int i = 0; i < Curlines.Count; i++)
        {
            print(Curlines[i]);
        }

        if (CurAudiolines.Count > 0 && !playing)
        {
            playing = true;

            AS.clip = CurAudiolines[0];
            AS.Play();
            curText = Curlines[0];
            StartCoroutine(Textdisplay());
        }
        else if (CurAudiolines.Count > 0 && playing && !AS.isPlaying)
        {
            CurAudiolines.Remove(CurAudiolines[0]);
            playing = false;
        }
    }

    IEnumerator Textdisplay()
    {
        yield return new WaitForSeconds(Start_delay);

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

    void next()
    {
        Curlines.Remove(Curlines[0]);

        if (Curlines.Count == 0)
        {
            PC_subtitles.text = "";
        }

        else
        {
            curText = Curlines[0];
            textlength = curText.Length;
            letter = 0;

            StartCoroutine(Textdisplay());
        }
    }

}
