using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    
    public float playerSpeed;

    Vector3 velocity;
    public float gravity = -20f;
    public Transform capteurSol;
    public float distanceSol = 0.4f;
    public LayerMask solMask;
    bool estAuSol;
    public float jumpHeight;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
        Gravity();
    }


    void Move()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * playerSpeed * Time.deltaTime);

        //sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move *0.6f* playerSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && estAuSol)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

    }
    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //vrai si la sphere creer rentre en collision avec un objet de Mask sol
        estAuSol = Physics.CheckSphere(capteurSol.position, distanceSol, solMask);

        if (estAuSol && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    } 
}
