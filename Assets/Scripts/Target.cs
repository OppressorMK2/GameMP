/*
* Copyright (c) Mohamad Mehdi Badran
* https://twitter.com/_Mehdi_Badran_
*/

using UnityEngine;

public class Target : MonoBehaviour
{
    #region Variables
    public bool destructible = true;
    public float health = 50f;
    public GameObject DestroyedV;
    public ParticleSystem PS;
	#endregion

	#region Unity Methods

	public void TakeDamage (float amount)
    {
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
        }else if (!destructible)
        {
            Instantiate(PS, transform.localPosition, transform.localRotation);
            Destroy(gameObject);
        }
    }

	#endregion
}
