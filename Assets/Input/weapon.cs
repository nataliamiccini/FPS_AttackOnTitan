using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : item
{
    public GameObject playerCam;
    public float range = 100f;
    public float damage = 25f;
    public GameObject enemy;
    public int bigenemyAlive;
    public GameObject enemyPrefab;
    public GameObject spawnPoint;
    public enum WeapunType
    {
        boltGun
    }
    

    
    [SerializeField] private WeapunType _weapunType;

    private void Start()
    {
        enemy= GameObject.FindGameObjectWithTag("Enemy");
    }

    //When the player collides with the weapon, it is set to true
    protected override void OnTriggerEnter(Collider other)
    {
        //base liked base class
        base.OnTriggerEnter(other);
        if (other.tag == "Player")
            other.gameObject.GetComponent<playerCombat>().SetWeapon(_weapunType);
       
    }

}
