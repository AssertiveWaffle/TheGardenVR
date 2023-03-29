using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.UI;

public class RadioController : MonoBehaviour
{
    // reference to the audio source component attached to the radio game object
    public AudioSource audioSource;

    // reference to the UI text component that displays the volume level
    public Text volumeText;

    // reference to the UI button components for controlling the radio
    public Button volumeUpButton;
    public Button volumeDownButton;
    public Button muteButton;
    public Button forwardButton;
    public Button backwardButton;

    // the current volume level of the radio (0-1)
    private float volume = 0.5f;

    // a flag indicating whether the radio is currently muted
    private bool isMuted = false;

    // an array of audio clips representing the available songs
    public AudioClip[] songs;

    // the index of the currently playing song in the songs array
    private int currentSongIndex = 0;

    void Start()
    {
        // set the initial volume level and update the UI text
        audioSource.volume = volume;
        volumeText.text = "Volume: " + Mathf.Round(volume * 100) + "%";

        // set up the UI button click events
        volumeUpButton.onClick.AddListener(OnVolumeUpButtonClick);
        volumeDownButton.onClick.AddListener(OnVolumeDownButtonClick);
        muteButton.onClick.AddListener(OnMuteButtonClick);
        forwardButton.onClick.AddListener(OnForwardButtonClick);
        backwardButton.onClick.AddListener(OnBackwardButtonClick);

        // start playing the first song in the songs array
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();
    }

    void Update()
    {
        // check if the user has pressed the spacebar to pause/unpause the radio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.UnPause();
            }
        }
    }

    void OnVolumeUpButtonClick()
    {
        // increase the volume level by 0.1 (up to a maximum of 1)
        volume = Mathf.Clamp01(volume + 0.1f);

        // update the audio source volume and UI text
        audioSource.volume = volume;
        volumeText.text = "Volume: " + Mathf.Round(volume * 100) + "%";
    }

    void OnVolumeDownButtonClick()
    {
        // decrease the volume level by 0.1 (down to a minimum of 0)
        volume = Mathf.Clamp01(volume - 0.1f);

        // update the audio source volume and UI text
        audioSource.volume = volume;
        volumeText.text = "Volume: " + Mathf.Round(volume * 100) + "%";
    }

    void OnMuteButtonClick()
    {
        // toggle the isMuted flag and update the audio source volume and UI text accordingly
        isMuted = !isMuted;

        if (isMuted)
        {
            audioSource.volume = 0;
            volumeText.text = "Muted";
        }
        else
        {
            audioSource.volume = volume;
            volumeText.text = "Volume: " + Mathf.Round(volume * 100) + "%";
        }
    }

    void OnForwardButtonClick()
    {
        // stop the current song
        audioSource.Stop();

        // increment the current song index (wrapping around if necessary)
        currentSongIndex = (currentSongIndex + 1) % songs.Length;

        // start playing the new song
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();
    }

    void OnBackwardButtonClick()
    {
        // stop the current song
        audioSource.Stop();

        // decrement the current song index (wrapping around if necessary)
        currentSongIndex = (currentSongIndex - 1 + songs.Length) % songs.Length;

        // start playing the new song
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();
    }
}