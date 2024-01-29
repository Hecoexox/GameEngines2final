using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    public float turningSpeed = 10f; // Adjust this value to control the turning speed
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            PlayerLocomotion playerLocomotion = player.GetComponent<PlayerLocomotion>();

            if (playerLocomotion != null && playerLocomotion.isSprinting)
            {
                // Calculate the direction from the enemy to the player
                Vector3 directionToPlayer = player.transform.position - transform.position;

                // Calculate the rotation needed to face the player
                Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

                // Smoothly rotate towards the player with adjustable turning speed
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turningSpeed * Time.deltaTime);
            }
        }
    }
}
