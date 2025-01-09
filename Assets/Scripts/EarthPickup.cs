using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPickup : MonoBehaviour
{
    private int earthPickupValue = 2;
    public AudioClip soundToPlay;
    public float volume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RuneCollector runeCollector = collision.GetComponent<RuneCollector>();
            if (runeCollector != null)
            {
                runeCollector.AddRunes(earthPickupValue);
                AudioSource.PlayClipAtPoint(soundToPlay, transform.position, volume);
                Destroy(gameObject);
            }
        }
    }
}
