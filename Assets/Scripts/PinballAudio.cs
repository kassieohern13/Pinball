using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballAudio : MonoBehaviour
{
    public AudioClip wallHitSound;   
    public AudioClip bumperHitSound; 
    public AudioClip flipperHitSound; 
    public AudioClip drainSound; 

    private AudioSource audioSource; 

    void Start()
    {
        
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
