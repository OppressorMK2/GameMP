using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

	void Update ()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Desert village")
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
	}
    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
