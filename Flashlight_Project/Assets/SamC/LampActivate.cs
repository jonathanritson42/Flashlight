using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampActivate : MonoBehaviour
{
    private int mashCount = 10;
    public int mashAmount = 0;

    public GameObject lightSource;
    public AudioSource lightSound;

    private void Start()
    {
        lightSource.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            mashAmount += mashCount;
            Debug.Log(mashAmount);
        }
        if(mashAmount >= 100)
        {
            mashAmount = 100;
            lightSource.gameObject.SetActive(true);
            StartCoroutine(CoolDown());
        }
    }


    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(10.0f);
        mashAmount = 0;
        lightSource.gameObject.SetActive(false);
        //Debug.Log("True");
    }

}
