using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class item2 : MonoBehaviour
{
    virtual protected void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);

    }
}