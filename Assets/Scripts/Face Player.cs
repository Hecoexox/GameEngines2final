using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        // Assuming your player has a tag "Player". Adjust this if necessary.
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found. Make sure the player has the tag 'Player'.");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the direction from the object to the player.
            Vector3 lookDirection = playerTransform.position - transform.position;

            // Ensure the object only rotates around the Y-axis to face the player.
            lookDirection.y = 0;

            // Rotate the object to face the player.
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}
