using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPickUp : MonoBehaviour
{
    public LevelManager levelManager;
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
            levelManager.pickUpNb += 1;
            levelManager.pickUpAudioBool = true;
            Destroy(gameObject);
        }
    }
}
