using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract class that does not need to be intialised itself

public abstract class fBehaviour : ScriptableObject
{
    // all behaviours will implement this calculation. Makes use of the flock agent and a list of transforms to check what other agents or obstacles are doing
    public abstract Vector3 calcMove(fAgent agent, List<Transform> context, Flock flock);

}
