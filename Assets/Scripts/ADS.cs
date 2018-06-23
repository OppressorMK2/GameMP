using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson

{
    public class ADS : MonoBehaviour
    {

        public Animator animator;
        public Animator animatorH;

        public GameObject player;
        public GameObject CrossHair;
        public Camera WeaponCamera;
        public Camera maincamera;
        public UnityEngine.PostProcessing.Menu Menu;

        public float scopedFOV = 15f;
        public float speed = 0.15f;
        public float normalFOV = 60f;
        public float AdsWalkSpeed = 3f;
        public float crouchSpeed = 2.75f;
        private float originalSpeed;

        void Update()
        {
            WeaponCamera.fieldOfView = maincamera.fieldOfView;
            if (animator.GetBool("Reloading"))
            {
                maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, normalFOV, speed * Time.deltaTime);
            }
            if (animator.GetBool("Run"))
            {
                animator.SetBool("Scoped", false);
                animator.SetBool("Strafing", false);
                maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, normalFOV, speed * Time.deltaTime);
                return;
            }
            if (animator.GetBool("Scoped") && animator.GetBool("Walk"))
            {
                animator.SetBool("Strafing", true);
            }else
            {
                animator.SetBool("Strafing", false);
            }
            if (animator.GetBool("Scoped"))
            {
                player.GetComponent<FirstPersonController>().m_WalkSpeed = AdsWalkSpeed;
                maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, scopedFOV, speed * Time.deltaTime);
                CrossHair.gameObject.SetActive(false);
            }else if (animatorH.GetBool("Crouch") && animator.GetBool("Scoped"))
            {
                player.GetComponent<FirstPersonController>().m_WalkSpeed = crouchSpeed;
            }
            else if (animatorH.GetBool("Crouch") && !animator.GetBool("Scoped"))
            {
                player.GetComponent<FirstPersonController>().m_WalkSpeed = crouchSpeed;
                maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, normalFOV, speed * Time.deltaTime);
                CrossHair.gameObject.SetActive(true);
            }
            else
            {
                player.GetComponent<FirstPersonController>().m_WalkSpeed = originalSpeed;
                maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, normalFOV, speed * Time.deltaTime);
                CrossHair.gameObject.SetActive(true);
            }
            if (!Menu.Paused)
            {
                if (Input.GetMouseButton(1))
                {
                    animator.SetBool("Scoped", true);
                }
                else if (Input.GetMouseButtonUp(1))
                {
                    animator.SetBool("Scoped", false);
                }
            }
            else
            {
                animator.SetBool("Scoped", false);
                CrossHair.SetActive(false);
            }
        }
        void Start()
        {
            originalSpeed = player.GetComponent<FirstPersonController>().m_WalkSpeed;
        }

    }
}
