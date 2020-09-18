using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampActivate : MonoBehaviour
{
    private int mashCount = 10;
    public int mashAmount = 0;

    public GameObject lightSource;
    public AudioSource lightSound;

    public Light lt;

    public bool leftKeyPushed = false;
    public bool rightKeyPushed = true;

    public GameObject enemyGO;
    LampStealing lampSteal;

    private GameObject player;
    public GameObject lampPosition;


    private void Start()
    {
        lightSource.gameObject.SetActive(false);
        lampSteal = enemyGO.GetComponent<LampStealing>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && rightKeyPushed == true)
        {
            mashAmount += mashCount;
            leftKeyPushed = true;
            rightKeyPushed = false;
        }
        if (Input.GetKeyDown(KeyCode.X) && leftKeyPushed == true)
        {
            mashAmount += mashCount;
            leftKeyPushed = false;
            rightKeyPushed = true;
            if (mashAmount >= 100)
            {
                mashAmount = 100;
                StartCoroutine("PowerUp");
            }
        }
        if(lampSteal.lampStolen == true)
        {
            StartCoroutine("CoolDown");
        }
        if(lampSteal.lampStolen == false)
        {
            LampPickedUp();
        }
    }

    IEnumerator PowerUp()
    {
        lightSource.gameObject.SetActive(true);
        while (lt.intensity != 1.5f)
        {
            lt.intensity = Mathf.MoveTowards(lt.intensity, 1.5f, Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(CoolDown());
    }


    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(10.0f);
        while (lt.intensity != 0.0)
        {
            lt.intensity = Mathf.MoveTowards(lt.intensity, 0.0f, Time.deltaTime);
            yield return null;
        }
        //lightSource.gameObject.SetActive(false);
        mashAmount = 0; 
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Lamp"))
        {
            lampSteal.lampStolen = false;
        }
    }

    public void LampPickedUp()
    {
        player = GameObject.Find("Player");
        lampSteal.lamp.transform.parent = player.transform.parent;
        lampSteal.lamp.transform.position = lampPosition.transform.position;
    }

}
