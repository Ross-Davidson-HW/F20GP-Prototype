using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The asset must have a collidor, for the agent to properly detect other flock agents
[RequireComponent(typeof(Collider))]

public class fAgent : MonoBehaviour
{

    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }


    Collider agentCollider;

    // needed to access the collider without assigning to it
    public Collider AgentCollider { get { return agentCollider; } }

    // Start is called before the first frame update
    void Start()
    {
        // initialises the agentCollider with the collider the component uses
        agentCollider = GetComponent<Collider>();
    }

    public void initialise(Flock flock)
    {
        agentFlock = flock;
    }

    // turns agent to face direction it is moving towards, then moves towards it
    public void move(Vector3 velocity)
    {
        // whatever way the object is facing will be forward
        transform.forward = velocity;

        // updates the objects position, using deltaTime to keep it consistent regardless of framerate
        transform.position += velocity * Time.deltaTime;
    }
}
