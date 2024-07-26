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
    private double x = 1;
    private double a = 0;

    private double dt = 0.01;

    private double k_by_m = 1;

    private int upd_cnt = 0;

    private readonly double c = Math.Pow(2.0, 1.0/3.0);

    double[] cs;
    double[] ds;
    void Start()
    {
        transform.position = new Vector3((float) x, 0, 0);
        a = -k_by_m * x;

        cs = new double[4] {0.5, 0.5*(1.0-c), 0.5*(1.0-c), 0.5};
        ds = new double[4] {0.0,         1.0,          -c, 1.0};

        double divisor = 2.0 - c;
        for (int i = 0; i < cs.GetLength(0); i++) {
            cs[i] /= divisor;
            ds[i] /= divisor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (upd_cnt == 0) {       
            Debug.Log(string.Format("P0 a = {0}, v = {1}, x = {2}", a, v, transform.position.x));
        } else if (upd_cnt == 1) {
            Debug.Log(string.Format("P1 a = {0}, v = {1}, x = {2}", a, v, transform.position.x));
        }
        x += (float) (v * dt);
        transform.position = new Vector3((float) x, transform.position.y, transform.position.z);
        v += a * dt;
        a = -k_by_m * x;
        upd_cnt += 1;
    }
}
