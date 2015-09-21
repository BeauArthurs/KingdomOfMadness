using UnityEngine;
using System.Collections;

public class BaseCharacter  : MonoBehaviour
{

    [SerializeField]
    protected int hp;
    [SerializeField]
	protected int maxHp;
    [SerializeField]
	protected int moveSpeed;
    [SerializeField]
	protected int attackDamage;
	[SerializeField]
	protected float JumpForce;
	protected bool jumping;
	protected Rigidbody body;
    // Use this for initialization
	void Awake ()
	{
		body = GetComponent<Rigidbody> ();
		JumpForce = 200;
	}
	
    // Update is called once per frame
	void FixedUpdate()
    {
		if (Input.GetAxis("Jump") > 0 && jumping == false)
		{
			jumping = true;
			body.AddForce(Vector3.up * JumpForce);
		}
    }

    public void takeDamage(int damage)
    {
        hp -= damage;
        if (hp <=0)
	    {
		     //kill me
            Debug.Log("dead");
	    }
    }
    public void takeHeal(int amount)
    {
        hp += amount;
        if (hp > maxHp)
	    {
		    hp = maxHp;
	    }
    }
	private void  OnCollisionEnter(Collision other)
	{
		if (jumping && other.gameObject.tag == "Ground") 
		{
			jumping = false;
		}
	}
}
