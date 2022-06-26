using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float _rotateX = 0f, _rotateY = 15f, _rotateZ = 0f;



    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(_rotateX,_rotateY,_rotateZ)* Time.deltaTime);
    }
}
