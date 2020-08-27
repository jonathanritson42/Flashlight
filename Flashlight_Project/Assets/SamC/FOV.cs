using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public GameObject player;
    public GameObject objects;
    float maxFovAngle = 45;
    float lookRadius = 8;

    private void Update()
    {
        Vector3 fovRadius = player.gameObject.transform.forward * lookRadius;
        float distanceToObject = Vector3.Distance(objects.transform.position - player.transform.position, fovRadius);
        float playerAngle = Vector3.Angle(objects.transform.position - player.transform.position, fovRadius);

        if(playerAngle < maxFovAngle)
        {

            Debug.DrawRay(player.transform.position, objects.transform.position);

            RaycastHit hit;
            
            if(Physics.Raycast(player.transform.position, objects.transform.position,out hit))
            {
                if (hit.collider.CompareTag("Objects"))
                {
                    //Destroy(gameObject);
                    Debug.Log("SS");
                }
            }
        }
    }
}
