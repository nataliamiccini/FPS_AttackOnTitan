using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerMenu : MonoBehaviour
{
    public void Restart () {
        Debug.Log("Restart");
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu() {
        Debug.Log("Back to Main Menu");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    } 
}