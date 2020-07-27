using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectApperance : MonoBehaviour
{
    public List<GameObject> objects;

    void CheckDistance()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (Vector3.Distance(transform.position, objects[i].transform.position) < 10)
            {
                objects[i].gameObject.SetActive(false);
            }
        }
    }


    /*public GameObject objects;

    public float distanceBetweenObjects;

    private void Update()
    {
        distanceBetweenObjects = Vector3.Distance(transform.position, objects.transform.position);
    }

    void ObjectApperance()
    {
        if (distanceBetweenObjects <= 10)
        {
            objects.gameObject.SetActive(false);
        }
        else
        {
            objects.gameObject.SetActive(true);
        }
    }*/
}
