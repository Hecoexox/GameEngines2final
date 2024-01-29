using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Awareness : MonoBehaviour
{
    public float awarenessRate = 1.0f; // Adjust the rate at which awareness increases
    public Slider awarenessSlider; // Reference to your UI Slider
    public float maxAwareness = 100.0f; // Maximum awareness value

    private bool isNearGuard = false;
    public GameObject respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Guard"))
        {
            isNearGuard = true;
            Debug.Log("Entered Guard's Trigger Zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Guard"))
        {
            isNearGuard = false;
            Debug.Log("Exited Guard's Trigger Zone");
        }
    }

    private void Update()
    {
        if (isNearGuard)
        {
            IncreaseAwareness();
        }
        else
        {
            DecreaseAwareness();
        }
    }

    private void IncreaseAwareness()
    {
        // Increase awareness gradually
        awarenessSlider.value += awarenessRate * Time.deltaTime;

        // Check if awareness has reached the maximum
        if (awarenessSlider.value >= maxAwareness)
        {
            HandleCaught();
        }
    }

    private void DecreaseAwareness()
    {
        if (awarenessSlider == null || awarenessSlider.value <= 0f) return;

        // Decrease awareness gradually when not near a guard
        awarenessSlider.value -= awarenessRate * Time.deltaTime;
    }

    private void HandleCaught()
    {
        Debug.Log("You Got Caught");

        // Respawn the player at the designated respawn point
        RespawnPlayer();
    }

    public void RespawnPlayer()
    {
        // Check if a respawn point is assigned
        if (respawnPoint != null)
        {
            // Move the player to the respawn point
            transform.position = respawnPoint.transform.position;
            // Reset awareness to zero after respawn
            awarenessSlider.value = 0f;
        }
        else
        {
            Debug.LogError("Respawn point is not assigned!");
            // You may want to add additional handling here, such as restarting the level
            // or telegraphing the error to the user.
        }
    }

}
