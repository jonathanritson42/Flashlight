using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dooranimation : MonoBehaviour
{
    [Header("Animations")]
    public bool open;
    public bool openclose;
    public bool spin;
    public bool flop;
    public bool shrink;

    [Header("Detection")]
    public bool proximity;
    public bool timer;

    [Header("Values")]
    public float proxdist;
    public float timedelay;


    private float dist;
    public GameObject player;
    private Animator anim;
    public Text textpopup;
    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        textpopup.gameObject.SetActive(false);

        if (timer)
        {
            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(timedelay);

        animate();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);

        if (dist < 4.5 && !proximity)                       // Detection distance 
        {
            textpopup.gameObject.SetActive(false);
        }

        if (dist < 4 && !proximity)                         // Detection distance 
        {
            textpopup.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                textpopup.gameObject.SetActive(false);
                animate();
            }
        }

        if (dist < proxdist && proximity) 
        {
            animate();
        }
    }

    void animate()
    {
        print("animate");

        if (open) anim.SetTrigger("normal");
        if (spin) anim.SetTrigger("spin");
        if (flop) anim.SetTrigger("flop");
        if (shrink) anim.SetTrigger("shrink");

        if (openclose && !once)
        {
            anim.SetTrigger("normal");
            once = true;
        }
        else if (openclose && once)
        {
            anim.SetTrigger("normal");
            once = false;
        }

        if(!openclose) this.enabled = false;
    }
}