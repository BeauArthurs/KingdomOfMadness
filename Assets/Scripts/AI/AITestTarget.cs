using UnityEngine;
using System.Collections;

public class AITestTarget : MonoBehaviour
{
    MovementAI movementScript;
    MovementData myMoveData;
    // Use this for initialization
    void Start()
    {
        movementScript = GameObject.FindGameObjectWithTag("AI").GetComponent<MovementAI>();
        myMoveData = GetComponent<MovementData>();
        myMoveData.position = transform.position;
        myMoveData.velocity = new Vector3(1,0,0);
    }

    // Update is called once per frame
    void Update()
    {

        myMoveData.position = transform.position;
        Debug.DrawRay(transform.position, myMoveData.velocity);
        transform.Translate(myMoveData.velocity);
        myMoveData.position = transform.position;
    }
}
