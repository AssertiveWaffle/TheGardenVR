using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName; // Name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player collided with the button
        {
            // Display message to player to press E
            Debug.Log("Press 'E' to load the scene");

            // Wait for the player to press E
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                SceneManager.LoadScene(sceneName); // Load the specified scene
            }
        }
    }
}