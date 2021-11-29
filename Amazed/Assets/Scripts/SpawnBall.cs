using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnBall : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject camera;
    public float bulletSpeed = 20;

    public LampeController lampeScript;
    public float timerShoot;
    float timerShootReset;
    // Start is called before the first frame update
    void Start()
    {
        timerShootReset = timerShoot;
    }

    // Update is called once per frame
    void Update()
    {
        timerShoot -= Time.deltaTime;
        if (lampeScript.timerFire > 5)
        {
            if (Input.GetMouseButtonDown(0) && timerShoot<0)
            {
                timerShoot = timerShootReset;
                Fire();
            }
        }
    }

    



    void Fire()
    {
        GameObject bulletClone = Instantiate(fireBall,camera.transform.position,camera.transform.rotation);
    
        Rigidbody bulletRB = bulletClone.GetComponent<Rigidbody>();
        bulletRB.velocity = camera.transform.forward * bulletSpeed;

    }
   
}
