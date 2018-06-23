using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class Crouch : MonoBehaviour {

    public float crouchSpeed = 10f;
    public bool crouched = false;
    public Vector3 crouchPos;
    public Vector3 DefaultPosition;
    public FirstPersonController fps;

    void Update ()
    {
		if (Input.GetKey("c") && !fps.m_IsWalking)
        {
            crouch();
        }else
        {
            UnCrouch();
        }
	}
    void crouch ()
    {
        crouched = true;
        fps.m_WalkSpeed = 2.5f;
        transform.localPosition = Vector3.Lerp(transform.localPosition, crouchPos, crouchSpeed * Time.deltaTime);
    }
    void UnCrouch()
    {
        crouched = false;
        fps.m_WalkSpeed = 4f;
        transform.localPosition = Vector3.Lerp(transform.localPosition, DefaultPosition, crouchSpeed * Time.deltaTime);
    }
}
