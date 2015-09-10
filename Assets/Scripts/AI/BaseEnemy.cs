using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour
{

    [SerializeField]
    private int hp;
    [SerializeField]
    private int maxHp;
    [SerializeField]
    private int moveSpeed;
    [SerializeField]
    private int attackDamage;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
