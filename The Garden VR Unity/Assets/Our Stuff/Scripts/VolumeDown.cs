using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeDown : MonoBehaviour
{
    public AudioSource musicSource;
    public Button volumeDownButton;
    public float volumeDecrement = 0.1f;

    void Start()
    {
        // Add an event listener to the volume down button
        volumeDownButton.onClick.AddListener(DecreaseVolume);
    }

    void DecreaseVolume()
    {
        // Decrease the music volume by the specified decrement
        musicSource.volume -= volumeDecrement;
    }
}