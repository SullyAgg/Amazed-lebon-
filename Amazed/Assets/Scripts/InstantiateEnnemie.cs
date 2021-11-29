using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnnemie : MonoBehaviour
{
    public Transform[] target;
    public GameObject ennemie;
    public float timer=5;
    private float resetTimer;
    // Start is called before the first frame update
    void Start()
    {
        resetTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            Instantiate(ennemie, target[0].position, Quaternion.identity);
            timer = resetTimer;
            
        }
    }
}
