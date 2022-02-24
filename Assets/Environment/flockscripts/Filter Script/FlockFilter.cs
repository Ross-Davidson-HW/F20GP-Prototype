using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to ensure the flock does not adhere to the wrong thing (I.E other flocks or the player)

[CreateAssetMenu(menuName = "Flock/Filter/SameFlock")]
public class FlockFilter : context
{
    public override List<Transform> Filter(fAgent agent, List<Transform> orig)
    {
        // List container for the filtered objects
        List<Transform> filtered = new List<Transform>();

        foreach (Transform t in orig)
        {
            // gets the flock agent of the List, compares it to the flock agent of the agent itself, then adds to the list if they match
            fAgent tAgent = t.GetComponent<fAgent>();
            if (tAgent != null && tAgent.AgentFlock == agent.AgentFlock)
            {
                filtered.Add(t);                
                            
            }
        }

        return filtered;
    }
}
