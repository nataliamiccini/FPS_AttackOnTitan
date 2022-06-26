using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float health = 100;
    public Text healthText;
    public GameManager gameManager;
    
    //Hit method used to manage player's life.
    //If it drops below zero, the game has been lost 
    //and the End Game screen is loaded by the gamemanager
    public void Hit(float damage) {
        health -= damage;
        healthText.text = "HEALTH: " + health.ToString();
        if (health <= 0)
        {
            gameManager.EndGame();
        }
    }

}
