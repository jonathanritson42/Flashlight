using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changemat : MonoBehaviour
{
    public Material changematerial;
    private Material startingmat;

    // Start is called before the first frame update
    void Start()
    {
        startingmat = this.GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<flashlight>())
        {
            this.GetComponent<MeshRenderer>().material = changematerial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<flashlight>())
        {
            this.GetComponent<MeshRenderer>().material = startingmat;
        }
    }
}
