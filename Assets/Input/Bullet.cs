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

    IEnumerator BulletCleanUp()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
