using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//** This script handles the collection of the star object, sending an update to the Stars script and destroying the star object

public class Collect : MonoBehaviour
{
    // allows attachment of a manager object
    public manager gameManager;

    // This trigger allows for the user to enter the objects area to trigger an event
    void OnTriggerEnter(Collider other)
    {
        // checks that the moving object is a player, so other objects such as the flock can't pick them up
        if (other.tag == "Player") { 
            // Lowers the number of remaining stars by 1
            Stars.starTotal -= 1;

            // victory condition
            if (Stars.starTotal == 0) {
                gameManager.Victory();
            }

            //destroys the object so the player cannot pick it up more than once
            Destroy(gameObject);
    }
    }
}
