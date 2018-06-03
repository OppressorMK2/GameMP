using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {

    public UnityEngine.PostProcessing.Menu Menu;
    public Animator animator;

    void Update()
    {
        if (!Menu.Paused)
        {
            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }
            if (Input.GetKey("left shift") && Input.GetKey("w"))
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
            }
            if (animator.GetBool("Reloading"))
            {
                animator.SetBool("Run", false);
            }
        }else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
        }
    }
}
