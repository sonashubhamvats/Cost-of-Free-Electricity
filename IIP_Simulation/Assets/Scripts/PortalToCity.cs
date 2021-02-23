using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToCity : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.CompareTo("Player")==0)
        {
            KeyManager.instance.StartCity();
        }
    }
}
