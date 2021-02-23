using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PowerCutSim : MonoBehaviour
{
    public TextMeshProUGUI powerCutPrompt;

    public static PowerCutSim instance; 

    public bool powerCut,OnBattery;
    private bool collidePlayer;
    private void Awake()
    {
        powerCutPrompt.gameObject.SetActive(false);
        powerCut=true;
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
        if(collidePlayer)
        {
            powerCutPrompt.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Q))
            {
                if((powerCut&&OnBattery)||(!powerCut&&!OnBattery))
                {
                    GeneratorPrompt.instance.smoke1.gameObject.SetActive(false);
                    GeneratorPrompt.instance.smoke2.gameObject.SetActive(false);
                    AudioManager.instance.PlayBuzzerSound();
                    AudioManager.instance.StopGeneratorAudio();
                    powerCutPrompt.text="Press Q to simulate power backup";
                    powerCut=true;
                    OnBattery=false;
                    WireManagement.instance.GenWireOffAndNotGenOff();
                    AudioManager.instance.ElectricityOffAudio();
                    GeneratorPrompt.instance.genPrompt.text="Press Q to Start Generator";
                    GeneratorPrompt.instance.genOn=false;

                }
                else 
                {
                    if(powerCut&&!OnBattery)
                    {
                        AudioManager.instance.PlayBuzzerSound();
                        AudioManager.instance.ElectricityOnWithBatteryAudio();
                        powerCutPrompt.text="Press Q to simulate power cut";
                        powerCut=true;
                        OnBattery=true;
                        WireManagement.instance.GenWireOffAndNotGenOn();
                    }
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(GeneratorPrompt.instance.AllowGenOn)
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
            powerCutPrompt.gameObject.SetActive(false);
        }
            
    }
}
