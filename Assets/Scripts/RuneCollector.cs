using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RuneCollector : MonoBehaviour
{
    public UnityEvent<int, int> runeCountChanged;  // Event for notifying rune count change
    private int[] runes = new int[4];  // Array to store counts of different rune types

    // Maximum rune counts for each type
    [SerializeField]
    private int _maxFire = 5;
    [SerializeField]
    private int _maxEarth = 7;
    [SerializeField]
    private int _maxWater = 3;
    [SerializeField]
    private int _maxAir = 5;

    public int MaxFire { get => _maxFire; set => _maxFire = value; }
    public int MaxEarth { get => _maxEarth; set => _maxEarth = value; }
    public int MaxWater { get => _maxWater; set => _maxWater = value; }
    public int MaxAir { get => _maxAir; set => _maxAir = value; }

    // Current rune counts
    [SerializeField]
    private int _fire = 5;
    [SerializeField]
    private int _earth = 7;
    [SerializeField]
    private int _water = 3;
    [SerializeField]
    private int _air = 5;

    public int Fire
    {
        get => _fire;
        set
        {
            _fire = value;
            runeCountChanged?.Invoke(_fire, MaxFire);  // Invoke event to update UI
        }
    }

    public int Earth
    {
        get => _earth;
        set
        {
            _earth = value;
            runeCountChanged?.Invoke(_earth, MaxEarth);
        }
    }

    public int Water
    {
        get => _water;
        set
        {
            _water = value;
            runeCountChanged?.Invoke(_water, MaxWater);
        }
    }

    public int Air
    {
        get => _air;
        set
        {
            _air = value;
            runeCountChanged?.Invoke(_air, MaxAir);
        }
    }

    // Function to add runes
    public void AddRunes(int rune)
    {
        switch (rune)
        {
            case 1:
                runes[0]++;
                Fire = runes[0];  // Update Fire rune count
                break;
            case 2:
                runes[1]++;
                Earth = runes[1];  // Update Earth rune count
                break;
            case 3:
                runes[2]++;
                Water = runes[2];  // Update Water rune count
                break;
            case 4:
                runes[3]++;
                Air = runes[3];  // Update Air rune count
                break;
            default:
                Debug.LogWarning("Invalid rune type");
                break;
        }
        Debug.Log($"(Type 1: {runes[0]}, Type 2: {runes[1]}, Type 3: {runes[2]}, Type 4: {runes[3]})");
    }
}
