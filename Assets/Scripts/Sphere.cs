using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Assertions;




public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 v;
    public Vector3 r;

    void Start()
    {
        v = Vector3.zero;
        r = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = r;
    }
}
