using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class Crouch : MonoBehaviour {

    public float crouchSpeed = 10f;
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
        transform.localPosition = Vector3.Lerp(transform.localPosition, crouchPos, crouchSpeed * Time.deltaTime);
    }
    void UnCrouch()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, DefaultPosition, crouchSpeed * Time.deltaTime);
    }
}
