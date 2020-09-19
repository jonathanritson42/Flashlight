﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenuscript : MonoBehaviour//, IPointerEnterHandler
{
    public Button play, quit, settings;
    public GameObject settingsObj;
    public GameObject point1, point2;
    private float dist1, dist2;
    private bool cutscene, moveon;

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
        cutscene = true;
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

        if (trigger == 0)
        {
            yield return new WaitForSeconds(8);
            StartCoroutine(LoadYourAsyncScene());
        }

        if (trigger == 1) settingsObj.SetActive(true);
        if (trigger == 2) Application.Quit();
    }

    private void Update()
    {
        dist1 = Vector3.Distance(Camera.main.transform.position, point1.transform.position);
        dist2 = Vector3.Distance(Camera.main.transform.position, point2.transform.position);

        if (cutscene)
        {
            if (dist1 > 1 && !moveon)
            {
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, point1.transform.position, Time.deltaTime / 2);
                Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, point1.transform.rotation, Time.deltaTime);

            }
            else 
            {
                play.interactable = false;
                moveon = true;
            }

            if (moveon)
            {
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, point2.transform.position, Time.deltaTime / 2);
                Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, point2.transform.rotation, Time.deltaTime);

            }
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            if (dist2 < 1)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}