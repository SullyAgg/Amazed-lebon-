using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie : MonoBehaviour
{
    public GameObject explosionParticle;
    public Transform spawnExplosion;
    public Transform spawn;
    public bool damage;
    public float timerDamage;
    float resetTimer;
    public GameObject hitMarker;
    public int life = 100;
    public int resetLife;
    public int hitDamage=100;
    


    // Start is called before the first frame update
    void Start()
    {
        resetTimer = timerDamage;
        resetLife = life;
    }

    // Update is called once per frame
    void Update()
    {
        if (damage)
        {
            
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
        if (life <= 0)
        {
            hitMarker.SetActive(false);
            Kill();
            life = resetLife;
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !damage)
        {
            damage = true;
            hitMarker.SetActive(true);
        }

        if (other.gameObject.tag == "Bullet")
        {
            life -= hitDamage;
        }
    }


    private void Kill()
    {
        Instantiate(explosionParticle,spawnExplosion.position,Quaternion.identity);
        gameObject.transform.position = spawn.transform.position;
    }



}
