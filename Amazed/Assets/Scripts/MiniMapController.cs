using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapController : MonoBehaviour
{
    public RawImage imageObject;
    // Start is called before the first frame update
    void Start()
    {
        imageObject.enabled = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetMapOn();
        }
        Debug.Log("collision");
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetMapOff();
        }
    }

    void SetMapOn()
    {
        imageObject.enabled = true;
        Time.timeScale = 0.6f;
    }
    void SetMapOff()
    {
        imageObject.enabled = false;
        Time.timeScale = 1f;
    }
}
