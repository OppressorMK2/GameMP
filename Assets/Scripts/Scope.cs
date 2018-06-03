using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson

{
    public class Scope : MonoBehaviour
    {

        public Animator animator;
        public Animator ScopeAnim;

        public GameObject player;
        public GameObject ScopeOverLay;
        public GameObject CrossHair;
        public Camera WeaponCamera;
        public Camera maincamera;

        public UnityEngine.PostProcessing.Menu Menu;

        public float scopedFOV = 15f;
        public float speed = 0.15f;
        public float normalFOV = 60f;
        public float AdsWalkSpeed = 1.5f;

        private float originalSpeed;

        void Update()
        {
            WeaponCamera.fieldOfView = maincamera.fieldOfView;
            if (player.GetComponent<FirstPersonController>().m_IsWalking)
            {
                CrossHair.gameObject.SetActive(false);
            }
            else
            {
                CrossHair.gameObject.SetActive(true);
            }
            if (animator.GetBool("Run") || animator.GetBool("Reloading") || Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("Scoped", false);
                WeaponCamera.gameObject.SetActive(true);
                CrossHair.gameObject.SetActive(true);
                ScopeAnim.SetBool("Scoped", false);
                maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, normalFOV, speed * Time.deltaTime);
                return;
            }
            if (animator.GetBool("Scoped"))
            {
                player.GetComponent<FirstPersonController>().m_WalkSpeed = AdsWalkSpeed;
                CrossHair.gameObject.SetActive(false);
                StartCoroutine(ScopeDelay());
            }
            else
            {
                player.GetComponent<FirstPersonController>().m_WalkSpeed = originalSpeed;
                maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, normalFOV, speed * Time.deltaTime);
                WeaponCamera.gameObject.SetActive(true);
                ScopeAnim.SetBool("Scoped", false);
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
        IEnumerator ScopeDelay()
        {
            yield return new WaitForSeconds(0.15f);
            maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, scopedFOV, speed * Time.deltaTime);
            WeaponCamera.gameObject.SetActive(false);
            ScopeAnim.SetBool("Scoped", true);
        }
        IEnumerator UnScopeDelay()
        {
            StopCoroutine(ScopeDelay());
            WeaponCamera.gameObject.SetActive(true);
            maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, normalFOV, speed * Time.deltaTime);
            ScopeAnim.SetBool("Scoped", false);
            CrossHair.gameObject.SetActive(true);
            yield return null;
        }
        void Start()
        {
            originalSpeed = player.GetComponent<FirstPersonController>().m_WalkSpeed;
            ScopeOverLay.gameObject.SetActive(true);
        }
    }
}
