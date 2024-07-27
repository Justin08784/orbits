using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public GameObject body;
    
    private readonly double c = Math.Pow(2.0, 1.0/3.0);

    double[] cs;
    double[] ds;

    void Start()
    {
        cs = new double[4] {0.5, 0.5*(1.0-c), 0.5*(1.0-c), 0.5};
        ds = new double[4] {0.0,         1.0,          -c, 1.0};

        double divisor = 2.0 - c;
        for (int i = 0; i < cs.GetLength(0); i++) {
            cs[i] /= divisor;
            ds[i] /= divisor;
        }

        // for (int y=0; y<height; ++y)
        // {
        //     for (int x=0; x<width; ++x)
        //     {
        //         Instantiate(block, new Vector3(x,y,0), Quaternion.identity);
        //     }
        // }       
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
