using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    public float moveDistance = 2.0f;   
    public float moveSpeed = 2.0f;     
    public float holdTime = 1.0f;     
    public Vector3 moveDirection = Vector3.back; 

    private Vector3 obj1OriginalPosition;
    private Vector3 obj2OriginalPosition;

    private bool isMovingBack = false;
    private bool isReturning = false;
    private bool isHolding = false;
    private float holdTimer = 0f;

    [Header("Launch Control")]
    public PinballForce pinballForce; // Reference to PinballForce script

    void Start()
    {
        if (object1 != null && object2 != null)
        {
            obj1OriginalPosition = object1.transform.position;
            obj2OriginalPosition = object2.transform.position;
        }

        if (pinballForce == null)
        {
            Debug.LogError("PinballForce reference not assigned. Please link it in the inspector.");
        }
    }

    void Update()
    {
        // Check if the spring action should start
        if (Input.GetKeyDown(KeyCode.S) && pinballForce != null && pinballForce.canLaunch)
        {
            if (!isMovingBack && !isReturning && !isHolding)
            {
                isMovingBack = true;

                // Disable further launches during spring action
                pinballForce.canLaunch = false;
            }
        }

        if (isMovingBack)
        {
            MoveObjectsBack();
        }
        else if (isHolding)
        {
            HoldObjects();
        }
        else if (isReturning)
        {
            ReturnObjectsToOriginalPosition();
        }
    }

    void MoveObjectsBack()
    {
        Vector3 obj1TargetPosition = obj1OriginalPosition + object1.transform.TransformDirection(moveDirection) * moveDistance;
        Vector3 obj2TargetPosition = obj2OriginalPosition + object2.transform.TransformDirection(moveDirection) * moveDistance;

        object1.transform.position = Vector3.MoveTowards(object1.transform.position, obj1TargetPosition, moveSpeed * Time.deltaTime);
        object2.transform.position = Vector3.MoveTowards(object2.transform.position, obj2TargetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(object1.transform.position, obj1TargetPosition) < 0.01f &&
            Vector3.Distance(object2.transform.position, obj2TargetPosition) < 0.01f)
        {
            isMovingBack = false;
            isHolding = true;
            holdTimer = holdTime;
        }
    }

    void HoldObjects()
    {
        holdTimer -= Time.deltaTime;

        if (holdTimer <= 0)
        {
            isHolding = false;
            isReturning = true;
        }
    }

    void ReturnObjectsToOriginalPosition()
    {
        object1.transform.position = Vector3.MoveTowards(object1.transform.position, obj1OriginalPosition, moveSpeed * Time.deltaTime);
        object2.transform.position = Vector3.MoveTowards(object2.transform.position, obj2OriginalPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(object1.transform.position, obj1OriginalPosition) < 0.01f &&
            Vector3.Distance(object2.transform.position, obj2OriginalPosition) < 0.01f)
        {
            isReturning = false;

            // Apply force to the rigidbodies
            Rigidbody rb1 = object1.GetComponent<Rigidbody>();
            Rigidbody rb2 = object2.GetComponent<Rigidbody>();

            if (rb1 != null)
            {
                rb1.AddForce(Vector3.up * 50f, ForceMode.Impulse); // Adjust the direction and magnitude as needed
            }

            if (rb2 != null)
            {
                rb2.AddForce(Vector3.up * 50f, ForceMode.Impulse); // Adjust the direction and magnitude as needed
            }

            // Re-enable launching after spring action is complete
     
        }
    }
}
