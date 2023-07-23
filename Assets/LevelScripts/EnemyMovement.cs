using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterController controller;
    public Rigidbody rigidbody;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 moveDirection_ = Vector3.zero;

    private float turner;
    private float looker;



    bool isJumping = false;
    bool isFalling = false;
    float jump_started_y = 1.08f;


    private float speed = 10.0f;

    private float sensitivity = 5;




    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        if (true)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            controller.Move(moveDirection * Time.deltaTime);
        }
        looker = -Input.GetAxis("Mouse Y") * sensitivity;

        if (looker != 0)
        {
            //transform.eulerAngles += new Vector3(0, looker, 0);
        }
    }
}
