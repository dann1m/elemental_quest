using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPickup : MonoBehaviour
{
    private int airPickupValue = 4;
    public AudioClip soundToPlay;
    public float volume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RuneCollector runeCollector = collision.GetComponent<RuneCollector>();
            if (runeCollector != null)
            {
                runeCollector.AddRunes(airPickupValue);
                AudioSource.PlayClipAtPoint(soundToPlay, transform.position, volume);
                Destroy(gameObject);
            }
        }
    }
}
