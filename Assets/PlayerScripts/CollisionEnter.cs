using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnter : MonoBehaviour
{
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TestStart");
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.IsSleeping())
        {
            rigidbody.WakeUp();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
    }
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay");
    }
}
