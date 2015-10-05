using UnityEngine;
using System.Collections;

public class PlayerScript : BaseCharacter {
	          

	private Vector3 movement;
	private Quaternion tempY;

    private MovementData _moveData;
    private Quaternion targetRotation;
	private int turningRate = 600;

    void Start()
    {
        _moveData = GetComponent<MovementData>();
    }

	void FixedUpdate ()
	{
        _moveData.position = this.transform.position;
        float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		if (h != 0 || v != 0) {
			movement.Set (h, 0f, v);
			movement = transform.TransformDirection (movement);

            body.MovePosition (transform.position + movement * Time.deltaTime * moveSpeed);
            anime.SetBool("Moving", false);
        }
        else
        {
            anime.SetBool("Moving", true);
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningRate * Time.deltaTime);
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
