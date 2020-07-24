using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class mainmenuscript : MonoBehaviour//, IPointerEnterHandler
{
    public Button play, quit, settings;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(playgame);
        quit.onClick.AddListener(quitprogram);
        settings.onClick.AddListener(settingmenu);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void playgame()
    {

    }

    void settingmenu()
    {

    }

    void quitprogram()
    {
        Application.Quit();
    }
}