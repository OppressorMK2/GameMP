using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class Model : NetworkBehaviour {

    public Animator animator;//stores the animator component
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;
    public float v; //vertical movements
    public float h; //horizontal movements
    public float sprint;
    public bool grounded = true;
    public UnityEngine.PostProcessing.Menu menu;

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
        grounded = GetComponent<CapsuleCollider>().isTrigger;
        if (fps.readyJump && Input.GetKey(KeyCode.Space) && !menu.Paused)
        {
            animator.SetBool("Jump", true);
        }else
        {
            animator.SetBool("Jump", false);
        }
        animator.SetBool("Crouch", GetComponentInChildren<Crouch>().crouched);
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
