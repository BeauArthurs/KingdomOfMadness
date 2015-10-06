using UnityEngine;
using System.Collections;

public class EnemyStateMachine : MonoBehaviour
{

    enum States { attack, flee }
    private States _currentState = States.attack;
    [SerializeField]
    private float _moveSpeed = 1;
    private float _attackRange = 1;
    private MovementAI _movementScript;
    private MovementData _myMoveData;
    public GameObject target;
    private MovementData _targetMoveData;
    private int _maxHp = 100;
    [SerializeField]
    private int _currentHp;
    private bool _canExplode = true;
    private Animator anime;

    // Use this for initialization
    void Awake()
    {
        _movementScript = GameObject.FindGameObjectWithTag("AI").GetComponent<MovementAI>();
        _myMoveData = GetComponent<MovementData>();
        _targetMoveData = target.GetComponent<MovementData>();
        _myMoveData.position = transform.position;
        _currentHp = _maxHp;
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case States.attack:
                //attack logic
                anime.SetBool("Attack", true);
                if (_currentHp <= _maxHp / 2 && _canExplode)
                {
                    Debug.Log("BOOM");
                    _canExplode = false;

                    //hp is low start running away turn this on if there are ways to heal 
                    //_currentState = States.flee;
                }
                else if (_movementScript.seek(_targetMoveData, _myMoveData).magnitude <= _attackRange)
                {
                    Debug.Log("attacking");
                }
                else
                {
                    Debug.Log("move closer");
                    _movementScript.chase(_targetMoveData, _myMoveData, _moveSpeed);
                    move();
                }
                break;
            case States.flee:
                //flee logic
                Debug.Log("run away");
                _movementScript.flee(_targetMoveData, _myMoveData, _moveSpeed);
                move();
                break;
        }
    }

    void move()
    {
        transform.Translate(_myMoveData.velocity);
        _myMoveData.position = transform.position;
    }

    public void takeDamage(int damage)
    {
        _currentHp -= damage;
        if (_currentHp <= 0)
        {
            Destroy(this.gameObject);
;       }
    }
}
