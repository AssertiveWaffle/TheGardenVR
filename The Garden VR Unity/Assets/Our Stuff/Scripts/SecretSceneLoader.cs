using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretSceneLoader : MonoBehaviour
{
    private string secretSceneName = "Secret";

    public void SecretLoadScene()
    {
        SceneManager.LoadScene(secretSceneName);
        Debug.Log("Scene loaded");
    }
}