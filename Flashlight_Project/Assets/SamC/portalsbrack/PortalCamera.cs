using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	public Transform playerCamera;
	public Transform portal;
	public Transform otherPortal;
	public bool attic;
	private Vector3 tempplayer;

	// Update is called once per frame
	void Update () 
	{
		if (attic)
		{
			tempplayer = new Vector3(playerCamera.position.z + 15.5f, playerCamera.position.y, playerCamera.position.x - 18f);
			Vector3 playerOffsetFromPortal = tempplayer - otherPortal.position;
			transform.position = portal.position + playerOffsetFromPortal;

			float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

			Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
			Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
			transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
		}
		else 
		{
			tempplayer = new Vector3(playerCamera.position.z + 3f, playerCamera.position.y, playerCamera.position.x);
			Vector3 playerOffsetFromPortal = tempplayer - otherPortal.position;
			transform.position = portal.position + playerOffsetFromPortal;

			float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

			Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, -Vector3.up);
			Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
			transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
		}

		
		/*		
 		Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
		transform.position = portal.position + playerOffsetFromPortal;

		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);
																																// Original Sam/Brackeys code
		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
		*/
		
	}
}
