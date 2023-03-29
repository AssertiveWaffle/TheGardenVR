using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BookController : MonoBehaviour
{
    // reference to the shelf gameobject
    public GameObject shelf;

    // whether or not the book is currently being held
    private bool isHeld = false;

    // the distance from the player's hand to the book's center when picked up
    private float pickupDistance;

    // reference to the player's hand transform
    private Transform handTransform;

    // reference to the book's rigidbody
    private Rigidbody bookRigidbody;

    // input action for picking up and releasing the book
    public InputActionProperty pickupAction;

    private void Start()
    {
        // get references to the player's hand transform and book rigidbody
        handTransform = GameObject.Find("Hand").transform;
        bookRigidbody = GetComponent<Rigidbody>();

        // bind the pickup action to the input system
        pickupAction.action.Enable();
        pickupAction.action.performed += _ => OnPickupAction();
        pickupAction.action.canceled += _ => OnPickupAction();
    }

    private void OnPickupAction()
    {
        if (isHeld)
        {
            // release the book and apply a small amount of force to it
            bookRigidbody.AddForce(handTransform.forward * 100);
            isHeld = false;
        }
        else
        {
            // pick up the book
            RaycastHit hit;
            if (Physics.Raycast(handTransform.position, handTransform.forward, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // calculate the distance from the player's hand to the book's center when picked up
                    pickupDistance = Vector3.Distance(handTransform.position, transform.position);

                    isHeld = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (isHeld)
        {
            // update the book's position to be in front of the player's hand
            transform.position = handTransform.position + handTransform.forward * pickupDistance;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == shelf && isHeld)
        {
            // snap the book to the shelf if it's close enough
            float distance = Vector3.Distance(transform.position, shelf.transform.position);
            if (distance < 0.5f)
            {
                transform.position = shelf.transform.position + shelf.transform.forward * 0.5f;
                isHeld = false;
            }
        }
    }

    private void OnDisable()
    {
        // unbind the pickup action from the input system
        pickupAction.action.performed -= _ => OnPickupAction();
        pickupAction.action.canceled -= _ => OnPickupAction();
        pickupAction.action.Disable();
    }
}