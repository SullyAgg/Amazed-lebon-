using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    
    public Text timerText;
    public Text pickUpNbText;
    public Text keyPickUpNbText;
    public Text potionNbText;


    private float secondsCount;
    private int minuteCount;
    public float life = 3;

    public int pickUpNb =0;
    public int keyPickUpNb = 0;
    public int potionNb = 0;

    public GameObject player;
    public GameObject pausemenuui;

    public static bool Gameispaused = false;
    public bool pickUpAudioBool;
    public AudioSource pickUpAudio;
    public RawImage lifeBar3;
    public RawImage lifeBar2;
    public RawImage lifeBar1;

    public GameObject Settings;
    public GameObject campFire;
    

    private void Start()
    {
        
        Settings.SetActive(false);
        
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Gameispaused = false;
        pausemenuui.SetActive(false);
    }
    void Update()
    {
        UpdateTimerUI();
        Life();
        PickUp();
        KeyPickUp();
        Potion();

        if (Input.GetKeyDown(KeyCode.A)&&life<3&&potionNb>=1)
        {
            life += 1;
            potionNb -= 1;

        }

        if (Input.GetMouseButtonDown(1) && pickUpNb >= 3 )
        {
            pickUpNb -= 3;
            Instantiate(campFire, player.transform.position + Vector3.forward,Quaternion.identity);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Gameispaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }
    }
    public void Life()
    {
        if (life == 3)
        {
            lifeBar3.enabled = true;
            lifeBar2.enabled = false;
            lifeBar1.enabled = false;
        }
        if (life == 2)
        {
            lifeBar3.enabled = false;
            lifeBar2.enabled = true;
            lifeBar1.enabled = false;
        }
        if (life == 1)
        {
            lifeBar3.enabled = false;
            lifeBar2.enabled = false;
            lifeBar1.enabled = true;
        }
        if (life <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
    public void UpdateTimerUI()
    {
        secondsCount += Time.deltaTime;
        timerText.text = minuteCount + "m" + (int)secondsCount + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {

            minuteCount = 0;
        }
    }

    public void Potion()
    {
        potionNbText.text = "Potion x" + potionNb;
        if (pickUpAudioBool)
        {
            pickUpAudioBool = false;
            pickUpAudio.Play();
        }
    }
    public void PickUp()
    {
        pickUpNbText.text = "Wood x" + pickUpNb;
        if (pickUpAudioBool)
        {
            pickUpAudioBool = false;
            pickUpAudio.Play();
        }
    }
    public void KeyPickUp()
    {
        keyPickUpNbText.text = "key x" + keyPickUpNb;
        if (pickUpAudioBool)
        {
            pickUpAudioBool = false;
            pickUpAudio.Play();
        }
    }


    //fonction pour le menu pause et le menu
    public void Resume()
    {
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Gameispaused = false;
        pausemenuui.SetActive(false);

    }
    public void Pause()
    {

        pausemenuui.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    public void Loadmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quitgame()
    {
        Application.Quit();
    }
    public void SettingsMenu()
    {
        Settings.SetActive(true);
        pausemenuui.SetActive(false);
    }
}
