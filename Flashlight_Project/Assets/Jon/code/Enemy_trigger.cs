using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_trigger : MonoBehaviour
{    
    public GameObject EnemyObj,singlespawnlocation;
    public bool userandomspawn;
    public GameObject[] spawnlocationlist;

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>())
        {
            triggered = true;

            if (userandomspawn)
            {
                int spawnpos = Random.Range(0, spawnlocationlist.Length);

                Instantiate(EnemyObj, spawnlocationlist[spawnpos].transform.position, EnemyObj.transform.rotation);
            }
            else
            {
                Instantiate(EnemyObj, singlespawnlocation.transform.position, EnemyObj.transform.rotation);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggered)
        {
            this.GetComponent<Collider>().enabled = false;

            //this.GetComponent<Collider>().isTrigger = false;
                                                                    // Depends on usecase
            //Destroy(this.gameObject);
        }
    }
}
