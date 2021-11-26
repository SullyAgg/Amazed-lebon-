using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteController : MonoBehaviour
{
    public GameObject door;
    public float doorSpeed;
    bool doorDown;
    float closePositionY;
    //float closePositionY;
    // Start is called before the first frame update
    void Start()
    {
       // float closePositionY = door.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorDown && door.transform.position.y >  10)
        {
            door.transform.position += Vector3.down * doorSpeed;
        }
        else if (door.transform.position.y <= 10)
        {
            doorDown = false;
        }
        
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && door.transform.position.y < 10 + 10)
        {
            door.transform.position += Vector3.up * doorSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            doorDown = true;
        }
    }
}
