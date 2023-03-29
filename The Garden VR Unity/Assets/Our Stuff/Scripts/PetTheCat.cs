using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetTheCat : MonoBehaviour
{
    public float pettingForce = 10f;
    public float maxDistance = 0.1f;
    public Animation catAnimation;

    private bool isBeingPetted = false;

    void Update()
    {
        if (isBeingPetted && Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Vector3 force = (hit.point - transform.position).normalized * pettingForce;
                    GetComponent<Rigidbody>().AddForceAtPosition(force, hit.point);
                    if (catAnimation != null)
                    {
                        catAnimation.Play();
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isBeingPetted = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isBeingPetted = false;
        }
    }
}