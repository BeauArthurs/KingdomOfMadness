using UnityEngine;
using System.Collections;

public class PlayerScript : BaseCharacter {
	          

	private Vector3 movement;
	private Quaternion tempY;


	private Quaternion targetRotation;
	private int turningRate = 200;

	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		if (h != 0 || v != 0) {
			movement.Set (h, 0f, v);
			Debug.Log(movement);
			movement = transform.TransformDirection (movement);

			body.MovePosition (transform.position + movement * Time.deltaTime * moveSpeed);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, turningRate * Time.deltaTime);
		}

	}
	public void SetRotation(Quaternion angles)
	{
		targetRotation = new Quaternion(0,angles.y,0,angles.w);
	}
	private void  OnCollisionEnter(Collision other)
	{
	}
}
