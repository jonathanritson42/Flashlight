using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disolvethroughcode : MonoBehaviour
{
    public Color startcolour, endcolour;
    Material[] myMaterials;
    private bool change;
    private float timer, downtimer = 1;
    public bool effect;

    // Start is called before the first frame update
    void Start()
    {
        myMaterials = GetComponent<Renderer>().materials;


    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            timer += 0.002f;

            if (downtimer > 0)
            {
                downtimer -= 0.002f;
            }

            myMaterials[0].color = Color.Lerp(startcolour, endcolour, timer);
            myMaterials[1].SetFloat("_Cutoff", downtimer);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<flashlight>())
        {
            if (effect)
            {
                change = true;
            }
            else
            {
                myMaterials[0].color = endcolour;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<flashlight>())
        {
            if (effect)
            {
                change = false;
                timer = 0;
                downtimer = 1;
                myMaterials[1].SetFloat("_Cutoff", 1);
                myMaterials[0].color = startcolour;
            }
            else
            {
                myMaterials[0].color = startcolour;
            }
        }
    }
}
