using UnityEngine;
using UnityEngine.UI;


//** This script handles the display in the top left of the screen that tracks how many stars remain to be gathered /

public class Stars : MonoBehaviour
{
    // Sets the number of stars in the scene
    public GameObject starText;    
    public static int starTotal = 9;
        
    void Update()
    { 
        // updates the displayed text when a star is collected
        starText.GetComponent<Text>().text = "Stars left: " + starTotal;
    }

}
