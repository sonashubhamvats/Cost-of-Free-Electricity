using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GeneratorPrompt : MonoBehaviour
{
    public TextMeshProUGUI genPrompt;

    public bool genOn;

    
    public ParticleSystem smoke1,smoke2;
    public static GeneratorPrompt instance; 
    public bool AllowGenOn;

    private bool collidePlayer;
    // Start is called before the first frame update
    private void Awake()
    {
        genPrompt.gameObject.SetActive(false);
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(collidePlayer)
        {
                genPrompt.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Q))
                {
                    //code
                    if(genOn)
                    {
                        smoke1.gameObject.SetActive(false);
                        smoke2.gameObject.SetActive(false);
                        
                        genPrompt.text="Press Q to Start Generator";
                        AudioManager.instance.PlayBuzzerSound();
                        genOn=false;
                        PowerCutSim.instance.powerCutPrompt.text="Press Q to simulate power backup";
                        PowerCutSim.instance.powerCut=true;
                        PowerCutSim.instance.OnBattery=false;
                        AudioManager.instance.StopGeneratorAudio();
                        AudioManager.instance.ElectricityOffAudio();
                        WireManagement.instance.GenWireOffAndNotGenOff();
                    }
                    else
                    {
                        smoke1.gameObject.SetActive(true);
                        smoke2.gameObject.SetActive(true);
                        genPrompt.text="Press Q to Stop Generator";
                        genOn=true;
                        AudioManager.instance.PlayBuzzerSound();
                        PowerCutSim.instance.powerCutPrompt.text="Press Q to simulate power cut";
                        PowerCutSim.instance.powerCut=false;
                        PowerCutSim.instance.OnBattery=false;
                        AudioManager.instance.StartGeneratorAudio();
                        AudioManager.instance.ElectricityOnWithBatteryAudio();
                        WireManagement.instance.GenWireOnAndNotGenOn();
                        

                    }
                }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(AllowGenOn)
        {
            if(other.name=="Player")
            {
                collidePlayer=true;
            }
        }
    }    
    private void OnTriggerExit(Collider other)
    {
        if(other.name=="Player")
        {
            collidePlayer=false;
            genPrompt.gameObject.SetActive(false);
        }
            
    }
}
