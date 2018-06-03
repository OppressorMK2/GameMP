using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {

	public int selectedweapon = 0;
    public GameObject scopeoverlay;
    public GameObject Crosshair;
    public GameObject WeaponCamera;
    public Camera maincamera; 
    public float normalFOV = 65f;
    public float lerpSpeed = 12f;

    private bool ready = true;

    // Use this for initialization
    void Start ()
	{
        SelectWeapon();
	}
	
	// Update is called once per frame
	void Update ()
	{
		int previousSelectedWeapon = selectedweapon;

        if (Input.GetKeyDown(KeyCode.Space) && ready)
        {
            StartCoroutine(jump());
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedweapon = 0;
            if (scopeoverlay.GetComponent<Animator>().isInitialized)
            {
                scopeoverlay.GetComponent<Animator>().SetBool("Scoped", false);
            }
            maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, normalFOV, lerpSpeed * Time.deltaTime);
            Crosshair.gameObject.SetActive(true);
            WeaponCamera.gameObject.SetActive(true);
        }

		if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
		{
			selectedweapon = 1;
            if (scopeoverlay.GetComponent<Animator>().isInitialized)
            {
                scopeoverlay.GetComponent<Animator>().SetBool("Scoped", false);
            }
            maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, normalFOV, lerpSpeed * Time.deltaTime);
            Crosshair.gameObject.SetActive(true);
            WeaponCamera.gameObject.SetActive(true);
        }

		if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
		{
			selectedweapon = 2;
            if (scopeoverlay.GetComponent<Animator>().isInitialized)
            {
                scopeoverlay.GetComponent<Animator>().SetBool("Scoped", false);
            }
            maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, normalFOV, lerpSpeed * Time.deltaTime);
            Crosshair.gameObject.SetActive(true);
            WeaponCamera.gameObject.SetActive(true);
        }

		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			if (selectedweapon >= transform.childCount - 1)
				selectedweapon = 0;
			else
				selectedweapon++;

            if (scopeoverlay.GetComponent<Animator>().isInitialized)
            {
                scopeoverlay.GetComponent<Animator>().SetBool("Scoped", false);
            }
            maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, normalFOV, lerpSpeed * Time.deltaTime);
            Crosshair.gameObject.SetActive(true);
            WeaponCamera.gameObject.SetActive(true);
        }

		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
            if (selectedweapon <= 0)
            {
                selectedweapon = transform.childCount - 1;
            }
            else
                selectedweapon--;

            if (scopeoverlay.GetComponent<Animator>().isInitialized)
            {
                scopeoverlay.GetComponent<Animator>().SetBool("Scoped", false);
            }
            maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, normalFOV, lerpSpeed * Time.deltaTime);
            Crosshair.gameObject.SetActive(true);
            WeaponCamera.gameObject.SetActive(true);
        }

		if (previousSelectedWeapon != selectedweapon)
		{
				SelectWeapon();
		}
	}

    IEnumerator jump()
    {
        ready = !ready;
        //GetComponent<Animator>().applyRootMotion = false;
        GetComponent<Animator>().SetBool("Jump", true);
        yield return new WaitForSeconds(0.75f);
        GetComponent<Animator>().SetBool("Jump", false);
        //GetComponent<Animator>().applyRootMotion = true;
        ready = !ready;
    }

    void SelectWeapon()
	{
		int i = 0;
		foreach (Transform weapon in transform)
		{
			if (i == selectedweapon)
				weapon.gameObject.SetActive(true);
			else
				weapon.gameObject.SetActive(false);
			i++;
		}
	}

}
