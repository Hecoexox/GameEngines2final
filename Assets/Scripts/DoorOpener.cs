using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpener : MonoBehaviour
{
    public Transform playerTransform;
    public float destroyDistance = 3f;
    public KeyTracker keyTracker; // Reference to the KeyTracker script
    public DoorType doorType = DoorType.Bronze; // Door type associated with this script
    public Image imageToDelete;
    public float doorOpenSpeed = 90f;
    public bool hasRotated = false;

    // Enum to represent different door types
    public enum DoorType
    {
        Bronze,
        Silver,
        Gold,
        Black,
        // Add more door types if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Check the distance between the player and the object
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        // Check the door type and key availability before destroying
        if (distance < destroyDistance && Input.GetKeyDown(KeyCode.F) && !hasRotated)
        {
            switch (doorType)
            {
                case DoorType.Bronze:
                    if (keyTracker.CanOpenBronzeDoor())
                    {
                        StartCoroutine(RotateOverTime(135f));
                        imageToDelete.gameObject.SetActive(false);
                    }
                    break;

                case DoorType.Silver:
                    if (keyTracker.CanOpenSilverDoor())
                    {
                        StartCoroutine(RotateOverTime(135f));
                        imageToDelete.gameObject.SetActive(false);
                    }
                    break;

                case DoorType.Gold:
                    if (keyTracker.CanOpenGoldDoor())
                    {
                        StartCoroutine(RotateOverTime(135f));
                        imageToDelete.gameObject.SetActive(false);
                    }
                    break;

                case DoorType.Black:
                    if (keyTracker.CanOpenBlackDoor())
                    {
                        StartCoroutine(RotateOverTime(135f));
                        imageToDelete.gameObject.SetActive(false);
                    }
                    break;

                // Add more cases for other door types if needed

                default:
                    break;

                IEnumerator RotateOverTime(float targetAngle)
                {
                    float currentAngle = 0f;

                    while (currentAngle < targetAngle)
                    {
                    float rotation = doorOpenSpeed * Time.deltaTime;
                    transform.Rotate(0f, rotation, 0f);
                    currentAngle += rotation;

                    yield return null; // Wait for the next frame
                    }
                    hasRotated = true;
                }
            }
        }
    }
}
