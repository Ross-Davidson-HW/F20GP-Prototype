using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // allows a player object to be linked and movement disabled
    public Movement moving;    

    void OnCollisionEnter(Collision collisionInfo)
    {
        // test function to check collision between objects
        //Debug.Log(collisionInfo.collider.name);
             

        if (collisionInfo.collider.tag == "Danger")
        {
            // disables player movement and triggers game over
            GetComponent<Movement>().enabled = false;
            FindObjectOfType<manager>().GAMEOVER();

        }


    }

}
