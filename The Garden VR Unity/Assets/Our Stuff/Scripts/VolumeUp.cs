using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUp : MonoBehaviour
{
    public AudioSource musicSource;
    public Button volumeUpButton;
    public float volumeIncrement = 0.1f;

    void Start()
    {
        // Add an event listener to the volume up button
        volumeUpButton.onClick.AddListener(IncreaseVolume);
    }

    void IncreaseVolume()
    {
        // Increase the music volume by the specified increment
        musicSource.volume += volumeIncrement;
    }
}