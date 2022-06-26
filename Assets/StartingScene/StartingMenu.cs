using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingMenu : MonoBehaviour
{
    public void Skip()
    {
        Debug.Log("Skip");
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Play()
    {
        Debug.Log("Let's play!");
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}