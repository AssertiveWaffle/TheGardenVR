using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotHandController : MonoBehaviour
{
    public float grabRadius = 0.1f; // the radius within which pots can be grabbed
    public Transform handTransform; // the transform of the hand

    private PotController currentPot; // reference to the currently grabbed pot
    private Collider[] colliders; // array to store colliders within the grab radius

    void Update()
    {
        if (currentPot)
        {
            currentPot.transform.position = handTransform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pot"))
        {
            colliders = Physics.OverlapSphere(transform.position, grabRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject == other.gameObject)
                {
                    currentPot = other.GetComponent<PotController>();
                    if (currentPot)
                    {
                        currentPot.GrabPot();
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (currentPot && other.gameObject == currentPot.gameObject)
        {
            currentPot.ReleasePot();
            if (currentPot.canStack)
            {
                currentPot.transform.SetParent(null);
            }
            currentPot = null;
        }
    }
}