using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject rock;
    private GameObject go;
    [SerializeField] private Transform HandPosition;
    public GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void CreateRock()
    {
        
        go = Instantiate(rock, HandPosition.position,Quaternion.identity);
        go.transform.position = HandPosition.position;
        go.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position)*70f);

    }

    
}
