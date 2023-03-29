using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float turnSpeed = 5.0f;
    public float waterLevel = 0.5f;
    public Animation duckAnimation;

    private bool isInWater = false;

    void Update()
    {
        if (isInWater)
        {
            transform.position = new Vector3(transform.position.x, waterLevel, transform.position.z);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            if (duckAnimation != null)
            {
                duckAnimation.Play();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
        }
    }
}