using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	protected Animator anime;
	protected Transform target;
	protected Transform destination;
	protected Rigidbody body;
	protected float health;
	protected float speed;
	protected bool vulnerable;
	protected bool knockback;
	// Use this for initialization
	protected void Awake () 
	{
		anime = GetComponent<Animator> ();
	}
	protected void heal (int amount)
	{
		health += amount;
	}
	protected void TakeDamige(int amount)
	{
		if (vulnerable) 
		{
			health -= amount;
		}
		if (knockback) 
		{
			anime.SetTrigger("knockback");
		}
	}
	protected void FixedUpdate()
	{
		if (destination != null) 
		{
			// goto destination at speed
		}
		if (target != null) 
		{
			transform.LookAt(target);
		}
	}
}
