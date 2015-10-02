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
			movement = transform.TransformDirection (movement);

			body.MovePosition (transform.position + movement * Time.deltaTime * moveSpeed);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, turningRate * Time.deltaTime);
            anime.SetBool("Moving", false);
        }
        else
        {
            anime.SetBool("Moving", true);
        }
        anime.SetFloat("DirX", h);
        anime.SetFloat("DirY", v);
        if (Input.GetAxis("Jump") > 0 && jumping == false)
		{
			Jump();
		}
        if(Input.GetMouseButtonDown(0))
        {
            anime.SetBool("Attack", true);
        }
		
	}
    public void EndAttack()
    {
        anime.SetBool("Attack", false);
    }
	public void SetRotation(Quaternion angles)
	{
		targetRotation = new Quaternion(0,angles.y,0,angles.w);
	}
	public override void OnCollisionEnter(Collision other)
	{
		base.OnCollisionEnter (other);
	}
}
