using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/stayInArea")]
public class stayInArea : filteredFBehaviour
{

    public Vector3 centre;
    public float radius = 30f;

    public override Vector3 calcMove(fAgent agent, List<Transform> context, Flock flock)
    {
        // determines where the agent is compared to the centre of the area
        Vector3 centreOffset = centre - agent.transform.position;
        float t = centreOffset.magnitude / radius;

        // if the agent is within the radius, continue as is
        if (t < 0.8f)
        {
            return Vector3.zero;
        }

        return centreOffset * t * t;
    }

}
