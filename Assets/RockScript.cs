using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    private GameObject playerTag;
    private GameObject enemyTag;
    private GameObject house;
    public float damage = 5f;
    //private GameObject rock;
    void Start()
    {
        playerTag= GameObject.FindGameObjectWithTag("Player");
        enemyTag= GameObject.FindGameObjectWithTag("Enemy");
        house= GameObject.FindGameObjectWithTag("House");
        
    }
    

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != enemyTag)
        {
            if (other.gameObject == playerTag)
            {
                Debug.Log("Player hit by a rock!");
                playerTag.GetComponent<PlayerManager>().Hit(damage);
            }
            
          /* if (other.gameObject == house)
            {
                other.gameObject.GetComponent<Rigidbody>().collisionDetectionMode= CollisionDetectionMode.ContinuousDynamic;
                Debug.Log("House");
                Destroy(gameObject);
            }*/
            Destroy(gameObject);
        }
    }
}
