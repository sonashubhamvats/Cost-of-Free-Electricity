using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource rotors,buzzer,gasPump,genrator,batteries,wheel,steam;
    public AudioSource[] transformers;
    // Start is called before the first frame update
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartSim()
    {
        rotors.Play();
        gasPump.Play();
        wheel.Play();
        steam.Play();
    }
    public void StopSim()
    {
        rotors.Stop();
        gasPump.Stop();
        wheel.Stop();
        steam.Stop();
        genrator.Stop();
    }
    public void StartGeneratorAudio()
    {
        genrator.Play();
    }

    public void StopGeneratorAudio()
    {
        genrator.Stop();
    }

    public void PlayBuzzerSound()
    {
        buzzer.Play();
    }

    public void ElectricityOnWithBatteryAudio()
    {
        for(int i=0;i<transformers.Length;i++)
        {
            transformers[i].Play();
        }
        batteries.Play();
    }
    public void ElectricityOffAudio()
    {
        for(int i=0;i<transformers.Length;i++)
        {
            transformers[i].Stop();
        }
        batteries.Stop();

    }

}
