using System;
using UnityEngine;
using TMPro;

public class BumperPoints : MonoBehaviour
{
    public ParticleSystem jumpertwo; 
    public ParticleSystem jumper;    
    public AudioSource bumperSound;  
    public AudioSource failSound;   
    public TextMeshProUGUI scoreText;

    private int score = 0;        

    private void Start()
    { 
        UpdateScoreText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumper"))
        {
            if (jumpertwo != null) jumpertwo.Play();
            if (jumper != null) jumper.Play();
            if (bumperSound != null) bumperSound.Play();

            score += 100;
            UpdateScoreText();
        }

        if (collision.gameObject.CompareTag("Fail"))
        {
            if (failSound != null) failSound.Play();
            score = 0;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
        else
        {
            Debug.LogError("Score Text is not assigned!");
        }
    }
}