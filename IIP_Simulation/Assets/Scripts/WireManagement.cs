using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireManagement : MonoBehaviour
{
    public static WireManagement instance;
    public Material genWire,genNotWire;

    public Color noPower,Power;

    public Light[] pointLights;
    private void Awake()
    {
        MakeInstance();
        for(int i=0;i<pointLights.Length;i++)
        {
            pointLights[i].enabled=false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GenWireOffAndNotGenOff();
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
    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenWireOnAndNotGenOn()
    {
        genWire.color=Power;
        genNotWire.color=Power;
        for(int i=0;i<pointLights.Length;i++)
        {
            pointLights[i].enabled=true;
        }

    }
    public void GenWireOffAndNotGenOff()
    {
        genWire.color=noPower;
        genNotWire.color=noPower;
        for(int i=0;i<pointLights.Length;i++)
        {
            pointLights[i].enabled=false;
        }


    }
    public void GenWireOffAndNotGenOn()
    {
        genWire.color=noPower;
        genNotWire.color=Power;
        for(int i=0;i<pointLights.Length;i++)
        {
            pointLights[i].enabled=true;
        }


    }

}
