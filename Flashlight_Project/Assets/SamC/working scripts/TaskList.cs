using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    public GameObject nextLevelPortal;

    public int taskCounter = 0;
    public static int tasksToComplete = 1;

    public Text taskScore;


    private void Start()
    {
        nextLevelPortal.gameObject.SetActive(false);
        taskCounter = 0;
        tasksToComplete += 1;
    }

    void Update()
    {
        if (taskCounter == tasksToComplete)
        {
            nextLevelPortal.gameObject.SetActive(true);
        }
        taskScore.text = taskCounter + "/" + tasksToComplete;
    }
}
