using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseThing : MonoBehaviour
{
    public GameObject pauseUI; // Reference to the Pause Menu UI GameObject

    // Method to resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume time
        pauseUI.SetActive(false);

    }
}
