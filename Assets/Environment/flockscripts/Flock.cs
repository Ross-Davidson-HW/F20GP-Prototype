using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    // needed for the prefab that the flock will use
    public fAgent prefab;
    // list to store all of the agents
    List<fAgent> agents = new List<fAgent>();
    // holds the object behaviour
    public fBehaviour behaviour;

    // the range used to determine how many are in the flock, with 12 as the start
    [Range(12, 20)] public int startCount = 15;
    const float density = 0.2f;

    // movement speed of the float
    [Range(1f, 10f)] public float drive = 5f;
    // the max speed of the object
    [Range(1f, 100f)] public float maxSpeed = 50f;
    // how close the object can be to its neighbours
    [Range(1f, 10f)] public float nRadius = 1.5f;
    // how close objects have to be to avoid each other, with 0 being no avoidance
    [Range(0f, 1f)] public float avoidMultiplier = 0.5f;

    // utility variables
    float maxSpeedSqr;
    float nRadiusSqr;
    float avoidSqr;

    // access the avoidSqr without changing it
    public float AvoidSqr { get { return avoidSqr; } }

    // Start is called before the first frame update
    void Start()
    {
        // assign values to the utility variables
        maxSpeedSqr = maxSpeed * maxSpeed;
        nRadiusSqr = nRadius * nRadius;
        avoidSqr = avoidMultiplier * avoidMultiplier;

        // initialise the flock
        for (int i = 0; i < startCount; i++)
        {
            // gives the flock agent its prefab object, as well as determines how many there are and what direction it is facing
            fAgent newAgent = Instantiate(prefab, Random.insideUnitCircle * startCount * density, Quaternion.Euler(Vector3.forward * Random.Range(0, 360)), transform);

            // assigns the agent a name and places it in the agents list
            newAgent.name = "Agent " + i;
            newAgent.initialise(this);
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(fAgent agent in agents)
        {
            // list of objects that exist within the context of the neighbour radius
            List<Transform> context = GetNearbyObjects(agent);

            // debug command to check that it is correctly detecting nearby objects
            // Debug.Log(context.Count);

            // calculate how the agent should move
            Vector3 move = behaviour.calcMove(agent, context, this);

            // set speed
            move *= drive;

            // checks if speed is higher than max speed, and if so, set it to max allowed speed instead
            if (move.sqrMagnitude > maxSpeedSqr)
            {
                move = move.normalized * maxSpeed;
            }
            // passes the speed to the agent
            agent.move(move);
        }
    }

    List<Transform> GetNearbyObjects(fAgent agent)
    {
        // list to return
        List<Transform> context = new List<Transform>();

        // collider checking what is within the neighbour radius of the object
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, nRadius);

        foreach(Collider c in contextColliders)
        {
            // checks that the collider is not the objects own collission box
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }
}
