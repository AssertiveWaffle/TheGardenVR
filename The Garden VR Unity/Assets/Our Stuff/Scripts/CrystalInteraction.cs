using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class CrystalInteraction : MonoBehaviour
{
    public AudioClip soundEffect;
    public float volume = 1f;
    public float pitchMin = 0.5f;
    public float pitchMax = 2f;

    private AudioSource audioSource;
    private bool isCrystalInContactWithBowl = false;
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.volume = volume;

        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
        }
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bowl"))
        {
            isCrystalInContactWithBowl = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bowl"))
        {
            isCrystalInContactWithBowl = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isCrystalInContactWithBowl && collision.gameObject.CompareTag("Bowl"))
        {
            audioSource.clip = soundEffect;
            audioSource.pitch = Random.Range(pitchMin, pitchMax);
            audioSource.Play();
        }
    }
}