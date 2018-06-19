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
        if (GetComponentInChildren<Crouch>().crouched)
        {
            //animator.SetBool("",);
        }
    }

    void FixedUpdate()
    {
        //set the "Walk" parameter to the v axis value
        animator.SetFloat("Walk", v, 0.1f, Time.deltaTime);
        animator.SetFloat("Turn", h, 0.1f, Time.deltaTime);
        animator.SetFloat("Sprint", sprint, 0.2f, Time.deltaTime);
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
