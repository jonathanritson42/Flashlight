using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wardrobe : MonoBehaviour
{
    public bool wardrobe1;
    public bool wardrobe2;

    private Animator anim;
    public bool triggered;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            triggered = false;
            animate();
        }
    }

    void animate()
    {
        if (wardrobe1) anim.SetTrigger("wardrobe1");

        if (wardrobe2) anim.SetTrigger("wardrobe2");
    }
}
