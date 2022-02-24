using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform playerPos;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        // test function to ensure player position is correctly been caught
        // Debug.Log(playerPos.position);

        transform.position = playerPos.position + offset;
    }
}
