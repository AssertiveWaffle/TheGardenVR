using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip[] musicTracks;

    void Start()
    {
        // Load the first track into the music source and play it
        musicSource.clip = musicTracks[0];
        musicSource.Play();
    }
}