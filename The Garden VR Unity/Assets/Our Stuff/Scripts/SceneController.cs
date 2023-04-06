using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public Button button; // Reference to the button you want to trigger

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            button.onClick.Invoke();
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // load the new scene
    }

  


}