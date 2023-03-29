using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float minScale = 0.5f; // the minimum scale of the ball
    public float maxScale = 2.0f; // the maximum scale of the ball
    public float scaleSpeed = 1.0f; // the speed at which the ball scales up and down

    private bool growing = true; // flag to keep track of whether the ball is currently growing or shrinking
    private float currentScale; // the current scale of the ball

    void Start()
    {
        currentScale = minScale; // set the initial scale of the ball to the minimum scale
    }

    void Update()
    {
        if (growing)
        {
            currentScale += scaleSpeed * Time.deltaTime; // increase the current scale by the scale speed
            if (currentScale >= maxScale)
            {
                growing = false; // switch to shrinking mode when the ball reaches the maximum scale
            }
        }
        else
        {
            currentScale -= scaleSpeed * Time.deltaTime; // decrease the current scale by the scale speed
            if (currentScale <= minScale)
            {
                growing = true; // switch to growing mode when the ball reaches the minimum scale
            }
        }

        transform.localScale = new Vector3(currentScale, currentScale, currentScale); // update the scale of the ball
    }
}