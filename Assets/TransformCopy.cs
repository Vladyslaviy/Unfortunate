using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCopy : MonoBehaviour
{
    public Transform transform_;
    void Update()
    {
        transform.position = transform_.position;
        transform.rotation = transform_.rotation;
    }
}
