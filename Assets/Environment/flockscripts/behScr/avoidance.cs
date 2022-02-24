using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the flocks avoidance, ensuring they don't all glue themselves together into one solid mass, but keep some seperation between them

// Adds an option to the create menu to create flock behaviours
[CreateAssetMenu(menuName = "Flock/Behaviour/avoidance")]
public class avoidance : filteredFBehaviour
{
    public override Vector3 calcMove(fAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbours, no adjustment needed
        if (context.Count == 0)
        {
            return Vector3.zero;
        }


        // number of objects to avoid
        int nAvoid = 0;

        // add all together and average them out
        Vector3 avoidMove = Vector3.zero;
        // if no filter is in use, continue as is, else apply the filter
        List<Transform> filtered = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform t in filtered)
        {
            if (Vector3.SqrMagnitude(t.position - agent.transform.position) < flock.AvoidSqr)
            {                
                avoidMove += (agent.transform.position - t.position);
            }
        }
        
        // Check if there is anything to avoid
        if (nAvoid > 0)
        {
            avoidMove /= nAvoid;
        }

        return avoidMove;

    }
}
