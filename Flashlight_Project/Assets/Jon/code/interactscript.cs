using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactscript: MonoBehaviour
{
    public Text textpopup;
    public AudioClip interactsfx, doorsfx;
    public AudioSource AS;
    public Collider lightbounds;

    void Update()
    {
        if (!pausemenu.paused)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 4) && ((hit.transform.GetComponent<objectanimation>() && lightbounds.enabled) || hit.transform.GetComponent<dooranimation>() || (hit.transform.GetComponent<lamponoff>()) && lightbounds.enabled))
            {
                textpopup.gameObject.SetActive(true);

                if (GetComponent<Lamp>().state == LampState.STOLEN || hit.transform.GetComponent<dooranimation>())
                {
                    textpopup.GetComponent<Text>().color = new Color(255, 255, 255, Mathf.PingPong(Time.time, 1));
                }
                else
                {
                    if (lightbounds.enabled)
                    {
                        textpopup.GetComponent<Text>().color = new Color(0, 0, 0, Mathf.PingPong(Time.time, 1));
                    }
                    else
                    {
                        return;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Mouse0) && (hit.transform.GetComponent<objectanimation>()))
                {
                    textpopup.gameObject.SetActive(false);
                    hit.transform.GetComponent<objectanimation>().triggered = true;
                    TaskList.taskCounter += 1;

                    AS.clip = interactsfx;
                    AS.Play();

                }

                if (Input.GetKeyDown(KeyCode.Mouse0) && (hit.transform.GetComponent<dooranimation>()))
                {
                    textpopup.gameObject.SetActive(false);
                    hit.transform.GetComponent<dooranimation>().animate();
                    AS.clip = doorsfx;
                    AS.Play();

                }

                if (Input.GetKeyDown(KeyCode.Mouse0) && (hit.transform.GetComponent<lamponoff>() && lightbounds.enabled))
                {
                    textpopup.gameObject.SetActive(false);
                    hit.transform.GetComponent<lamponoff>().triggered = true;
                    TaskList.taskCounter += 1;

                    AS.clip = interactsfx;
                    AS.Play();
                }
            }
            else
            {
                textpopup.gameObject.SetActive(false);
            }
        }
    }
}
