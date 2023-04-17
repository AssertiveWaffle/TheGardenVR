using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{

    public AudioSource musicSource;
    public AudioClip[] musicTracks;
    private int currentTrackIndex = 0;


    void Start()
    {
        // Load the first music track and set it as the current track
        musicSource.clip = musicTracks[0];
        musicSource.Play();
    }
    private void OnTriggerEnter(Collider other)
        {
        Debug.Log("Colliding with " + other.gameObject.name);
        if (other.CompareTag("PlayPause"))
            {
                Debug.Log("Play/Pause");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PlayPauseMusic();
                    
                }
            }
            else if (other.CompareTag("VolumeUp"))

            {
                Debug.Log("VUP");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    IncreaseVolume();
                }
            }
            else if (other.CompareTag("VolumeDown"))
            {
                Debug.Log("VDown");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DecreaseVolume();
                }
            }
            else if (other.CompareTag("ChangeTrack"))
            {
                Debug.Log("Change");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ChangeTrack();
                }
            }
        }

        private void PlayPauseMusic()
        {
            if (musicSource.isPlaying)
            {
                musicSource.Pause();
            }
            else
            {
                musicSource.Play();
            }
        }

        private void IncreaseVolume()
        {
            musicSource.volume += 0.1f;
        }

        private void DecreaseVolume()
        {
            musicSource.volume -= 0.1f;
        }

        private void ChangeTrack()
        {
            // Increment the current track index
            currentTrackIndex++;

            // If the index goes beyond the array length, reset it to 0
            if (currentTrackIndex >= musicTracks.Length)
            {
                currentTrackIndex = 0;
            }

            // Set the current track to the AudioClip at the current index
            musicSource.clip = musicTracks[currentTrackIndex];

            // Play the new track
            musicSource.Play();
        }
    }

