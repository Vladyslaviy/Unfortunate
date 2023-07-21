using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{



    // Start is called before the first frame update
    private CharacterController controller;
    

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 moveDirection_ = Vector3.zero;

    private float turner;
    private float looker;
    


    bool isJumping = false;
    bool isFalling = false;
    float jump_started_y = 1.08f;


    ///PUPLIC
    private float speed = 20.0f;

    private float sensitivity = 5;
    
    private float jumpHeight = 30.0f;
    private float jumpStartSpeed = 7.5f;
    private float jumpAccelerationSpeed = -0.05f;
    private float jumpCurrentSpeed = 1.0f;
    
    private float fallMaxSpeed = 30.0f;
    private float fallStartSpeed = 1.0f;
    private float fallAccelerationSpeed = 0.05f;
    private float fallCurrentSpeed = 1.0f;

    ///END PUPLIC
    //public Transform orientation;

    
    
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Update()
    {
        if (true)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

        }
        looker = -Input.GetAxis("Mouse Y") * sensitivity;

        if (looker != 0)
        {
            //transform.eulerAngles += new Vector3(0, looker, 0);
        }
        if (Input.GetButton("Jump") && !isJumping && IsGrounded() && !isFalling)
        {
            jumpCurrentSpeed = jumpStartSpeed;
            isJumping = true;
            jump_started_y = transform.position.y;
        }
        if (!isJumping && !isFalling)
        {
            if (!IsGrounded())
            {
                
                fallCurrentSpeed = fallStartSpeed;
                isFalling = true;
            }
            else
            {
                isFalling = false;
            }
        }
        if (!IsGrounded())
        {
            //Debug.LogWarning("SSSSSSSSSS");
        }

        if (isFalling)
        {

            if (IsGrounded())
            {
                isFalling = false;
                moveDirection.y = 0;
            }
            else
            {
                //Debug.LogWarning(transform.position.y);
                moveDirection.y = -fallCurrentSpeed;
                if (fallCurrentSpeed < fallMaxSpeed)
                {
                    fallCurrentSpeed += fallAccelerationSpeed;
                }
            }
        }



        if (isJumping)
        {
            if (transform.position.y >= jump_started_y + jumpHeight || jumpCurrentSpeed <= 0)
            {
                isJumping = false;
                //Debug.LogWarning(jump_started_y+"\t\t"+ jumpHeight);
            }
            else
            { moveDirection.y = jumpCurrentSpeed; jumpCurrentSpeed += jumpAccelerationSpeed; }
        }
        controller.Move(moveDirection * Time.deltaTime);
        //IsGrounded()
    }

    private float distToGround = 0f;

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "CoinObject")
        {
            transform.position = new Vector3{x=1,y=320,z=1 };
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "CoinObject")
        {
            transform.position = new Vector3 { x = 1, y = 320, z = 1 };
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }


    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
    void OnCollisionStay()
    {
    }

}