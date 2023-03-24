using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip backgroundMusic;  // The audio clip for the background music

    private AudioSource audioSource;   // The audio source component

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  // Get the audio source component
        audioSource.clip = backgroundMusic;         // Set the audio clip to play
        audioSource.loop = true;                    // Loop the audio clip
        audioSource.Play();                         // Play the audio clip
    }

    void Update()
    {
        // Check if the audio clip is playing
        if (!audioSource.isPlaying)
        {
            // If it's not playing, play it again
            audioSource.Play();
        }
    }
}
