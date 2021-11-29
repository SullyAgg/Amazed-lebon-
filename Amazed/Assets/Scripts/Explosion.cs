using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float timer;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle.Emit(100);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<0)
        {
            Destroy(gameObject);
        }
    }
}
