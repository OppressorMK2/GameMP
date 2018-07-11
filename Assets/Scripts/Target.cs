/*
* Copyright (c) Mohamad Mehdi Badran
* https://twitter.com/_Mehdi_Badran_
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Target : NetworkBehaviour
{
    #region Variables
    public bool destructible = true;
    [SyncVar]
    public float health = 50f;

    public Text txtHP;
    public GameObject DestroyedV;
    public ParticleSystem PS;
    #endregion

    #region Unity Methods

    private void Update()
    {
        if (transform.tag == "Player")
        {
            txtHP.text = health.ToString() + "HP";
        }
        
    }

    public void TakeDamage (float amount)
    {
        if (!isServer)
        {
            return;
        }
        health -= amount; 
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die ()
    {
        if (destructible)
        {
            Instantiate(DestroyedV, transform.localPosition, transform.localRotation);
            Destroy(gameObject);
        }
        else if (transform.tag == "Player")
        {
            //death Animation
            // Kills ++
        }
        else
        {
            Instantiate(PS, transform.localPosition, transform.localRotation);
            Destroy(gameObject);
        }
    }

	#endregion
}
