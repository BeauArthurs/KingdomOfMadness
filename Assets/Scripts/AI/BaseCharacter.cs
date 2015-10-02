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
    [SerializeField]
    protected bool jumping;
    protected Rigidbody body;
    protected Animator anime;
    // Use this for initialization
    void Awake ()
	{
		body = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
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

    public virtual void takeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            //kill me
            Debug.Log("dead");
        }
    }
    public virtual void takeHeal(int amount)
    {
        hp += amount;
        if (hp > maxHp)
	    {
		    hp = maxHp;
	    }
    }
    protected void Jump()
    {
        jumping = true;
        body.AddForce(Vector3.up * JumpForce);
    }
    public virtual void  OnCollisionEnter(Collision other)
	{
		if (jumping && other.gameObject.tag == "Ground") 
		{
			jumping = false;
		}
	}
}
