using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager2 : MonoBehaviour
{

    public GameObject player;
    public Animator enemyAnimator;
    public GameManager gameManager;
    public float damage = 28f;
    public float health = 500f;
    public int EnemyDead = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

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
    
    //Hit method used to manage the big enemy's life. 
    //If it is hit by the player then it is decreased. 
    //If it is less than zero the enemy has been killed
    public void Hit(float damageP) {
        health -= damageP;
        StartCoroutine("ShootCoroutine");
        if (health <= 0)
        {
            damage = 0;
            StartCoroutine("DeadCoroutine");
        }
    }
    
    //If the collision between the enemy and the player occurs, 
    //then the player loses life recalling the Hit method of PlayerManager is recalled
    private void OnCollisionEnter (Collision collision){
        if(collision.gameObject.CompareTag("Player")){
            Debug.Log("Player hit by Big Giant!");
            player.GetComponent<PlayerManager>().Hit(damage);
        }
    }
    
    //IEnumerator used to handle boolean variables for animations
    IEnumerator DeadCoroutine()
    {
        enemyAnimator.SetBool("isDying", true);
        yield return new WaitForSeconds(4);
        enemyAnimator.SetBool("isDying", false);
        gameManager.WinGame();
        Debug.Log("Winner");
        Destroy(gameObject);
    }
    
    IEnumerator ShootCoroutine()
    {
        enemyAnimator.SetBool("isShoot", true);
        yield return new WaitForSeconds(1);
        enemyAnimator.SetBool("isShoot", false);
    }

}
