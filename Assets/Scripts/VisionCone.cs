using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeInteraction : MonoBehaviour
{
    public Material redVisionCode;
    public Material greenVisionCode;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Renderer coneRenderer = GetComponent<Renderer>();

            coneRenderer.material = redVisionCode;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Renderer coneRenderer = GetComponent<Renderer>();

            coneRenderer.material = greenVisionCode;
        }
    }
}
