using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Assertions;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    private double v = 0;
    private double a = 0;

    private double delta_t = 0.01;

    private double k_by_m = 5;

    private int upd_cnt = 0;
    void Start()
    {
        transform.position = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (upd_cnt == 0) {       
            Debug.Log(string.Format("P0 a = {0}, v = {1}, x = {2}", a, v, transform.position.x));
        } else if (upd_cnt == 1) {
            Debug.Log(string.Format("P1 a = {0}, v = {1}, x = {2}", a, v, transform.position.x));
        }
        transform.position = new Vector3(transform.position.x + (float) (v * delta_t), transform.position.y, transform.position.z);
        v += a * delta_t;
        a = -k_by_m * transform.position.x;
        upd_cnt += 1;
    }
}
