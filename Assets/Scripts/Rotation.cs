using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // Adjust the speed as needed
    public bool isSprinting = false;

    void Update()
    {
        if (isSprinting)
        {
            // Implement the locking on logic here when sprinting
            // For example, you can call a method to handle locking on to the player
            LockOnToPlayer();
        }
        else
        {
            // Rotate the object around its up axis (vertical axis)
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    // Call this method to start locking on to the player
    void LockOnToPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Calculate the direction from the object to the player
            Vector3 directionToPlayer = player.transform.position - transform.position;

            // Calculate the rotation needed to face the player
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

            // Smoothly rotate towards the player with adjustable turning speed
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // Call this method to set the sprinting state from external scripts
    public void SetSprinting(bool sprinting)
    {
        isSprinting = sprinting;
    }
}
