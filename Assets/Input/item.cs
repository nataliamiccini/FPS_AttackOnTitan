using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  item : MonoBehaviour
{
    virtual protected void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        
   
    }
}
