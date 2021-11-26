using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivityY = 100f;
    public float sensitivityX = 100f;

    public Transform playerMesh;

    private float xRotation =0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

   
    void Update()
    {
        CameraMove();

        


    }
    void CameraMove()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * sensitivityY * Time.deltaTime;
        float mouseVertical = Input.GetAxis("Mouse Y") * sensitivityX * Time.deltaTime;

        xRotation -= mouseVertical;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerMesh.Rotate(Vector3.up * mouseHorizontal);
    }
}
