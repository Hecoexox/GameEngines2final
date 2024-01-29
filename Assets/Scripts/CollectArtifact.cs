using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleManager : MonoBehaviour
{
    public float activationDistance = 3f;
    private bool isPlayerNear = false;
    private List<GameObject> collectibles = new List<GameObject>();
    private int totalCollectibles;  // Remove the initial assignment

    public Text collectiblesCountText;

    void Start()
    {
        // Find all GameObjects with the "Collectible" tag
        GameObject[] collectibleObjects = GameObject.FindGameObjectsWithTag("Collectible");

        collectibles.AddRange(collectibleObjects);
        totalCollectibles = collectibles.Count; // Set the total count here

        UpdateCollectiblesCountText(); // Ensure count starts at 0/3 initially
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
        {
            CollectNearbyCollectible();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void CollectNearbyCollectible()
    {
        if (collectibles.Count > 0)
        {
            GameObject currentCollectible = collectibles[0];
            collectibles.RemoveAt(0);

            // Deactivate the current collectible or perform any other desired actions
            currentCollectible.SetActive(false);

            UpdateCollectiblesCountText();
        }
    }

    void UpdateCollectiblesCountText()
    {
        int collectedCount = totalCollectibles - collectibles.Count;
        collectiblesCountText.text = $"{collectedCount}/{totalCollectibles} items collected";
    }
}
