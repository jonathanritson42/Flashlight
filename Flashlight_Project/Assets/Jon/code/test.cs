using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private void Update()
    {
        GameObject.FindGameObjectWithTag("Player").transform.GetComponentInChildren<Audiomanager>().Playsound(0, 0.2f, 0);
    }
}
