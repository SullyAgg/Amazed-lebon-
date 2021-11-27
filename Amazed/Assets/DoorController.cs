using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorController : MonoBehaviour
{
    public GameObject door;
    public GameObject player;
    public float doorSpeed;

    public float doorPosition = 3;
    public bool doorOpen = false;
    public bool openDoor = false;
    private float doorPos;
    public LevelManager levelManager;
    public Text doorText;
    public bool playerNextDoor;


    private void Start()
    {
        doorPos = doorPosition;
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
            else
            {
                doorText.text = "";
            }
        }
    }
    
    void OpenDoor()
    {
        if (doorPos >= 0)
        {
            doorPos -= doorSpeed * Time.deltaTime;
            door.transform.position += Vector3.up * doorSpeed * Time.deltaTime;
            Debug.Log("opendoor");
        }
        else
        {
            doorOpen = true;
            openDoor = false;
        }
    }



}
