using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie : MonoBehaviour
{
    public GameObject explosionParticle;
    public Transform spawn;
    public bool damage;
    public float timerDamage;
    float resetTimer;
    public GameObject hitMarker;


    // Start is called before the first frame update
    void Start()
    {
        resetTimer = timerDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (damage)
        {
            hitMarker.SetActive(true);
            if(timerDamage==resetTimer)
            {
                LevelManager levelManager = GetComponentInParent<LevelManager>();
                levelManager.life -= 1;
            }
            
            timerDamage -= Time.deltaTime;
            if(timerDamage < 0)
            {
                damage = false;
                timerDamage = resetTimer;
                hitMarker.SetActive(false);
            }
        }
        

   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !damage)
        {
            damage = true;
        }

        if (other.gameObject.tag == "Bullet")
        {
            Kill();
        }
    }


    private void Kill()
    {
        Instantiate(explosionParticle,spawn.position,Quaternion.identity);
        Destroy(gameObject);
    }



}
