using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the Pause Menu UI GameObject

    private bool isPaused = false;

    // Method to toggle pause/resume
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    // Method to pause the game
    public void PauseGame()
    {
        Time.timeScale = 0f; // Freeze time
        isPaused = true;
        pauseMenuUI.SetActive(true); // Show the pause menu
    }

    // Method to resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume time
        isPaused = false;
        pauseMenuUI.SetActive(false);

    }

    // Optional: Method to quit the game
    public void QuitGame()
    {
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
                Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + "Unity Event Invoked");
            #endif
            #if (UNITY_EDITOR)
                UnityEditor.EditorApplication.isPlaying = false;
            #elif (UNITY_STANDALONE)
                Application.Quit();
            #elif (UNITY_WEBGL)
                SceneManager.LoadScene("QuitScene");
            #endif
        Debug.Log("Application has quit.");
    }
}
