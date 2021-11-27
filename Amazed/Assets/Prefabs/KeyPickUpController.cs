using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpController : MonoBehaviour
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
            levelManager.keyPickUpNb += 1;
            levelManager.pickUpAudioBool = true;
            Destroy(gameObject);
        }
    }
}
