using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pausemenu : MonoBehaviour
{
    public static bool paused;
    public GameObject pausemenuobj;

    public Button resume, menu, quit;

    private void Start()
    {
        resume.onClick.AddListener(resumegame);
        menu.onClick.AddListener(menugame);
        quit.onClick.AddListener(quitgame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pausemenuobj.activeInHierarchy)
        {
            pausemenuobj.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = true;
            pausemenuobj.SetActive(true);
        }
    }

    void resumegame()
    {
        pausemenuobj.SetActive(false);
        paused = false;
    }

    void menugame()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    void quitgame()
    {
        Application.Quit();
    }

    IEnumerator LoadYourAsyncScene()
    {

        Camera.main.GetComponentInChildren<fadeinout>().fadeflip = true;

        yield return new WaitForSeconds(3f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);


        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        paused = false;
        asyncLoad.allowSceneActivation = true;
    }
}
