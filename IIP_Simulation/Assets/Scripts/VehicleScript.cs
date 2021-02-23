using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum direction
{
    horizontal,vertical
}
public class VehicleScript : MonoBehaviour
{
    public direction dir;
    public float speed;
    private Vector3 increment;

    public float inverse;
    // Start is called before the first frame update
    void Start()
    {
        if(dir==direction.horizontal)
        {
            increment=new Vector3(speed*inverse,0f,0f);
        }    
        else
        {
            increment=new Vector3(0f,0f,speed*inverse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=increment*Time.deltaTime;
    }
}
