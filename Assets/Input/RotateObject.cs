using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float _rotateX = 0f, _rotateY = 15f, _rotateZ = 0f;

   //Used to rotate the weapon in the scene before it is picked up by the player
    void Update()
    {
        transform.Rotate(new Vector3(_rotateX,_rotateY,_rotateZ)* Time.deltaTime);
    }
}
