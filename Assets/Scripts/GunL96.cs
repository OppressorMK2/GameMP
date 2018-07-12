/*
* Copyright (c) Mohamad Mehdi Badran
* https://twitter.com/_Mehdi_Badran_
*/

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GunL96 : NetworkBehaviour
{
    #region Variables
    [Header("Stats")]
    public float damage = 10f;
    public float range = 100f;
    public float firerate = 15f;
    public float impactforce = 60f;
    private float nexttimetofire = 0f;

    [Header("Ammo")]
    public int maxAmmoMag = 30;
    public int currentAmmo;
    public int reserveAmmo = 200;
    private int AmmoNeeded;
    public int totalAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    [Header("GameObjects")]
    public GameObject fpsCam;
    public ParticleSystem muzzleflash;
    public GameObject impacteffect;
    public Animator animator;
    public GameObject cartrage;
    public UnityEngine.PostProcessing.Menu Menu;
    public GameObject hitmarker;
    public GameObject canvas;

    [Header("Audio")]
    public AudioClip gunSound;
    public float Volume;
    public AudioSource AudioSourceMaster;
    public AudioSource AudioSourceEffects;
    public AudioClip hitMarkerSound;

    [Header("Recoil")]
    public Recoil recoilComponent;
    public float amountOfRecoil = 0.01f;
    public float maxRecoilx = -5f;
    public float recoilSpeed = 15f;

    [Header("Camera Recoil")]
    public Recoil recoilComponentCam;
    public float amountOfRecoilCam = 0.01f;
    public float maxRecoilxCam = 4f;
    public float recoilSpeedCam = 7.5f;
    #endregion

    #region Unity Methods

    void Start()
    {
        currentAmmo = maxAmmoMag;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {

        totalAmmo = reserveAmmo + currentAmmo;

        if (animator.GetBool("Run"))
        {
            return;
        }

        if (totalAmmo <= 0)
        {
            return;
        }


        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0 && reserveAmmo > 0 || Input.GetKey("r") && maxAmmoMag > currentAmmo && reserveAmmo > 0 && !Menu.Paused)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetMouseButton(0) && Time.time >= nexttimetofire && !Menu.Paused)
        {
            nexttimetofire = Time.time + 1f / firerate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        AmmoNeeded = maxAmmoMag - currentAmmo;
        if (AmmoNeeded > reserveAmmo)
        {
            currentAmmo += reserveAmmo;
            reserveAmmo -= reserveAmmo;
        }
        else
        {
            reserveAmmo -= AmmoNeeded;
            currentAmmo += AmmoNeeded;
        }

        isReloading = false;

    }

    void Shoot()
    {

        currentAmmo--;

        muzzleflash.Play();
        cartrage.GetComponent<ParticleSystem>().Play();
        AudioSourceMaster.PlayOneShot(gunSound, Volume);

        recoilComponent.StartRecoil(amountOfRecoil, maxRecoilx, recoilSpeed);
        recoilComponentCam.StartRecoil(amountOfRecoilCam, maxRecoilxCam, recoilSpeedCam);
        GetComponent<Accuracy>().Recoil();

        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactforce);
            }

            if (hit.collider.transform.name == "PlayerMP(Clone)")
            {
                Hit();
            }

            GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
    void Hit()
    {
        print("hit");
        AudioSourceEffects.PlayOneShot(hitMarkerSound, 1f);
        Instantiate(hitmarker, canvas.transform);
    }

    #endregion
}
