using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    public GameObject nextLevelPortal, deleteobject;

    public static int taskCounter = 0;
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
            if(deleteobject != null) deleteobject.gameObject.SetActive(false);
        }
        taskScore.text = taskCounter + "/" + tasksToComplete;
    }
}
