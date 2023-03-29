using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class StringPull : MonoBehaviour
{
    public GameObject lightbulb;
    public float maxDistance = 10f;
    public float pullSpeed = 1f;

    private bool isPulling = false;
    private float currentDistance = 0f;
    private Vector3 initialLightbulbPosition;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        initialLightbulbPosition = lightbulb.transform.position;
        grabInteractable = lightbulb.GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        grabInteractable.onSelectExited.AddListener(OnReleased);
    }

    void Update()
    {
        if (isPulling && currentDistance < maxDistance)
        {
            currentDistance += pullSpeed * Time.deltaTime;
            Vector3 newPosition = initialLightbulbPosition - new Vector3(0, currentDistance, 0);
            lightbulb.transform.position = newPosition;
        }
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        isPulling = true;
    }

    private void OnReleased(XRBaseInteractor interactor)
    {
        isPulling = false;
        currentDistance = 0f;
        lightbulb.transform.position = initialLightbulbPosition;
    }
}