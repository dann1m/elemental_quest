using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPanelManager : MonoBehaviour
{
    // Method to toggle the visibility of the menu
    public void ToggleInstructionMenu()
    {
        bool isActive = gameObject.activeSelf;
        gameObject.SetActive(!isActive);  // Toggle active state
    }
}
