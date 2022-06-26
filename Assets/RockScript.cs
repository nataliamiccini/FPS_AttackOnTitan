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
    
    void Start()
    {
        playerTag= GameObject.FindGameObjectWithTag("Player");
        enemyTag= GameObject.FindGameObjectWithTag("Enemy");
        house= GameObject.FindGameObjectWithTag("House");
        
    }
    
    //Method used to handle if the rock hits the player
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != enemyTag)
        {
            if (other.gameObject == playerTag)
            {
                Debug.Log("Player hit by a rock!");
                playerTag.GetComponent<PlayerManager>().Hit(damage);
            }
            Destroy(gameObject);
        }
    }
}
