using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleportsam : MonoBehaviour
{

    public CharacterController player;

    public Transform receiver;

     private bool playerIsOverlapping = false;

     private void Update()
     {
         if (playerIsOverlapping)
         {
             Vector3 portalToPlayer = player.transform.position - transform.position;
             float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

             if(dotProduct < 0f)
             {
                 float rotationDifference = -Quaternion.Angle(transform.rotation, receiver.rotation);
                 rotationDifference += 180;
                 player.transform.Rotate(Vector3.up, rotationDifference);

                 Vector3 positionOffset = Quaternion.Euler(0f, rotationDifference, 0f) * portalToPlayer;
                 player.enabled = false;
                 player.transform.position = receiver.position + positionOffset;
                 player.enabled = true;
                 playerIsOverlapping = false;
             }
         }
     }

     private void OnTriggerEnter(Collider other)
     {
         if(other.tag == "Player")
         {
             playerIsOverlapping = true;
         }
     }

     private void OnTriggerExit(Collider other)
     {
         if(other.tag == "Player")
         {
             playerIsOverlapping = false;
         }
     }

}
