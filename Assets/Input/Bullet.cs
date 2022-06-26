using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(BulletCleanUp());

    }

    //Ienumerator method used to destroy the projectile after 3 seconds
    IEnumerator BulletCleanUp()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
