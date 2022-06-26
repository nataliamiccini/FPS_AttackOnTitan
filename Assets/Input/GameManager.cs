using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public int enemyAlive = 0;
    public int round = 0;
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    public GameObject endScreen;
    public Text roundNumber;
    public GameObject doorL;
    public GameObject doorR;
    
    //The round is increased each time an enemy is killed.
    //Then the NextWave function is recalled.
    void Update() {
        if(enemyAlive == 0){
            round++;
            NextWave(round);
            roundNumber.text ="ROUND: " + round.ToString();
        }
    }

    //NextWave method used to generate giant. Each time there is one killed, 
    //as many are generated equal to the number of the round.
    //Enemies are instantiated at randomly chosen spawnPoints.
   public void NextWave (int round) {
         for(var x = 0; x < round; x++){
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            //Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            enemyAlive++;
        }
    } 
    
   //Methods used to upload the victory scene
   public void WinGame() {
       Time.timeScale = 0;
       Cursor.lockState = CursorLockMode.None;
       SceneManager.LoadScene(2);
   }
   
   //Methods used to implement the buttons of the various screens
   
   //Restart button: start a new game
    public void Restart () {
        Debug.Log("Restart");
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    
    //Back to main menu button: reload the start menu scene
    public void BackToMainMenu() {
        Debug.Log("Back to Main Menu");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
     //Methods used upload the loser scene 
    public void EndGame() {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        endScreen.SetActive(true);
    }
}
