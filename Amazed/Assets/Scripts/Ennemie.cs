using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Ennemie : MonoBehaviour
{
    public float distance;
    public GameObject explosionParticle;
    public Transform spawnExplosion;
    public bool damage;
    public float timerDamage;
    float resetTimer;
    public GameObject hitMarker;
    public int life = 100;
    public int resetLife;
    public int hitDamage=100;
    NavMeshAgent fantome;
    public Transform player;
    public bool dead;
    public float speed;
    public float timerDead = 10;
    public float resetTimerDead;
    public Animator fantomeAnim;

    LevelManager levelManager;
    Vector3 initialPos;


    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        levelManager = GetComponentInParent<LevelManager>();
        resetTimerDead = timerDead;
        dead = false;
        fantome = GetComponent<NavMeshAgent>();
        resetTimer = timerDamage;
        resetLife = life;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.position.x - transform.position.x) <= distance && Mathf.Abs(player.position.z - transform.position.z) <= distance)
        {
            fantome.SetDestination(player.position);
        }
        else
        {
            fantome.SetDestination(initialPos);
        }
        if (damage)
        {
            timerDamage -= Time.deltaTime;
            if(timerDamage<0)
            {
                hitMarker.SetActive(false);
            }
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
            Kill();
        }
    }


    private void Kill()
    {
        Instantiate(explosionParticle,spawnExplosion.position,Quaternion.identity);
        hitMarker.SetActive(false);
        Destroy(this.gameObject);
    }



}
