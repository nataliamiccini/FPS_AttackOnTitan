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
  /*  protected override void OnTriggerEnter(Collider other)
    {
        //base liked base class
        base.OnTriggerEnter(other);
        
         if(other.tag == "Trigger")
            {
                if(bigenemyAlive < 1) {
                    Debug.Log("Trigger hit!");
                    Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                    bigenemyAlive++;
                }
            }
            
        }*/

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
