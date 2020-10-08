using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    public GameObject nextLevelPortal;

    public int taskCounter = 0;
    public int tasksToComplete;

    public Text taskScore;


    private void Start()
    {
        nextLevelPortal.gameObject.SetActive(false);
        taskCounter = 0;
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
