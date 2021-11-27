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
        fantome.SetDestination(target.position);
    }
}
