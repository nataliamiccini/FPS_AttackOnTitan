using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject rulesScreen;
    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene(3);
    }
    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit(); //shuts down the game
    }
    public void Rules()
    {
        Debug.Log("Rules");
        rulesScreen.SetActive(true);
    }
    public void BackToMainMenu() 
    {
        Debug.Log("Back");
        SceneManager.LoadScene(0);
    } 
}