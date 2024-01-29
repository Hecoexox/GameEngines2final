using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    public Image imageToShow;
    public KeyTracker keyTracker; // Reference to the KeyTracker script

    private void Start()
    {
        // Ensure that keyTracker is assigned
        if (keyTracker == null)
        {
            Debug.LogError("KeyTracker reference is not set in KeyPickup script!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("BronzeKey"))
            {
                keyTracker.hasBronzeKey = true;
            }
            else if (gameObject.CompareTag("SilverKey"))
            {
                keyTracker.hasSilverKey = true;
            }
            else if (gameObject.CompareTag("GoldKey"))
            {
                keyTracker.hasGoldKey = true;
            }
            else if (gameObject.CompareTag("BlackKey"))
            {
                keyTracker.hasBlackKey = true;
            }

            // Show the image on the canvas
            if (imageToShow != null)
            {
                imageToShow.gameObject.SetActive(true);
            }

            // Optionally, destroy the object with this script attached to it
            Destroy(gameObject);
        }
    }
}
