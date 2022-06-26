using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Implementation of the scene containing the winner menu 
public class WinnerMenu : MonoBehaviour
{
    //Restart button: starting new game
    public void Restart () {
        Debug.Log("Restart");
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    //Back to main menu button: used to load the
    //initial scene containing the main menu 
    public void BackToMainMenu() {
        Debug.Log("Back to Main Menu");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    } 
}
