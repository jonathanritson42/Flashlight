using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fadeinout : MonoBehaviour
{
    public float startfadeindelay;
    private Image white;
    private float alpha;

    public bool fadeflip, MM;
    private bool once;

    public Text subtitles;

    // Start is called before the first frame update
    void Start()
    {
        white = GetComponent<Image>();
        white.color = new Color(255, 255, 255, 1);
        alpha = 1;
        StartCoroutine(fadeinstart());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeflip)
        {
            once = true;
            StartCoroutine(fadein());
        }
        else if(once)
        {
            StartCoroutine(fadeout());
        }
    }

    IEnumerator fadeinstart()
    {
        subtitles.color = Color.white;

        if (!MM) GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;

        yield return new WaitForSeconds(startfadeindelay);

        if (!MM) GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;

        while (white.color.a > 0)
        {
            white.color = new Color(255, 255, 255, alpha);

            alpha -= 0.01f;

            yield return new WaitForSeconds(0.00001f);

        }
    }

    IEnumerator fadein()
    {
        subtitles.color = Color.black;

        alpha = 0;

        while (white.color.a < 1)
        {
            white.color = new Color(255, 255, 255, alpha);

            alpha += 0.005f;

            yield return new WaitForSeconds(0.00001f);

        }

        if (!MM) GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
    }

    IEnumerator fadeout()
    {
        subtitles.color = Color.white;


        alpha = 1;

        while (white.color.a > 0)
        {
            white.color = new Color(255, 255, 255, alpha);

            alpha -= 0.005f;

            yield return new WaitForSeconds(0.00001f);

        }
    }

    public IEnumerator fadeandLoadAsyncScene()
    {
        subtitles.color = Color.black;

        alpha = 0;

        while (white.color.a < 1)
        {
            white.color = new Color(255, 255, 255, alpha);

            alpha += 0.02f;

            yield return new WaitForSeconds(0.00001f);

        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        print("next");
    }

    public IEnumerator fadeandLoadAsyncDeath()
    {
        subtitles.color = Color.black;

        alpha = 0;

        while (white.color.a < 1)
        {
            white.color = new Color(255, 255, 255, alpha);

            alpha += 0.02f;

            yield return new WaitForSeconds(0.00001f);

        }

        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

}
