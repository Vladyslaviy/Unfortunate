using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRoation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 euler = new Vector3 { x = 0, y = 0, z = 50 };
        transform.Rotate(euler * Time.deltaTime);
    }
}
