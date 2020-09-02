using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActivation : MonoBehaviour
{
    //portals
    public GameObject nextLevelPortal;
    public GameObject CurrentLevelPortal;

    public int taskCounter = 0;
    public int tasksToComplete = 2;


    private void Start()
    {
        nextLevelPortal.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (taskCounter == tasksToComplete)
        {
            nextLevelPortal.gameObject.SetActive(true);
            CurrentLevelPortal.gameObject.SetActive(false);
            taskCounter = 0;
            tasksToComplete += 1;
        }
    }
}
