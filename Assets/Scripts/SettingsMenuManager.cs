using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle muteToggle;
    public Toggle fullscreenToggle;
    public AudioSource audioSource; // Reference to the AudioSource

    private void Start()
    {
        // Load saved settings
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        bool isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        bool isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        volumeSlider.value = savedVolume;
        muteToggle.isOn = isMuted;
        fullscreenToggle.isOn = isFullscreen;

        audioSource.volume = isMuted ? 0f : savedVolume;
        Screen.fullScreen = isFullscreen;
    }

    public void OnVolumeChanged(float value)
    {
        Debug.Log("Volume changed to: " + value);
        if (muteToggle.isOn)
        {
            // Don't adjust the volume if muted
            return;
        }

        // Update volume when not muted
        audioSource.volume = value;
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

     public void OnMuteToggleChanged(bool isMuted)
    {
        // Update the AudioSource volume
        if (isMuted)
        {
            audioSource.volume = 0f;  // Set volume to 0 when muted
        }
        else
        {
            audioSource.volume = volumeSlider.value;  // Restore to slider value when unmuted
        }

        // Save mute state
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    public void OnFullscreenToggleChanged(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }


    // Method to toggle the visibility of the menu
    public void ToggleSettingsMenu()
    {
        bool isActive = gameObject.activeSelf;
        gameObject.SetActive(!isActive);  // Toggle active state
    }
}

