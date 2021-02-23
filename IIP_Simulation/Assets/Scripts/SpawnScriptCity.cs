using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum type
{
    horiz,vert
}
public class SpawnScriptCity : MonoBehaviour
{
    public Transform spawnpoint;

    public type typee;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.CompareTo("Vehicle")==0)
        {
            if(typee==type.horiz)
            {
                Debug.Log("Horiz");
                
                other.transform.position=new Vector3(other.transform.position.x,other.transform.position.y,spawnpoint.position.z);
            }
            else
            {
                Debug.Log("Vert");
                other.transform.position=new Vector3(spawnpoint.position.x,other.transform.position.y,other.transform.position.z);
            }
        }
    }
}
