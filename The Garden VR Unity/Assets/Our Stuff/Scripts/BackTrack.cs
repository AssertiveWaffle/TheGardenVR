using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackTrack : MonoBehaviour
{
    public AudioSource musicSource;
    public Button previousTrackButton;
    public AudioClip[] musicTracks;
    private int currentTrackIndex = 0;

    void Start()
    {
        // Add an event listener to the previous track button
        previousTrackButton.onClick.AddListener(PreviousTrack);
    }

    void PreviousTrack()
    {
        // Decrease the track index and wrap around if necessary
        currentTrackIndex = (currentTrackIndex - 1 + musicTracks.Length) % musicTracks.Length;

        // Load the new track into the music source
        musicSource.clip = musicTracks[currentTrackIndex];

        // Play the new track
        musicSource.Play();
    }
}