using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy: MonoBehaviour
{
    public bool isFiring;
    public float damage = 5f;
    public Animator enemyAnimator;
    public GameObject player;
    private GameObject playerTag;
    public float range = 20f;
    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        isFiring = true;
        playerTag= GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(playerTag.transform.position, enemyAnimator.transform.position)< 40)
        {
            if (isFiring == true)
            {
                StartCoroutine("Throw");
            }
        }
    }
    /*private void OnCollisionEnter(Collision other)
    {
       if (other.gameObject == playerTag)
        {
            Debug.Log("Colpito");
            playerTag.GetComponent<PlayerManager>().Hit(damage);
        }
        //Destroy(gameObject);
    }*/
    
    /*IEnumerator Throw()
    {
        isFiring = false;
        enemyAnimator.SetBool("isThrowing", true);
        yield return new WaitForSeconds(3);
        enemyAnimator.SetBool("isThrowing", false);
        isFiring = true;
    }*/
    
    IEnumerator Throw()
    {
        isFiring = false;
        enemyAnimator.SetBool("isThrowing", true);
        yield return new WaitForSeconds(3);
        enemyAnimator.SetBool("isThrowing", false);
        isFiring = true;
    }
}
    

