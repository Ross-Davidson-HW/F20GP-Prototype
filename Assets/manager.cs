using UnityEngine;
using UnityEngine.SceneManagement;

// Management script that handles victory, game over and restarting the game

public class manager : MonoBehaviour
{
    bool gameOver = false;
    // sets the delay for when the level ends, be it in victory or failure
    public float delay = 5f;

    // UI objects displayed when victory or gameover occurs
    public GameObject completeUI, gameOverUI;
    
    // allows a player object to be linked and movement disabled
    public Movement moving;

    // Triggers when player completes the level
    public void Victory()
    {
        // shows the victory UI
        completeUI.SetActive(true);
        // disables movement
        moving.GetComponent<Movement>().enabled = false;
        // Load the finish screen after a delay
        Invoke("Success", delay);
    }

    // Triggers when the player fails
    public void GAMEOVER()
    {
        // ensures the gameover only triggers once
        if (gameOver == false)
        {
            gameOver = true;
            // displays the gameover UI
            gameOverUI.SetActive(true);
            // restarts the level after a delay
            Invoke("Restart", delay);            
        }
    
    }

    // restarts the level
    void Restart()
    {
        // resets the total stars, to avoid the player needing less stars or going into negatives when a restart occurs
        Stars.starTotal = 9;
        // calls the currently active scene and reloads it. Can be set to L1, L2, etc as more are added if wanting to restart from a specific level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // loads the finish screen
    void Success()
    {        
        SceneManager.LoadScene("Quit");
    }

}
