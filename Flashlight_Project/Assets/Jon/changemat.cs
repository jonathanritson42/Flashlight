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
        changematerial.SetFloat("Vector1_96B9559A", timerincrease);
        timerincrease += 0.0002f;
        print(changematerial.GetFloat("Vector1_96B9559A"));
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
            timerincrease = 0;
            this.GetComponent<MeshRenderer>().material = startingmat;
            StopCoroutine(delayswap());
        }
    }

    IEnumerator delayswap()
    {
        yield return new WaitForSeconds(12);

        this.GetComponent<MeshRenderer>().material = endmat;
        timerincrease = 0;

    }
}