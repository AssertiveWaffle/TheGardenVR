using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTrack : MonoBehaviour
{
    public AudioSource musicSource;
    public Button nextTrackButton;
    public AudioClip[] musicTracks;
    private int currentTrackIndex = 0;

    void Start()
    {
        // Add an event listener to the next track button
        nextTrackButton.onClick.AddListener(NextSong);
    }

    void NextSong()
    {
        // Increase the track index and wrap around if necessary
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;

        // Load the new track into the music source
        musicSource.clip = musicTracks[currentTrackIndex];

        // Play the new track
        musicSource.Play();
    }
}