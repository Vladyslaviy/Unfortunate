using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    bool isJumping = false;
    float jump_started_y = 1.08f;
    public float jumpHeight = 8.0f;
    public float gravity = 9.81f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }
    void Update()
    {
        
        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpHeight;
            isJumping = true;
            jump_started_y = transform.position.y;
            
        }
        if (!isJumping)
        {
            if (!controller.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;

            }
        }

        controller.Move(moveDirection * Time.deltaTime);
        //controller.Move(moveDirection * Time.deltaTime);
        if (isJumping)
        {
            if (transform.position.y >= jump_started_y + jumpHeight)
            {
                isJumping = false;
            }
        }
    }

}
