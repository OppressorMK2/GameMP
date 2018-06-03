/*
* Copyright (c) Mohamad Mehdi Badran
* https://twitter.com/_Mehdi_Badran_
*/

using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    #region Variables
    public Text ammoCounter;
    public GameObject M4;
    public GameObject L96;
    public GameObject G18;
    #endregion

    #region Unity Methods

    void Update () 
	{
        if (M4.activeSelf)
        {
            ActiveGunM4();
        }

        if (L96.activeSelf)
        {
            ActiveGunL96();
        }

        if (G18.activeSelf)
        {
            ActiveGunG18();
        }
    }

    void ActiveGunM4()
    {
        ammoCounter.text = "Ammo      " + M4.GetComponentInChildren<GunM4>().currentAmmo.ToString() + " / " + M4.GetComponentInChildren<GunM4>().reserveAmmo.ToString();
    }

    void ActiveGunL96()
    {
        ammoCounter.text = "Ammo      " + L96.GetComponentInChildren<GunL96>().currentAmmo.ToString() + " / " + L96.GetComponentInChildren<GunL96>().reserveAmmo.ToString();
    }

    void ActiveGunG18()
    {
        ammoCounter.text = "Ammo      " + G18.GetComponentInChildren<GunG18>().currentAmmo.ToString() + " / " + G18.GetComponentInChildren<GunG18>().reserveAmmo.ToString();
    }

	#endregion
}
