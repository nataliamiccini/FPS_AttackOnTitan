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
    

    public void Hit(float damageP) {
        health -= damageP;
        StartCoroutine("Reset");
        if (health <= 0)
        {
            /*EnemyDead++;
            if (EnemyDead != 0)
            {
                Debug.Log("Open Doors");
                doorAnimatorL.SetBool("isOpenL", true);
                doorAnimatorR.SetBool("isOpenR", true);
            }*/
            damage = 0;
            StartCoroutine("Dead");
            gameManager.enemyAlive--;
        }
    }
    
    
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("Player hit!");
            player.GetComponent<PlayerManager>().Hit(damage);
        }
        
    }


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
