using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie : MonoBehaviour
{
    public GameObject explosionParticle;
    public Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
            LevelManager levelManager = GetComponentInParent<LevelManager>();
            levelManager.life -= 1;
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
