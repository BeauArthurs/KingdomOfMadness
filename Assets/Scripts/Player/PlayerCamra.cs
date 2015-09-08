using UnityEngine;
using System.Collections;

public class PlayerCamra : MonoBehaviour {

	[SerializeField]
	private Transform target;
	private float distance;
	private float height;
	private float heightDamping;
	private float rotationDamping;
	void Start () 
	{
		distance = 10;
		height = 5;
		heightDamping = 2;
		rotationDamping = 3;
	}

	void LateUpdate () 
	{
		// Calculate the current rotation angles
		float wantedRotationAngle = target.localEulerAngles.y;
		float wantedHeight = target.position.y + height;
		float currentRotationAngle = transform.localEulerAngles.y;
		float currentHight = transform.position.y;

		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.Lerp (currentRotationAngle,wantedRotationAngle,rotationDamping * Time.deltaTime);
		// Damp the height
		currentHight = Mathf.Lerp (currentHight, wantedHeight, heightDamping * Time.deltaTime);
		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		// Set the height of the camera
		transform.position = new Vector3(transform.position.x, currentHight,transform.position.z) ;
		// Always look at the target
		transform.LookAt (target);
	}
}
