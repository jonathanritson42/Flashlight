using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sway : MonoBehaviour
{
    public float verticalSway = 0.01f;

    public float horiztonalSway = 0.02f;

    public float swaySpeed = 2f;

    private float x, y;

    private void Start()
    {
        x = transform.localPosition.x;
        y = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pausemenu.paused)
        {
            y += verticalSway * Mathf.Sin((swaySpeed * 2) * Time.time);
            x += horiztonalSway * Mathf.Sin(swaySpeed * Time.time);
            transform.localPosition = new Vector3(x, y, transform.localPosition.z);
        }
    }

}
