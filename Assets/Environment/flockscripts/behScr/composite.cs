using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Combines other behaviours, so that multiple may be applied to the flocks at once

[CreateAssetMenu(menuName = "Flock/Behaviour/composite")]
public class composite : filteredFBehaviour
{
    // stores the behaviours, set in Unity
    public fBehaviour[] behaviours;
    // weight of each behaviour, set in unity
    public float[] weights;

    public override Vector3 calcMove(fAgent agent, List<Transform> context, Flock flock)
    {
        // checks the two arrays are equal in length, or returns an error
        if (behaviours.Length != weights.Length)
        {
            Debug.LogError("Mismatched data: " + name, this);
            return Vector3.zero;
        }

        // initialise movement
        Vector3 move = Vector3.zero;

        // iterate through behaviours
        for (int i = 0; i < behaviours.Length; i++)
        {
            // calculates partial movement, based upon weight
            Vector3 partial = behaviours[i].calcMove(agent, context, flock) * weights[i];

            
            if (partial != Vector3.zero)
            {
                // makes sure the weight does not exceed the maximum allowed
                if (partial.sqrMagnitude > weights[i] * weights[i])
                {
                    partial.Normalize();
                    partial *= weights[i];
                }

                move += partial;
            }
        }
        return move;

    }
}
