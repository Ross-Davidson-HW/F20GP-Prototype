using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tries to have the flock keep to the same alignment as they move around. If one turns, they all turn

// Adds an option to the create menu to create flock behaviours
[CreateAssetMenu(menuName = "Flock/Behaviour/alignment")]
public class alignment : filteredFBehaviour
{
    public override Vector3 calcMove(fAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbours, maintain alignment
        if (context.Count == 0)
        {
            return agent.transform.forward;
        }

        // add all together and average them out
        Vector3 alignMove = Vector3.zero;

        // if no filter is in use, continue as is, else apply the filter
        List<Transform> filtered = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform t in filtered)
        {
            alignMove += t.transform.forward;
        }
        alignMove /= context.Count;

        return alignMove;

    }

}
