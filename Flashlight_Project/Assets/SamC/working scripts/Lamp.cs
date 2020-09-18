using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LampState { NOTORCH, PICKEDUP, STOLEN}

public class Lamp : MonoBehaviour
{
    public LampState state;

    //lamp vars
    private int mashCount = 10;
    public int mashAmount = 0;
    public GameObject lightSource;
    public AudioSource lightSound;
    public Light lt;
    public bool leftKeyPushed = false;
    public bool rightKeyPushed = true;
    public GameObject lamp;

    //positions
    public GameObject player;
    public GameObject lampPosition;

    public Transform[] lampLocations;

    private void Start()
    {
        state = LampState.NOTORCH;
        lamp.transform.parent = null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lamp"))
        {
            PickedUp();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Stolen();
        }
    }

    public void Update()
    {
        if(state == LampState.PICKEDUP)
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

    void PickedUp()
    {
        lamp.transform.parent = player.transform.parent;
        lamp.transform.position = lampPosition.transform.position;
        state = LampState.PICKEDUP;
    }

    void Stolen()
    {
        lamp.transform.parent = null;
        lamp.transform.position = lampLocations[Random.Range(0, lampLocations.Length)].transform.position;
        state = LampState.STOLEN;
    }
}
