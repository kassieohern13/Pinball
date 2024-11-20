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

    // Timer settings
    private bool isLaunching = false;

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
        // Check if the launch key is pressed
        if (Input.GetKeyDown(launchKey) && ballRigidbody != null && !isLaunching)
        {
            StartCoroutine(LaunchBallWithDelay());
        }
    }

    IEnumerator LaunchBallWithDelay()
    {
        isLaunching = true;
        Debug.Log("Launching in 1 second...");
        yield return new WaitForSeconds(1f); // Wait for 1 second

        // Apply force in the specified direction
        ballRigidbody.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
        Debug.Log("Ball launched with force: " + forceMagnitude);
        isLaunching = false;
    }
}