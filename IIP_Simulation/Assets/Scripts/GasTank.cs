using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GasTank : MonoBehaviour
{
    public Image[] gasMeter;
    public static GasTank instance; 

    [HideInInspector]
    public bool startFillUp;
    private void Awake()
    {
        gasMeter[0].fillAmount=0f;
        gasMeter[1].fillAmount=0f;
        MakeInstance();
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(startFillUp)
        {
            gasMeter[0].fillAmount+=(Time.deltaTime/15f);
            gasMeter[1].fillAmount+=(Time.deltaTime/15f);
            if(gasMeter[0].fillAmount>=1f)
            {
                GeneratorPrompt.instance.AllowGenOn=true;
            }            
        
        }
        if(gasMeter[0].fillAmount<1f)
        {
            GeneratorPrompt.instance.AllowGenOn=false;
        }            

    }
}
