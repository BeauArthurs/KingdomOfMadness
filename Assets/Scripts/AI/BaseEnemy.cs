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

    public int HP
    {
        get{return hp}; set{hp = value};
    }
    public int MAXHP
    {
        get{return maxHp}; set{maxHp = value};
    }
    public int MoveSpeed
    {
        get{return moveSpeed}; set{moveSpeed = value};
    }
    public int AttackDamage
    {
        get{return attackDamage}; set{attackDamage = value};
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
