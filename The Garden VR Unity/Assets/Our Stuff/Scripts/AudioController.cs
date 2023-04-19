using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    private int currentClipIndex = 0;
    public float volumeIncrement = 0.1f;

    private void Start()
    {
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextClip();
        }
    }

    public void PlayPauseMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
        Debug.Log("Play/Pause");
    }

    public void IncreaseVolume()
    {
        audioSource.volume = Mathf.Clamp(audioSource.volume + volumeIncrement, 0, 1);
        Debug.Log("IncreaseVolume");
    }

    public void DecreaseVolume()
    {
        audioSource.volume = Mathf.Clamp(audioSource.volume - volumeIncrement, 0, 1);
        Debug.Log("DecreaseVolume");
    }

    public void PlayNextClip()
    {
        currentClipIndex = (currentClipIndex + 1) % audioClips.Length;
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();
        Debug.Log("PlayNextClip");
    }
}
