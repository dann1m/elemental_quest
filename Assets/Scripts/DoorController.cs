using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public UIManager uiManager;
    RuneCollector runeCollector;
    PlayerController playerController;
    Animator doorAnimator;

    public int requiredFireRunes = 5;
    public int requiredEarthRunes = 7;
    public int requiredWaterRunes = 3;
    public int requiredAirRunes = 5;

    private void Start()
    {
        if (uiManager == null)
        {
            Debug.LogError("UIManager not found in the scene!");
        }

        doorAnimator = GetComponent<Animator>();
        if (doorAnimator == null)
        {
            Debug.LogError("Door Animator not found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collision with door");
           
            runeCollector = collision.GetComponent<RuneCollector>();
            playerController = collision.GetComponent<PlayerController>();

            if (runeCollector == null)
            {
                Debug.LogError("RuneCollector not found on the Player!");
                return;
            }

            if (playerController == null)
            {
                Debug.LogError("PlayerController not found on the Player!");
                return;
            }

            if (HasCollectedAllRunes())
            {
                StartCoroutine(WinSequence(collision.gameObject));
                // playerController.OnWin();
                // Invoke(nameof(ShowWinPanel), 1.5f);
                // collision.gameObject.SetActive(false);
            }
            else
            {
                string missingRunesMessage = GetMissingRunesMessage();
                uiManager.ShowLosePanel(missingRunesMessage);
            }
        }
    }

    private bool HasCollectedAllRunes()
    {
        Debug.Log($"Fire: {runeCollector.Fire}, Required: {requiredFireRunes}");
        Debug.Log($"Earth: {runeCollector.Earth}, Required: {requiredEarthRunes}");
        Debug.Log($"Water: {runeCollector.Water}, Required: {requiredWaterRunes}");
        Debug.Log($"Air: {runeCollector.Air}, Required: {requiredAirRunes}");

        return runeCollector.Fire >= requiredFireRunes &&
               runeCollector.Earth >= requiredEarthRunes &&
               runeCollector.Water >= requiredWaterRunes &&
               runeCollector.Air >= requiredAirRunes;
    }

    private string GetMissingRunesMessage()
    {
        int missingFire = Mathf.Max(0, requiredFireRunes - runeCollector.Fire);
        int missingEarth = Mathf.Max(0, requiredEarthRunes - runeCollector.Earth);
        int missingWater = Mathf.Max(0, requiredWaterRunes - runeCollector.Water);
        int missingAir = Mathf.Max(0, requiredAirRunes - runeCollector.Air);

        return $"You still need:\n" +
               $"{missingFire} Fire Runes\n" +
               $"{missingEarth} Earth Runes\n" +
               $"{missingWater} Water Runes\n" +
               $"{missingAir} Air Runes";
    }

    private IEnumerator WinSequence(GameObject player)
    {
        // 1. Play Player's Win Animation
        playerController.OnWin();

        yield return new WaitForSeconds(1.5f); // Wait for player animation

        // 2. Play Door Animation
        doorAnimator.SetTrigger(AnimationStrings.doorTrigger);

        yield return new WaitForSeconds(2.5f); // Wait for door animation

        // 3. Fade Out Player
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
        if (playerRenderer != null)
        {
            float fadeDuration = 2f;
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                Color color = playerRenderer.color;
                color.a = Mathf.Lerp(1f, 0f, t / fadeDuration);
                playerRenderer.color = color;
                yield return null;
            }
            player.SetActive(false); // Deactivate player after fading out
        }

        // 4. Show Win Panel
        uiManager.ShowWinPanel();
    }
    // private void ShowWinPanel()
    // {
    //     if (uiManager == null)
    //     {
    //         Debug.LogError("UIManager reference is missing!");
    //         return;
    //     }

    //     uiManager.ShowWinPanel();
    // }
}
