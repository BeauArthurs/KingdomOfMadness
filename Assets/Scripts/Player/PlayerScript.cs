using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed = 6f;            
	
	Vector3 movement;
	Rigidbody playerRigidbody;
	[SerializeField]
	private float rotationSensitivity = 15f;
    private float yRotation = 0F;
	private Quaternion originalBodyRotation;
	void Awake ()
	{
		originalBodyRotation = transform.localRotation;
		playerRigidbody = GetComponent<Rigidbody> ();
	}
	void FixedUpdate () 
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		movement.Set (h, 0f, v);
		movement = transform.TransformDirection(movement);
		
		// Move the player to it's current position plus the movement.
		transform.position  += movement * Time.deltaTime * speed;

		yRotation += Input.GetAxis("Mouse X") * rotationSensitivity;

		Quaternion yQuaternion = Quaternion.AngleAxis(yRotation, Vector3.up);
		Quaternion tempY = originalBodyRotation * yQuaternion;

		transform.localRotation = Quaternion.Slerp(transform.localRotation, tempY, 5);
	}
}
