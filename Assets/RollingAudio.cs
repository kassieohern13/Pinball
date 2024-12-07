using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingAudio : MonoBehaviour
{
    public float maxVolume = 1.0f; // The maximum volume of the audio source
    public float maxVelocity = 10.0f; // The velocity at which the volume will reach its max
    public float minVolume = 0.0f; // Minimum volume when velocity is zero

    private Rigidbody rb;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        // Ensure the AudioSource is enabled
        if (audioSource != null)
        {
            audioSource.playOnAwake = true;
            audioSource.loop = true;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    void Update()
    {
        if (rb != null && audioSource != null)
        {
            // Calculate the velocity magnitude
            float velocityMagnitude = rb.velocity.magnitude;

            // Map velocity to volume
            float normalizedVelocity = Mathf.Clamp01(velocityMagnitude / maxVelocity);
            audioSource.volume = Mathf.Lerp(minVolume, maxVolume, normalizedVelocity);
        }
    }
}
