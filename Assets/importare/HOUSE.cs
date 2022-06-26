using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOUSE : MonoBehaviour
{
    private GameObject house;
    //private GameObject rock;
    void Start()
    {
        house= GameObject.FindGameObjectWithTag("House");
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("House"))
            {
                other.gameObject.GetComponent<Rigidbody>().collisionDetectionMode= CollisionDetectionMode.ContinuousDynamic;
                Debug.Log("House");
                Destroy(gameObject);
            } 

        }
    }

