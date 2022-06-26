using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int bigenemyAlive;
    public GameObject enemyPrefab;
    public GameObject spawnPoint;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //When the collision with the cube (placed inside the gate) 
    //occurs, the final giant is instantiated, if it has not already been done.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (bigenemyAlive < 1)
            {
                Debug.Log("Trigger hit!");
                Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                bigenemyAlive++;
                Destroy(this.gameObject); 
            }
        }
        
    }
}
