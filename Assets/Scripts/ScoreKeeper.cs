using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    private int score = 0;          
    private void Start()
    {
        
        UpdateScoreText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ball"))
        {
            score = 0;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        Debug.Log("works");
        scoreText.text = score.ToString();
    }
}