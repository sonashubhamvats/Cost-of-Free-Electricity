using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlurryRotors : MonoBehaviour
{
    public GameObject rotor1,rotor2,rotor3,wheel;

    public bool StartRotors;

    public float speed;

    public static SlurryRotors instance;
    private void Awake()
    {
        MakeInstance();
    }
    void MakeInstance()
    {
        if(instance==null)
        {
            instance=this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StartRotors)
        {
            GasTank.instance.startFillUp=true;
            rotor1.transform.Rotate(0f,0f,speed*Time.deltaTime);
            rotor2.transform.Rotate(0f,0f,speed*Time.deltaTime);
            rotor3.transform.Rotate(0f,0f,speed*Time.deltaTime);
            wheel.transform.Rotate(0f,0f,speed*Time.deltaTime);
        }
    }
}
