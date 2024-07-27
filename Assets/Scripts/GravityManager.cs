using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    private static GravityManager Instance; // there should be only 1 manager
    private static List<Sphere> bodies;

    private readonly double c = Math.Pow(2.0, 1.0/3.0);

    /* integrator coeffs */
    double[] cs; // displacement update coeffs
    double[] ds; // velocity update coeffs

    private double dt = 0.01;

    private int upd_cnt = 0;

    private void Awake()
    {
        if (Instance != null) {
            // manager already init
            Destroy(this); 
            return;
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

    public static void register_body(Sphere sphere)
    {
        bodies.Add(sphere);
    }
    double compute_accel(double x)
    {
        double k_by_m = 1; // k / m
        return -k_by_m * x;
    }

    void FixedUpdate()
    {
        Sphere curr_body = bodies[0];
        for (int i = 0; i < cs.GetLength(0); i++) {
            double a = compute_accel(curr_body.r.x);
            curr_body.v.x += (float) (ds[i] * a * dt);
            curr_body.r.x += (float) (cs[i] * curr_body.v.x * dt);
        }
        upd_cnt += 1;
    }
}
