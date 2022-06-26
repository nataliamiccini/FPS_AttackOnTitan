using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public int bigenemyAlive=0;
    public GameObject enemyPrefab;
    public GameObject spawnPoint;
    public GameObject weapon;
    
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Weapon");
    }

    //When the collision between weapon and cube, placed inside the gate, 
    //occurs, the final giant is instantiated, if it has not already been done
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            if (bigenemyAlive < 1)
            {
                Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                bigenemyAlive++;
                Destroy(gameObject);
            }
        }
        
    }
}
