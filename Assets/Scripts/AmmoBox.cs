using UnityEngine;

public class AmmoBox : MonoBehaviour {

    public GameObject player;
    public GameObject m4;
    public GameObject l96;
    public GameObject g18;
    public int Mags = 2;

    void OnCollisionEnter(Collision CollInfo)
    {  
        if (CollInfo.gameObject.tag == "AmmoBox")
        {
            giveMag();
            Destroy(CollInfo.gameObject);
        }
        
    }

    void giveMag()
    {
        m4.GetComponent<GunM4>().reserveAmmo += (Mags * m4.GetComponent<GunM4>().maxAmmoMag);
        l96.GetComponent<GunL96>().reserveAmmo += (Mags * l96.GetComponent<GunL96>().maxAmmoMag);
        g18.GetComponent<GunG18>().reserveAmmo += (Mags * g18.GetComponent<GunG18>().maxAmmoMag);
    }

}
