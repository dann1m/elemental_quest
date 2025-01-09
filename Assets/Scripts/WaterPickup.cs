using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPickup : MonoBehaviour
{
    private int waterPickupValue = 3;
    public AudioClip soundToPlay;
    public float volume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RuneCollector runeCollector = collision.GetComponent<RuneCollector>();
            if (runeCollector != null)
            {
                runeCollector.AddRunes(waterPickupValue);
                AudioSource.PlayClipAtPoint(soundToPlay, transform.position, volume);
                Destroy(gameObject);
            }
        }
    }
}
