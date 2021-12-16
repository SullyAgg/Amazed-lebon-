using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
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
            LevelManager levelManager = GetComponentInParent<LevelManager>();
            levelManager.potionNb += 1;
            levelManager.pickUpAudioBool = true;
            Destroy(gameObject);

        }
    }
}
