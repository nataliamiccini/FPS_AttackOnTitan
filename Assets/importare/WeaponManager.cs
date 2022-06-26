using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float range = 100f;
    public float damage = 25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            //Debug.Log("Shoot!");
            Shoot();
        }
        
    }

    void Shoot() {
        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            //Debug.Log("hit");
            EnemyManager enemyManager =  hit.transform.GetComponent<EnemyManager>();
            if(enemyManager != null) { //then we hit an enemy
                Debug.Log("Enemy hit!");
                enemyManager.Hit(damage);
            }
        } 
    }
}
