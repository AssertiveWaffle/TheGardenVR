using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class PotController : MonoBehaviour
{
    public float maxScale = 2f; // the maximum scale the pot can grow to
    public float minScale = 0.5f; // the minimum scale the pot can shrink to
    public float growSpeed = 0.5f; // the speed at which the pot grows and shrinks
    public float stackThreshold = 0.1f; // the threshold for stacking pots

    public bool isGrabbed = false; // flag to indicate if the pot is currently being grabbed
    public bool canStack = true; // flag to indicate if the pot can be stacked with other pots

    private Vector3 startPosition; // the starting position of the pot
    private Quaternion startRotation; // the starting rotation of the pot
    private Rigidbody rb; // reference to the pot's rigidbody

    [SerializeField] private InputActionProperty triggerAction; // reference to the trigger input action

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;

        triggerAction.action.Enable();
    }

    void OnDestroy()
    {
        triggerAction.action.Disable();
    }

    void Update()
    {
        if (isGrabbed)
        {
            Vector3 controllerPosition = triggerAction.action.ReadValue<Vector3>();

            transform.position = controllerPosition;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pot") && canStack && other.transform.parent == null)
        {
            PotController otherPot = other.GetComponent<PotController>();
            if (otherPot && transform.localScale.x > otherPot.transform.localScale.x && !otherPot.isGrabbed)
            {
                other.transform.SetParent(transform);
                other.transform.localPosition = Vector3.up * (transform.localScale.y + other.transform.localScale.y) / 2f;
                rb.mass += other.GetComponent<Rigidbody>().mass;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pot") && canStack && other.transform.parent == transform)
        {
            PotController otherPot = other.GetComponent<PotController>();
            if (otherPot)
            {
                other.transform.SetParent(null);
                other.transform.position = startPosition;
                other.transform.rotation = startRotation;
                other.GetComponent<Rigidbody>().mass = otherPot.rb.mass;
            }
        }
    }

    public void GrabPot()
    {
        isGrabbed = true;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void ReleasePot()
    {
        isGrabbed = false;
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    public void GrowPot()
    {
        float newScale = transform.localScale.x + growSpeed * Time.deltaTime;
        newScale = Mathf.Clamp(newScale, minScale, maxScale);
        transform.localScale = Vector3.one * newScale;
        rb.mass = newScale;
    }

    public void ShrinkPot()
    {
        float newScale = transform.localScale.x - growSpeed * Time.deltaTime;
        newScale = Mathf.Clamp(newScale, minScale, maxScale);
        transform.localScale = Vector3.one * newScale;
        rb.mass = newScale;
    }
}