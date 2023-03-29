using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public float timeInSeconds = 5f; // the amount of time to stay in the new scene

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // load the new scene
        StartCoroutine(WaitAndLoad(timeInSeconds)); // start the coroutine to wait and load the original scene
    }

    IEnumerator WaitAndLoad(float time)
    {
        yield return new WaitForSeconds(time); // wait for the specified time
        SceneManager.LoadScene(0); // load the original scene
    }
}