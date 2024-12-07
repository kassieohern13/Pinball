using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballForce : MonoBehaviour
{
    // Force settings
    [Header("Force Settings")]
    public Vector3 forceDirection = new Vector3(0, 0, 1); // Adjust direction as needed
    public float forceMagnitude = 20f;

    // Input settings
    [Header("Input Settings")]
    public KeyCode launchKey = KeyCode.S;

    // Cached Rigidbody
    private Rigidbody ballRigidbody;

    // Launch availability
    public bool canLaunch = true;

    void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        ballRigidbody = GetComponent<Rigidbody>();

        if (ballRigidbody == null)
        {
            Debug.LogError("No Rigidbody component found on this GameObject. Please attach a Rigidbody.");
        }
    }

    void Update()
    {
        // Check if the launch key is pressed and launching is allowed
        if (Input.GetKeyDown(launchKey) && ballRigidbody != null && canLaunch)
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        // Apply force in the specified direction
        ballRigidbody.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
        Debug.Log("Ball launched with force: " + forceMagnitude);

        // Disable further launches until reset
        canLaunch = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reset launch capability when colliding with a "Fail" tagged object
        if (collision.gameObject.CompareTag("Fail"))
        {
            canLaunch = true;
            Debug.Log("Ball reset. Launch available again.");
        }
    }
}