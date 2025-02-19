using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Reference to the audio clip to play when a bullet is fired
    [SerializeField] private AudioClip bulletFireSound;

    // Reference to the AudioSource component
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Subscribe the PlaySound method to the bulletFired event
        BulletEvents.bulletFired.AddListener(PlaySound);
    }

    // Method to play the sound when a bullet is fired
    private void PlaySound(int bulletNumber)
    {
        if (audioSource != null && bulletFireSound != null)
        {
            audioSource.PlayOneShot(bulletFireSound);
            //PlayOneShot is used to play a sound once on each shot fired if I've used Play instead it would have played the sound only once
        }
        else
        {
            Debug.LogWarning("AudioSource or BulletFireSound is missing.");
        }
    }
}