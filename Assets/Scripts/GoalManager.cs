using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    // Method to toggle the visibility of the menu
    public void ToggleGoalPopup()
    {
        bool isActive = gameObject.activeSelf;
        gameObject.SetActive(!isActive);  // Toggle active state
    }
}
