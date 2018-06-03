using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMouvement : MonoBehaviour{

    public float MoveAmount = 1f;
    public float MoveSpeed = 2f;
    public float MaxMovement;
    private float MoveOnX;
    private float MoveOnY;
    public Vector3 DefaultPos;
    private Vector3 NewGunPos;
    private Quaternion DefaultRot;
    public bool OnOff = false;

    public GameObject Gun;
    public Animator animator;
    public Animator animatorH;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController FPScontroller;

    public float jumpSpeed = 1f;
    public float jumpFallOf = 0.5f;
    public Vector3 jumpPos;
    public Quaternion jumpRot;

    void Start()
    {
        DefaultRot = transform.localRotation;
        DefaultPos = transform.localPosition;
        OnOff = true;
    }

    void Update()
    {

        if (animator.GetBool("Scoped"))
        {
            MoveAmount = 0.1f;
            MoveSpeed = 4f;
            MaxMovement = 0.01f;
        }
        else
        {
            MoveAmount = 3f;
            MoveSpeed = 2f;
            MaxMovement = 0.2f;
        }
 
        if (OnOff == true)
        {
            MoveOnX = Input.GetAxis("Mouse X") * Time.deltaTime * MoveSpeed;
            MoveOnY = Input.GetAxis("Mouse Y") * Time.deltaTime * MoveSpeed;
        
            MoveOnX = Mathf.Clamp(MoveOnX, -MaxMovement, MaxMovement);
            MoveOnY = Mathf.Clamp(MoveOnY, -MaxMovement, MaxMovement);

            NewGunPos = new Vector3(DefaultPos.x + MoveOnX, DefaultPos.y + MoveOnY, DefaultPos.z);
            Gun.transform.localPosition = Vector3.Lerp(Gun.transform.localPosition, NewGunPos, MoveSpeed * Time.deltaTime);
            if (Input.GetButtonDown("Jump") && FPScontroller.m_CharacterController.isGrounded)
            {
                Jump();
            }
            else
            {
                jumpFallof();
            }
        }
        else
        {
            OnOff = false;
        }

    }
    public void jumpFallof()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, DefaultPos, jumpFallOf * Time.deltaTime);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, DefaultRot, jumpFallOf * Time.deltaTime);
    }
    public void Jump()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, jumpPos, jumpSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, jumpRot, jumpSpeed * Time.deltaTime);
    }
}