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
    private float doorPos;
    public LevelManager levelManager;
    public bool keyUsed;
    public Text doorText;
    private bool doorUIOn;


    private void Start()
    {
        doorPos = doorPosition;
        doorOpen = false;
        keyUsed = false;
        doorUIOn = false;
        doorText.text = "";

    }

    private void Update()
    {

        //1. You have to calculate vector between enemy and player:

        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();

        //2. Now you can create Ray
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;
        Debug.DrawRay(transform.position, direction / 10, Color.red);

        // 3 check distance between player and door.

        if (levelManager.keyPickUpNb > 0)
        {

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance < 5 && !doorOpen)
                {
                    if (!doorUIOn)
                    {
                        doorText.text = "Press E to use key";
                    }

                    if (Input.GetKey(KeyCode.E) && !keyUsed)
                    {

                        keyUsed = true;
                    }

                    if (keyUsed)
                    {
                        doorText.text = "";
                        OpenDoor();
                    }


                }
                else if (hit.distance >= 10 && doorOpen)
                {
                    doorText.text = "";
                    levelManager.keyPickUpNb -= 1;
                }
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
        }
    }
    void CloseDoor()
    {
        if (doorPos <= doorPosition)
        {
            doorPos += doorSpeed * Time.deltaTime;
            door.transform.position -= Vector3.up * doorSpeed * Time.deltaTime;
            
            Debug.Log("closedoor");
        }
        else
        {
            doorOpen = false;

        }
    }



}
