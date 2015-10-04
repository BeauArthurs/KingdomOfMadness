using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    [SerializeField] private string _name = "PlaceHolder";
    [SerializeField] private float _price = 1f;
    [SerializeField] private float _damage = 1f;

    public string name
    {
        get
        {
            return _name;
        }
    }

    public float price
    {
        get
        {
            return _price;
        }
    }


    public float damage
    {
        get
        {
            return _damage;
        }
    }

}
