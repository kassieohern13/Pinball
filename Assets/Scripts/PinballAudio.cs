using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballAudio : MonoBehaviour
{
    public AudioClip wallHitSound;   // Audio clip for wall hit
    public AudioClip bumperHitSound; // Audio clip for bumper hit
    public AudioClip flipperHitSound; // Audio clip for flipper hit
    public AudioClip drainSound; // Audio clip for drain hit

    private AudioSource audioSource; // Reference to AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the ball
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check the object that was collided with and play the corresponding sound
       // if (collision.gameObject.CompareTag("Wall"))
       // {
       //     PlaySound(wallHitSound);
       // }
       if (collision.gameObject.CompareTag("Bumper"))
        {
            PlaySound(bumperHitSound);
        }
       // else if (collision.gameObject.CompareTag("Flipper"))
       // {
       //     PlaySound(flipperHitSound);
       // }
       // else if (collision.gameObject.CompareTag("Drain"))
       // {
        //    PlaySound(drainSound);
        //}
    }

    // Helper function to play sound
    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
