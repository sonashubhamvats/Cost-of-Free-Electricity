using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KeyManager : MonoBehaviour
{
    public static KeyManager instance;
    public AudioSource audioSource;
    public AudioClip click;
    private void Awake()
    {
        if(instance==null)
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
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

    public void BackToMainMenu()
    {
        Cursor.lockState=CursorLockMode.None;
        SceneManager.LoadScene("StartScene");
        audioSource.PlayOneShot(click);


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
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            BackToMainMenu();
        }
    }

}
