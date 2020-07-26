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

    // Update is called once per frame
    void Update()
    {

    }

    void playgame()
    {
        quit.animator.SetTrigger("Disabled");
        settings.animator.SetTrigger("Disabled");

        SceneManager.LoadScene(1);
    }

    void settingmenu()
    {
        play.animator.SetTrigger("Disabled");
        settings.animator.SetTrigger("Disabled");
        quit.animator.SetTrigger("Disabled");

        settingsObj.SetActive(true);
    }

    void quitprogram()
    {
        play.animator.SetTrigger("Disabled");
        settings.animator.SetTrigger("Disabled");

        Application.Quit();
    }
}