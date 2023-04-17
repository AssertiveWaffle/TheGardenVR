using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneLoader : MonoBehaviour
{
    public string sceneName; // Name of the scene to load
    private bool canLoadScene = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Press 'E' to load the scene");
            canLoadScene = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left trigger zone");
            canLoadScene = false;
        }
    }

    private void Update()
    {
        if (canLoadScene && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("Button Pressed");
        }
    }
}