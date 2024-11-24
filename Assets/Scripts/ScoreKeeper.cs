using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the score UI
    public GameObject ball;          // Reference to the ball GameObject
    private int score = 0;           // Initialize score

    private void Start()
    {
        // Initialize the score display
        scoreText.text = score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the ball is involved in the collision
        if (collision.gameObject == ball)
        {
            // Loop through all contact points to find if the ball hit a bumper
            foreach (ContactPoint contact in collision.contacts)
            {
                if (contact.otherCollider.CompareTag("Bumper"))
                {
                    Debug.Log("yay!!");
                    // Increment score and update the score display
                    score++;
                    scoreText.text = score.ToString();
                    return; // Exit after handling the first bumper hit
                }
            }
        }
    }
}
