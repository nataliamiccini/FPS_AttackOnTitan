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
    public void Hit(float damageP) {
        health -= damageP;
        StartCoroutine("ShootCoroutine");
        if (health <= 0)
        {
            damage = 0;
            StartCoroutine("DeadCoroutine");
        }
    }

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
    private void OnCollisionEnter (Collision collision){
        if(collision.gameObject.CompareTag("Player")){
            Debug.Log("Player hit by Big Giant!");
            player.GetComponent<PlayerManager>().Hit(damage);
        }
    }
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
