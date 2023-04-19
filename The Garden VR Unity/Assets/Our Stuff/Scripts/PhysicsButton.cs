using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;
    private AudioController audioController;

    public UnityEvent onPressed, onReleased;

    private SceneLoader sceneLoader; // Added reference to SceneLoader script

    private void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
        audioController = GetComponentInParent<AudioController>();
        sceneLoader = FindObjectOfType<SceneLoader>(); // Find the SceneLoader script
        onPressed.AddListener(LoadScene); // Add an event listener to the onPressed event
    }

    private void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }

        if (isPressed && GetValue() - threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Math.Abs(value) < deadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        isPressed = true;
        onPressed?.Invoke();
        if (audioController != null)
        {
            audioController.PlayNextClip();
            audioController.PlayPauseMusic();
            audioController.IncreaseVolume();
            audioController.DecreaseVolume();
        }
        Debug.Log("Pressed");
    }

    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }

    private void LoadScene()
    {
        sceneLoader.LoadScene(); // Call LoadScene method in SceneLoader script
    }
}