using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactscript: MonoBehaviour
{
    public Text textpopup;

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 4) && (hit.transform.GetComponent<objectanimation>() || hit.transform.GetComponent<dooranimation>()))
        {
            textpopup.gameObject.SetActive(true);

            textpopup.GetComponent<Text>().color = new Color(0,0,0, Mathf.PingPong(Time.time, 1));

            if (Input.GetKeyDown(KeyCode.E) && (hit.transform.GetComponent<objectanimation>()))
            {
                textpopup.gameObject.SetActive(false);
                hit.transform.GetComponent<objectanimation>().triggered = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && (hit.transform.GetComponent<dooranimation>()))
            {
                textpopup.gameObject.SetActive(false);
                hit.transform.GetComponent<dooranimation>().animate();
            }
        }
        else
        {
            textpopup.gameObject.SetActive(false);
        }
    }
}
