using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemylegtarget : MonoBehaviour
{
    private Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;

        RB.velocity = new Vector3(0,0,0);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.2f))
        {
            RB.velocity = transform.forward * 1;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit1, 0.2f))
        {
            RB.velocity = transform.forward * -1;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit2, 0.2f))
        {
            RB.velocity = transform.up * 1;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit3, 0.2f))
        {
            RB.velocity = transform.up * -1;
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit1.distance, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit2.distance, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit3.distance, Color.red);

    }
}
