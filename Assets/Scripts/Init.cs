using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public GameObject Sphere_Prefab;
    public GameObject Gravity_Manager_Prefab;

    void Start()
    {
        Instantiate(Gravity_Manager_Prefab, Vector3.zero, Quaternion.identity);
        Sphere sphere1 = Instantiate(Sphere_Prefab, new Vector3(2, 0, 0), Quaternion.identity).GetComponent<Sphere>();
        Sphere sphere2 = Instantiate(Sphere_Prefab, new Vector3(-2, 0, 0), Quaternion.identity).GetComponent<Sphere>();

        GravityManager.register_body(sphere1);
        GravityManager.register_body(sphere2);
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
