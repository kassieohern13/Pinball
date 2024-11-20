using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    public Transform targetPosition; 

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Fail"))
        {
           
            if (targetPosition != null)
            {
                transform.position = targetPosition.position;
                Debug.Log("Ball moved to the target position.");
            }
            else
            {
                Debug.LogWarning("Target position is not assigned!");
            }
        }
    }
}
