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
    
    void Update() {
        if(enemyAlive == 0){
            round++;
            NextWave(round);
            roundNumber.text ="ROUND: " + round.ToString();
            /*if (round == 2)
            { Debug.Log( ("Open Doors"));
              doorL.transform.Rotate(0f,-90f, 0f, Space.World); 
              doorL.transform.Rotate(0f,-90f, 0f, Space.World);  
            }*/
        }
    }

   public void NextWave (int round) {
         for(var x = 0; x < round; x++){
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            //Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            enemyAlive++;
        }
    }   
   public void WinGame() {
       Time.timeScale = 0;
       Cursor.lockState = CursorLockMode.None;
       SceneManager.LoadScene(2);
   }
   
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
    public void EndGame() {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        endScreen.SetActive(true);
    }
}