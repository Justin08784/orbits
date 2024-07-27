using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    private static GravityManager Instance; // there should be only 1 manager
    private static List<Sphere> bodies;

    private readonly double c = Math.Pow(2.0, 1.0/3.0);

    double[] cs;
    double[] ds;

    private void Awake()
    {
        if (Instance != null) {
            // manager already init
            Destroy(this);   
        }

        Instance = this;
        DontDestroyOnLoad(Instance);

        cs = new double[4] {0.5, 0.5*(1.0-c), 0.5*(1.0-c), 0.5};
        ds = new double[4] {0.0,         1.0,          -c, 1.0};

        double divisor = 2.0 - c;
        for (int i = 0; i < cs.GetLength(0); i++) {
            cs[i] /= divisor;
            ds[i] /= divisor;
        }
    }

    void Start()
    {
        
    }

    public static void register_body(Sphere sphere)
    {
        bodies.Add(sphere);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
