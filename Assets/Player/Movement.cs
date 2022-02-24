using UnityEngine;


// script for allowing the player to move, and for the camera to move in relation to the player.


public class Movement : MonoBehaviour
{
    // allows adjusting of the physics of the object
    public Rigidbody rb;

    // Used for movement in earlier tests, using GetAxis is more efficient and thus swapped
    //public float forwards = 1000f;
    //public float right = 50f;
    //public float left = -50f;
    //public float back = -500f;

    // movement speed variable. Assigning it to a variable allows it to be adjusted within Unity itself, instead of hardcoded
    public float speed = 10.0f;

    // used for directional movement: Forward uses positive values to move up, and negative to move down, while right uses positive for right, negative for left.
    Vector3 forward, right;

    // Used to force the camera to the correct location for isometric
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }
    
    void Update()
    {
        //movement options. 

        // detects user input
        if (Input.anyKey)
        {
            Move();
        }

        // triggers gameover if the player falls out of the map
        if (rb.position.y < -10f)
        {
            FindObjectOfType<manager>().GAMEOVER();
        }        
        

        // Original method of controlling movement

        //if (Input.GetKey("d"))
        //{

        //    rb.AddForce(right * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}
        //if (Input.GetKey("a"))
        //{

        //    rb.AddForce(left * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}
        //if (Input.GetKey("s"))
        //{

        //    rb.AddForce(0, 0, back * Time.deltaTime);
        //}
        //if (Input.GetKey("w"))
        //{

        //    rb.AddForce(0, 0, forwards * Time.deltaTime);
        //}

    }

    // controls players movement, as well as ensuring it changes relative to the camera
    void Move()
    {
        // assign the input keys to variables for ease of use
        float horiInput = Input.GetAxis("horKey");
        float vertInput = Input.GetAxis("verKey");

        // Use of Time.deltaTime to avoid framerate affecting updates, and keep it consistent over all PCs that run it        
        Vector3 rightMove = right * speed * Time.deltaTime * horiInput;
        Vector3 forwardMove = forward * speed * Time.deltaTime * vertInput;

        // Determines movement direction, normalising the vectors to point the character when moving around.
        Vector3 heading = Vector3.Normalize(rightMove + forwardMove);
        transform.forward = heading;

        // Allows the object to move
        transform.position += rightMove;
        transform.position += forwardMove;
    }
}
