using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPause : MonoBehaviour
{
    public AudioSource musicSource;
    public Button playPauseButton;

    private bool isPlaying = false;

    void Start()
    {
        // Add an event listener to the play/pause button
        playPauseButton.onClick.AddListener(PlayPauseMusic);
    }

    void PlayPauseMusic()
    {
        if (isPlaying)
        {
            // Pause the music
            musicSource.Pause();
            playPauseButton.GetComponentInChildren<Text>().text = "Play";
        }
        else
        {
            // Play the music
            musicSource.Play();
            playPauseButton.GetComponentInChildren<Text>().text = "Pause";
        }

        // Toggle the playing state
        isPlaying = !isPlaying;
    }
}