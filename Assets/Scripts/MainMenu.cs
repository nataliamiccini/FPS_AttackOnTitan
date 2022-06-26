using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Implementation of the initial scene containing the main menu
public class MainMenu : MonoBehaviour
{
    public GameObject rulesScreen;
    
    //StartGame button: load the starting scene
    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene(3);
    }
    
    // ExitGame button: used to shut down the game
    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit(); //shuts down the game
    }
    
    //Rules button: use to load screen rules
    public void Rules()
    {
        Debug.Log("Rules");
        rulesScreen.SetActive(true);
    }
    
    //Back button: used to to go back to the main
    //menu from screen rules
    public void BackToMainMenu() 
    {
        Debug.Log("Back");
        SceneManager.LoadScene(0);
    } 
}
