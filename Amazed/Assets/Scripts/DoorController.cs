using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorController : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public bool doorOpen = false;
    public bool openDoor = false;
    public LevelManager levelManager;
    public Text doorText;
    public bool playerNextDoor;


    private void Start()
    {
        doorOpen = false;
        openDoor=false;
        doorText.text = "";
        playerNextDoor = false;

    }

    private void Update()
    {
        if(openDoor)
        {
            Debug.Log("Open");
            OpenDoor();
            openDoor = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if (levelManager.keyPickUpNb > 0 && !doorOpen)
            {
                Debug.Log("playernextdoor");
                doorText.text = "Press E to use key";
                if(Input.GetKey(KeyCode.E))
                {
                    openDoor = true;
                    levelManager.keyPickUpNb -= 1;
                }
            }
            
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            doorText.text = "";
        }
    }

    void OpenDoor()
    {
        animator.SetTrigger("Open");
    }



}
