using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class context : ScriptableObject
{
    // filters the flock to ensure it only flocks to others of the flock, and not random objects or the player
    public abstract List<Transform> Filter(fAgent agent, List<Transform> orig);
}
