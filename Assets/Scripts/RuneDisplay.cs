using UnityEngine;
using TMPro;

public class RuneDisplayScript : MonoBehaviour
{
    public TMP_Text fireRuneText;
    public TMP_Text earthRuneText;
    public TMP_Text waterRuneText;
    public TMP_Text airRuneText;

    private RuneCollector runeCollector;

    // Start is called before the first frame update
    void Start()
    {
        // Find the RuneCollector on the player object
        runeCollector = FindObjectOfType<RuneCollector>();

        if (runeCollector != null)
        {
            // Subscribe to rune count change events
            runeCollector.runeCountChanged.AddListener(OnRuneCountChanged);
            UpdateRuneDisplays();  // Initialize UI with current counts
        }
        else
        {
            Debug.LogError("RuneCollector not found in the scene!");
        }
    }

    // Update the rune display text when counts change
    private void OnRuneCountChanged(int currentRuneCount, int maxRuneCount)
    {
        if (fireRuneText != null) {
            fireRuneText.text = runeCollector.Fire + "/" + runeCollector.MaxFire;
            Debug.Log("Fire Rune Count: " + runeCollector.Fire + "/" + runeCollector.MaxFire); }
        if (earthRuneText != null) earthRuneText.text = runeCollector.Earth + "/" + runeCollector.MaxEarth;
        if (waterRuneText != null) waterRuneText.text = runeCollector.Water + "/" + runeCollector.MaxWater;
        if (airRuneText != null) airRuneText.text = runeCollector.Air + "/" + runeCollector.MaxAir;
    }

    // Update all rune displays initially
    private void UpdateRuneDisplays()
    {
        OnRuneCountChanged(0, 0);  // This will trigger the initial display update
    }
}
