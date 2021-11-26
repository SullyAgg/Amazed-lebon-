using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappeController : MonoBehaviour
{

    public GameObject trappe;
    public float trappeSpeed;
    bool trappeDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trappeDown && trappe.transform.position.y > 5)
        {
            trappe.transform.position += Vector3.down * trappeSpeed;
        }
        else if (trappe.transform.position.y <= 5)
        {
            trappeDown = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && trappe.transform.position.y < 15)
        {
            trappe.transform.position += Vector3.up * trappeSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            trappeDown = true;
        }
    }
}
