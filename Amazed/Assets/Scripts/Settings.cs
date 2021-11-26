using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioSource music;
    public Slider slider;
    public Text txtVolume;
    // Start is called before the first frame update
    void Start()
    {
        music.volume = 0.5f;
         slider.value = music.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }

    public void SliderChange()
    {
        music.volume = slider.value;
        txtVolume.text = "Volume " + (music.volume * 100).ToString("00") + "%";
    }
}
