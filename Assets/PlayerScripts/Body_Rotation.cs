using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Rotation : MonoBehaviour
{
    public Transform orientation;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0,orientation.eulerAngles.y,0);
        //transform.rotation = Quaternion.Euler(0, orientation.rotation.y, 0);
    }
}
