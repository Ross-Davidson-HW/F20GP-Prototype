using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script handling the Quit Function

public class Quit : MonoBehaviour
{
    // Must be public for the button to detect the method
    public void quitGame()
    {
        // If used as a seperate program, this script will close the game. Within the Unity testing area, instead it logs that the button has been pressed.
        Debug.Log("Quit Game selected");
        Application.Quit();
    }
}
