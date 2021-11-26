using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LampeController : MonoBehaviour
{
    public Text fireTimerText;
    public ParticleSystem orangeSmoke;
    public ParticleSystem flame;
    public ParticleSystem sparks;
    public ParticleSystem smoke;
    public ParticleSystem fire;

    public Light fireLight;
    public AudioSource flammeAllume;
    public AudioSource flammeAudio;
    
    public float timerFire ;
    float timerFireReset;
    public float lightIntensity = 5;
    public bool playFlammeAllume;
    public LevelManager levelManager;


    // Start is called before the first frame update
    void Start()
    {
        timerFireReset = timerFire;
        orangeSmoke.Play();
        smoke.Play();
        flame.Play();
        sparks.Play();
        fire.Play();

        fireLight.intensity = lightIntensity;
        flammeAudio.Play();
        fireTimerText.text = "0";


    }

    // Update is called once per frame
    void Update()
    {
        // le feu s'allume si le timer est plus grand que 0
        if (timerFire>=0)
        {
            timerFire -= Time.deltaTime;
            fireTimerText.text = ((int)timerFire).ToString();

            orangeSmoke.transform.localScale = Vector3.one;
            smoke.transform.localScale = Vector3.one;
            flame.transform.localScale = Vector3.one;
            sparks.transform.localScale = Vector3.one;

            fireLight.intensity = lightIntensity;

            // Sound
            
            if (playFlammeAllume)
            {
                playFlammeAllume = false;
                flammeAllume.Play();
                flammeAudio.Play();
            }
            
        }

        if (timerFire <0)
        {
            orangeSmoke.transform.localScale = Vector3.zero;
            smoke.transform.localScale = Vector3.zero;
            flame.transform.localScale = Vector3.zero;
            sparks.transform.localScale = Vector3.zero;
            fire.transform.localScale = Vector3.zero;

            fireLight.intensity = 0;
            flammeAudio.Pause();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            timerFire = timerFireReset;
            playFlammeAllume = true;
            
        }

 
       
    }
     void OnTriggerEnter(Collider other)
    {
        //reset le timer de la lampe
        if (other.gameObject.tag == "CampFire")
        {
            timerFire = timerFireReset;
            playFlammeAllume = true;
            timerFire = timerFireReset;
            
        }
        
    }
     
    
    
}
