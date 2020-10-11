using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject spider;

    private void Start()
    {
        spider.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            spider.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
