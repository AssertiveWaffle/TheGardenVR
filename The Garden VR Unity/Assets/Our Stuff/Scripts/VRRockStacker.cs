using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class VRRockStacker : MonoBehaviour
{
    public float stackHeight = 0.5f; // The height of each stacked rock
    public InputActionReference pickUpRockAction; // The InputActionReference for picking up a rock

    private GameObject currentRock; // The rock object that the user is currently holding
    private Vector3 dragOffset; // The offset between the controller and the center of the rock being dragged

    private void OnEnable()
    {
        pickUpRockAction.action.Enable();
        pickUpRockAction.action.performed += PickUpRock;
        pickUpRockAction.action.canceled += ReleaseRock;
    }

    private void OnDisable()
    {
        pickUpRockAction.action.Disable();
        pickUpRockAction.action.performed -= PickUpRock;
        pickUpRockAction.action.canceled -= ReleaseRock;
    }

    private void PickUpRock(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            // Check if the object hit is a rock
            if (hit.collider.CompareTag("Rock"))
            {
                // Pick up the rock and set up for dragging
                currentRock = hit.collider.gameObject;
                dragOffset = currentRock.transform.position - transform.position;
                currentRock.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    private void ReleaseRock(InputAction.CallbackContext context)
    {
        if (currentRock != null)
        {
            // Snap the rock to the grid and release it
            currentRock.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 pos = currentRock.transform.position;
            pos.y = Mathf.Round(pos.y / stackHeight) * stackHeight; // Round to the nearest stackHeight
            currentRock.transform.position = pos;
            currentRock = null;
        }
    }

    private void Update()
    {
        if (currentRock != null)
        {
            // Move the rock with the controller position
            currentRock.transform.position = transform.position + dragOffset;
        }
    }
}