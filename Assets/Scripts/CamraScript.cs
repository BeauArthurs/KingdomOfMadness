using UnityEngine;
using System.Collections;

public class CamraScript : MonoBehaviour {

	[SerializeField]
	private Transform target;
	private float distance;
	private float height;
	private float maxHeight;
	private float minHeight;
	private float maxDistance;
	private float minDistance;
	private float scrollSpeed;
	private float mouseX;
	void Awake () 
	{
		distance = 10;
		height = 2.5f;
		maxHeight = 5;
		minHeight = 0;
		maxDistance = 15;
		minDistance = 5.5f;
		scrollSpeed = 2;
	}
	void LateUpdate () 
	{
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		if (scroll != 0) 
		{
			float tempDistance = distance - scroll * scrollSpeed;
			if(tempDistance > minDistance && tempDistance < maxDistance)
			{
				distance = tempDistance;
			}
		}
		if (Input.GetMouseButton (2)) 
		{
			float y = Input.GetAxis ("Mouse Y");
			float newHeight= height + y;
			if(newHeight < maxHeight && newHeight > minHeight)
			{
				height = newHeight;
			
			}
		}
		float mouseX = Input.GetAxis ("Mouse X");

		transform.RotateAround (target.position, Vector3.up, mouseX * 100 * Time.deltaTime);
		transform.position = target.position;
		transform.position -= transform.rotation * Vector3.forward * distance;
		transform.position = new Vector3(transform.position.x,target.localPosition.y+ height,transform.position.z) ;
		transform.LookAt (target);

		if (mouseX != 0) 
		{
			target.GetComponent<PlayerScript>().SetRotation (transform.rotation);
		}
	}
}
