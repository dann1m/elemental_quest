using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioClip soundToPlay;
    public float volume = 1f;

    private void OnClick()
    {
        AudioSource.PlayClipAtPoint(soundToPlay, transform.position, volume);
    }

}
