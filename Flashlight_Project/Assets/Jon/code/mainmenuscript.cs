using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenuscript : MonoBehaviour//, IPointerEnterHandler
{
    public Button play, quit, settings;
    public GameObject settingsObj;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(playgame);
        quit.onClick.AddListener(quitprogram);
        settings.onClick.AddListener(settingmenu);

        settingsObj.SetActive(false);
    }

    void playgame()
    {
        settings.interactable = false;
        quit.interactable = false;

        StartCoroutine(delay(0));
    }

    void settingmenu()
    {
        play.interactable = false;
        settings.interactable = false;
        quit.interactable = false;

        StartCoroutine(delay(1));
    }

    void quitprogram()
    {
        play.interactable = false;
        settings.interactable = false;

        StartCoroutine(delay(2));
    }

    IEnumerator delay(int trigger)
    {
        yield return new WaitForSeconds(2);

        if(trigger == 0) SceneManager.LoadScene(1);
        if (trigger == 1) settingsObj.SetActive(true);
        if (trigger == 2) Application.Quit();
    }
}