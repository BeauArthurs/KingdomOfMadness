using UnityEngine;
using System.Collections;

public class MovementAI : MonoBehaviour {

    //seek behavior
    public Vector3 seek(MovementData target,MovementData self)
    {
        Vector3 position = target.position - self.position;
        return position;
    }

    public void chase(MovementData target, MovementData self, float maxSpeed)
    {
        Vector3 direction = seek(target,self);
        float distance = direction.magnitude;
        Vector3 targetPredictedLocation = target.position + target.velocity;
        Vector3 result = targetPredictedLocation - self.position;
        if (result.magnitude > maxSpeed)
        {
            result.Normalize();
            result *= maxSpeed;
        }
        
        self.velocity = result;
    }

    public void flee(MovementData target, MovementData self, float maxSpeed)
    {
        Vector3 direction = seek(target, self);
        float distance = direction.magnitude;
        Vector3 targetPredictedLocation = target.position + target.velocity;
        Vector3 result = targetPredictedLocation - self.position;
        if (result.magnitude > maxSpeed)
        {
            result.Normalize();
            result *= maxSpeed;
        }
        result *= -1;
        self.velocity = result;
    }

}
