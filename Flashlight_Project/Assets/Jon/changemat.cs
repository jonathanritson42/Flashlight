using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changemat : MonoBehaviour
{
    public Material changematerial, endmat;
    private Material startingmat;
    private float timerincrease;

    public bool effect;

    // Start is called before the first frame update
    void Start()
    {
        startingmat = this.GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        changematerial.SetFloat("timer", timerincrease);
        timerincrease += 0.001f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<flashlight>())
        {
            if (effect)
            {
                timerincrease = 0;
                this.GetComponent<MeshRenderer>().material = changematerial;
                StartCoroutine(delayswap());
            }
            else
            {
                this.GetComponent<MeshRenderer>().material = endmat;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<flashlight>())
        {
            StopCoroutine(delayswap());
            this.GetComponent<MeshRenderer>().material = startingmat;
        }
    }

    IEnumerator delayswap()
    {
        yield return new WaitForSeconds(4);

        this.GetComponent<MeshRenderer>().material = endmat;
    }
}