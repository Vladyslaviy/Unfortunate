using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform transformPlayer;

    float rotateX = 0f;
    float rotateY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.position= transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        rotateX -= mouseY;
        rotateY += mouseX;

        rotateX = Mathf.Clamp(rotateX, -90f, 90f);
        //transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);
        transform.eulerAngles = new Vector3(rotateX, rotateY, 0);


        Vector3 vector3 = new Vector3(transformPlayer.position.x, transformPlayer.position.y + 0.85f, transformPlayer.position.z);
        transform.position = vector3;
    }

}
