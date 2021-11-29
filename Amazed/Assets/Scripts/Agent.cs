using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    NavMeshAgent fantome;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        fantome = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x-target.transform.position.x)<=20 || Mathf.Abs(transform.position.z - target.transform.position.z) <= 20)
        {
            fantome.SetDestination(target.position );
        }
        else
        {
        }
    }
}
