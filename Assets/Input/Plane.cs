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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            if (bigenemyAlive < 1)
            {
                //Debug.Log("Trigger hit!");
                Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                bigenemyAlive++;
                Destroy(gameObject);
            }
        }
        
    }
}
