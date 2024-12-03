using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BumperPoints : MonoBehaviour
{
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
            score += 100;
            UpdateScoreText();
        }
        if (collision.gameObject.CompareTag("Fail"))
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