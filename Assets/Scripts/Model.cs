using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class Model : NetworkBehaviour {

    public Animator animator;//stores the animator component
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;
    public float v; //vertical movements
    public float h; //horizontal movements
    public float sprint;
     
    void Update()
    {
        CheckForInput();
        Sprinting();
    }

    void CheckForInput()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        //set the "Walk" parameter to the v axis value
        animator.SetFloat("Walk", v);
        animator.SetFloat("Turn", h);
        animator.SetFloat("Sprint", sprint);
    }

    void Sprinting()
    {
        if (fps.m_IsWalking)
        {
            sprint = 0.2f;
        }
        else
        {
            sprint = 0.0f;
        }

    }
}
