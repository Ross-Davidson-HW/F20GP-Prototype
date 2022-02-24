using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps the flock close together, but not touching, so they may move as a unit

// Adds an option to the create menu to create flock behaviours
[CreateAssetMenu(menuName = "Flock/Behaviour/cohession")]
public class cohession : filteredFBehaviour
{
    // used when smoothing the agents movement
    Vector3 currVelocity;

    // sets how long it takes the agent to move to the calculated state
    public float agentSmoothTime = 0.5f;

    public override Vector3 calcMove(fAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbours, no adjustment needed
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        // add all together and average them out
        Vector3 cohessionMove = Vector3.zero;

        // if no filter is in use, continue as is, else apply the filter
        List<Transform> filtered = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform t in filtered)
        {
            cohessionMove += t.position;
        }
        cohessionMove /= context.Count;

        // Agent position offset
        cohessionMove -= agent.transform.position;
        // smooths the agents movement
        cohessionMove = Vector3.SmoothDamp(agent.transform.forward, cohessionMove, ref currVelocity, agentSmoothTime);
        return cohessionMove;

    }


}
