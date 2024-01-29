using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30f; // Adjust the speed as needed
    public float minRotation = 95f;   // Minimum rotation value
    public float maxRotation = 168f;  // Maximum rotation value

    void Update()
    {
        // Rotate around Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        
        // Ensure the rotation stays within the specified range
        float currentRotationY = transform.rotation.eulerAngles.y;

        if (currentRotationY > maxRotation)
        {
            rotationSpeed = -Mathf.Abs(rotationSpeed); // Reverse rotation speed
        }
        else if (currentRotationY < minRotation)
        {
            rotationSpeed = Mathf.Abs(rotationSpeed); // Keep positive rotation speed
        }
    }
}
