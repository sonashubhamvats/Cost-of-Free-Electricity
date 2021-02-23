using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SimStartPrompt : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI simStartPrompt;

    private bool simStart;
    
    private bool collidePlayer;
    private void Awake()
    {
        simStartPrompt.gameObject.SetActive(false);
    }
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(collidePlayer)
        {
            simStartPrompt.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Down");
                //code
                if(simStart)
                {
                    AudioManager.instance.PlayBuzzerSound();
                    simStartPrompt.text="Press Q to Start Simulation";
                    simStart=false;
                    //resetting everything
                    SlurryRotors.instance.StartRotors=false;
                    GasTank.instance.gasMeter[0].fillAmount=0f;
                    GasTank.instance.gasMeter[1].fillAmount=0f;
                    GeneratorPrompt.instance.smoke1.gameObject.SetActive(false);
                    GeneratorPrompt.instance.smoke2.gameObject.SetActive(false);

                    GasTank.instance.startFillUp=false;
                    GeneratorPrompt.instance.genPrompt.text="Press Q to Start Generator";
                    GeneratorPrompt.instance.genOn=false;
                    PowerCutSim.instance.powerCutPrompt.text="Press Q to simulate power backup";
                    PowerCutSim.instance.powerCut=true;
                    PowerCutSim.instance.OnBattery=false;
                    AudioManager.instance.StopSim();
                    WireManagement.instance.GenWireOffAndNotGenOff();
                }
                else
                {
                    AudioManager.instance.PlayBuzzerSound();
                    simStartPrompt.text="Press Q to Stop Simulation";
                    simStart=true;
                    AudioManager.instance.StartSim();
                    SlurryRotors.instance.StartRotors=true;
                    

                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="Player")
        {
            collidePlayer=true;            
        }
        
    }    
    private void OnTriggerExit(Collider other)
    {
        if(other.name=="Player")
        {
            collidePlayer=false;
            simStartPrompt.gameObject.SetActive(false);
        }
            
    }
}
