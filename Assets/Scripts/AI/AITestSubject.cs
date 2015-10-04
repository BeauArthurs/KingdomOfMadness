using UnityEngine;
using System.Collections;

public class AITestSubject : MonoBehaviour
{
    MovementAI movementScript;
    MovementData myMoveData;
    float maxSpeed = 15;
    public GameObject target;

    // Use this for initialization
    void Start()
    {
        movementScript = GameObject.FindGameObjectWithTag("AI").GetComponent<MovementAI>();
        myMoveData = GetComponent<MovementData>();
    }

    // Update is called once per frame
    void Update()
    {

        myMoveData.position = transform.position;
        movementScript.chase(target.GetComponent<MovementData>(), myMoveData, 12f);
        Debug.DrawRay(transform.position, myMoveData.velocity);
    }
}
