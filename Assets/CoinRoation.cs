using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRoation : MonoBehaviour
{
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        rigidbody.WakeUp();
        if (GetComponent<Rigidbody>().IsSleeping())
        {
            GetComponent<Rigidbody>().WakeUp();
        }
        Vector3 euler = new Vector3 { x = 0, y = 0, z = 50 };
        transform.Rotate(euler * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        if (collision.gameObject.name == "CoinObject")
        {
            transform.position = new Vector3 { x = 1, y = 320, z = 1 };
            Debug.Log("CoinObject");
        }

        if (collision.gameObject.tag != "CoinObject")
        {
            transform.position = new Vector3 { x = 1, y = 320, z = 1 };
            Debug.Log("NotCoinObject");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay");
        if (collision.gameObject.name == "CoinObject")
        {
            transform.position = new Vector3 { x = 1, y = 320, z = 1 };
            Debug.Log("CoinObject");
        }
    }
}
