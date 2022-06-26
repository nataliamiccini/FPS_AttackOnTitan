using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    private CharacterController m_CharacterController;
    private bool m_Crouch = false;
    private float m_originalHeight;
    [SerializeField] private float m_CrouchHeight = 0.8f;
    public KeyCode crouchKey = KeyCode.C;
    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_originalHeight = m_CharacterController.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(crouchKey))
        {
            //print(("Crouch"));
            m_Crouch = !m_Crouch;
            checkCrouch();
        }
    }

    void checkCrouch()
    {
        if (m_Crouch == true)
        {
            m_CharacterController.height = m_CrouchHeight;
        }
        else
        {
            m_CharacterController.height = m_originalHeight;
        }
    }
}
