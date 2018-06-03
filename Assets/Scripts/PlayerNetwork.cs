using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
    public GameObject firstPersonCharacter;
    public GameObject canvas;
    public GameObject[] characterModel;

    public override void OnStartLocalPlayer()
    {
        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        firstPersonCharacter.SetActive(true);
        canvas.SetActive(true);
        
        foreach(GameObject GO in characterModel)
        {
            GO.SetActive(false);
        }
    }

}
