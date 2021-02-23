using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToVillage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.CompareTo("Player")==0)
        {
            KeyManager.instance.StartVillage();
        }
    }

}
