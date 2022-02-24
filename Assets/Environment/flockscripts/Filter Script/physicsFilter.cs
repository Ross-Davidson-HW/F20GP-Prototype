using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Filter/physics")]
public class physicsFilter : context
{
    // used for the layer the object is on
    public LayerMask mask;

    public override List<Transform> Filter(fAgent agent, List<Transform> orig)
    {
        // List container for the filtered objects
        List<Transform> filtered = new List<Transform>();

        foreach (Transform t in orig)
        {
            if (mask == (mask | (1 << t.gameObject.layer)))
            {
                filtered.Add(t);                
            }
            
        }
        return filtered;
    }
}
