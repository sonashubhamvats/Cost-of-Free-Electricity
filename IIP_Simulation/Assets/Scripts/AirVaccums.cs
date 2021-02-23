using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirVaccums : MonoBehaviour
{
    public GameObject[] fans;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<fans.Length;i++)
        {
            fans[i].transform.Rotate(0f,0f,speed*Time.deltaTime);
        }
    }
}
