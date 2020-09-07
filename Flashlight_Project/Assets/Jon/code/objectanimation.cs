using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectanimation : MonoBehaviour
{
    [Header("Animations")]
    public bool chair; public bool sofa; public bool sink; public bool bed;

    public bool triggered;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            animate();
        }
    }

    void animate()
    {
        if (chair) anim.SetTrigger("chair");
        if (sofa) anim.SetTrigger("sofa");
        if (sink) anim.SetTrigger("sink");
        if (bed) anim.SetTrigger("bed");

        this.enabled = false;
    }
}
