using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public Animator enemyAnimator;

    public float damage = 20f;
    public float health = 100f;
    public GameManager gameManager;
    public int EnemyDead;
   
        // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination =player.transform.position;
        if (GetComponent<NavMeshAgent>().velocity.magnitude>1){
            enemyAnimator.SetBool("isRunning", true);
        }
        else {
            enemyAnimator.SetBool("isRunning", false);
        }
        
    }
    
    //Hit method used to manage the enemy's life. 
    //If it is hit by the player then it is decreased. 
    //If it is less than zero the enemy is killed.
    public void Hit(float damageP) {
        health -= damageP;
        StartCoroutine("Reset");
        if (health <= 0)
        {
            damage = 0;
            StartCoroutine("Dead");
            gameManager.enemyAlive--;
        }
    }


    //If the collision between the enemy and the player occurs, 
    //then the player loses life recalling the Hit method of PlayerManager
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("Player hit!");
            player.GetComponent<PlayerManager>().Hit(damage);
        }
        
    }

    //IEnumerator used to handle boolean variables for animations
    IEnumerator Dead() {
        // your process
        enemyAnimator.SetBool("isDying", true);
        yield return new WaitForSeconds(4);
        // continue process
        enemyAnimator.SetBool("isDying", false);
        Destroy(gameObject);
    }
    
    IEnumerator Reset() {
        // your process
        enemyAnimator.SetBool("isShoot", false);
        yield return new WaitForSeconds(1);
        // continue process
        enemyAnimator.SetBool("isShoot", true);
    }
    

    
}
