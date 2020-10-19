﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LampState { NOTORCH, PICKEDUP, COOLDOWN, STOLEN}

public class Lamp : MonoBehaviour
{
    public LampState state;

    [Header("Variables")]
    private int mashCount = 10;
    public int mashAmount = 0;
    public Collider lightSource;
    public AudioSource lightSound;
    public Light lt;
    public bool leftKeyPushed = false;
    public bool rightKeyPushed = true;
    public GameObject lamp;

    //positions
    public GameObject player;
    public GameObject lampPosition;

    public Transform[] lampLocations;
    public Collider lightcoll;

    public float timer = 0.0f;
    public float delay;

    public GameObject UItext;

    public GameObject torchplacement;
    private GameObject clone;

    float chargetime;

    private void Start()
    {
        //state = LampState.NOTORCH;
        state = LampState.PICKEDUP;
        //lamp.transform.parent = null;
        lt.intensity = 0;
        lightSource.enabled = false;
        UItext.SetActive(false);
        chargetime = 0;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lamp") && state != LampState.PICKEDUP)
        {
            PickedUp();
        }
        if (other.gameObject.CompareTag("Enemy") && state != LampState.STOLEN)
        {
            //Stolen();
        }
    }

    public void Update()
    {
        chargetime += 0.1f;

        if(state == LampState.PICKEDUP)
        {
            if (lt.intensity == 0 && chargetime < 100)
            {
                UItext.SetActive(true);
            }
            else 
            {
                UItext.SetActive(false);
            }

            lt.intensity = Mathf.Clamp(lt.intensity, 0, 30);
            mashAmount = Mathf.Clamp(mashAmount, 0, 100);

            timer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Q) && rightKeyPushed == true)
            {
                mashAmount += mashCount;
                lt.intensity += 3;
                leftKeyPushed = true;
                rightKeyPushed = false;
                timer = 0;
                if (mashAmount >= 100)
                {
                    mashAmount = 100;
                    StartCoroutine("PowerUp");
                }
            }
            if (Input.GetKeyDown(KeyCode.E) && leftKeyPushed == true)
            {
                mashAmount += mashCount;
                lt.intensity += 3;
                leftKeyPushed = false;
                rightKeyPushed = true;
                timer = 0;
                if (mashAmount >= 100)
                {
                    mashAmount = 100;
                    StartCoroutine("PowerUp");
                }
            }
            if(timer >= delay - 5)
            {
                lt.intensity -= 3 * Time.deltaTime;
            }
        }
    }

    IEnumerator PowerUp()
    {
        StopCoroutine(CoolDown());

        //lightSource.gameObject.SetActive(true);
        while (lt.intensity != 30f)
        {
           // lt.intensity = Mathf.MoveTowards(lt.intensity, 30f, Time.deltaTime * 3);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(CoolDown());
    }

    IEnumerator CoolDown()
    {
        lightSource.enabled = true;
        enemymovement.running = true;
        yield return new WaitForSeconds(delay);
        state = LampState.COOLDOWN;
        while (lt.intensity != 0.0)
        {
            if(!pausemenu.paused) lt.intensity = Mathf.MoveTowards(lt.intensity, 0.0f, Time.deltaTime * 1);
            yield return null;
        }
        //lightSource.gameObject.SetActive(false);
        state = LampState.PICKEDUP;
        mashAmount = 0;

        enemymovement.running = false;
        lightSource.enabled = false;
    }

    void PickedUp()
    {
        //lamp.transform.parent = this.transform.parent;
        //lamp.transform.position = lampPosition.transform.position;
        lightcoll.enabled = true;
        lamp.SetActive(true);
        lt.enabled = true;
        UItext.SetActive(true);

        Destroy(clone);

        //lamp.GetComponent<flashlight>().enabled = true;

        state = LampState.PICKEDUP;
    }

    public void Stolen()
    {
        //lamp.transform.parent = null;

        //lamp.GetComponent<flashlight>().enabled = false;

        lamp.SetActive(false);
        lt.enabled = false;
        lightcoll.enabled = false;
        enemymovement.spiderrun = true;
        UItext.SetActive(false);

        clone = Instantiate(torchplacement, lampLocations[Random.Range(0, lampLocations.Length)].transform.position + new Vector3(0, -0.5f,0), new Quaternion(torchplacement.transform.rotation.x, torchplacement.transform.rotation.y, torchplacement.transform.rotation.z , torchplacement.transform.rotation.w));

        //lamp.transform.position = lampLocations[Random.Range(0, lampLocations.Length)].transform.position;
        //lamp.transform.position = new Vector3(lamp.transform.position.x, lamp.transform.position.y - 0.5f, lamp.transform.position.z + 8f);
        state = LampState.STOLEN;
    }
}
