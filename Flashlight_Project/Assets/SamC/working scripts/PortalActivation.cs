using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActivation : MonoBehaviour
{
    //portals
    public GameObject nextLevelPortal;
    public GameObject CurrentLevelPortal;

    public int taskCounter = 0;
    public static int tasksToComplete = 2;


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

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10) && hit.transform.CompareTag("Objective"))
            {
                //play sound effect and animation
                taskCounter++;
            }
        } 
    }
}
