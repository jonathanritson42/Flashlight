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

    public bool fadeflip;
    private bool once;
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
        yield return new WaitForSeconds(startfadeindelay);

        while (white.color.a != 0)
        {
            white.color = new Color(255, 255, 255, alpha);

            alpha -= 0.01f;

            yield return new WaitForSeconds(0.00001f);

        }
    }

    IEnumerator fadein()
    {
        alpha = 0;

        while (white.color.a != 1)
        {
            white.color = new Color(255, 255, 255, alpha);

            alpha += 0.005f;

            yield return new WaitForSeconds(0.00001f);

        }
    }
    IEnumerator fadeout()
    {
        alpha = 1;

        while (white.color.a != 0)
        {
            white.color = new Color(255, 255, 255, alpha);

            alpha -= 0.005f;

            yield return new WaitForSeconds(0.00001f);

        }
    }

    public IEnumerator fadeandLoadAsyncScene()
    {
        alpha = 0;

        while (white.color.a != 1)
        {
            white.color = new Color(255, 255, 255, alpha);

            alpha += 0.02f;

            yield return new WaitForSeconds(0.00001f);

        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        while (!asyncLoad.isDone)
        {
            asyncLoad.allowSceneActivation = true;

            yield return null;
        }
    }

    public IEnumerator fadeandLoadAsyncDeath()
    {
        alpha = 0;

        while (white.color.a != 1)
        {
            white.color = new Color(255, 255, 255, alpha);

            alpha += 0.02f;

            yield return new WaitForSeconds(0.00001f);

        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        while (!asyncLoad.isDone)
        {
            asyncLoad.allowSceneActivation = true;

            yield return null;
        }
    }

}
