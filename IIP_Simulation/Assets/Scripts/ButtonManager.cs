using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip click;
    public static ButtonManager instance;

    
    private void Awake()
    {
        MakeInstance();
    }
    private void MakeInstance()
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

    public void StartVillage()
    {
        SceneManager.LoadScene("VillageScene");
        audioSource.PlayOneShot(click);
    }
    public void StartCity()
    {
        SceneManager.LoadScene("CityScene");
        audioSource.PlayOneShot(click);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
