using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    Terrain terrain;
    public float distance = 2000;
    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();
        terrain.distance = distance;
    }

    // Update is called once per frame
    void Update()
    {
        terrain = GetComponent<Terrain>();
        terrain.distance = distance;
    }
}
