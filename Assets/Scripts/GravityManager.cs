using System;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    private static GravityManager Instance; // there should be only 1 manager
    private static List<Sphere> bodies = new();

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
    Vector3 compute_accel(Vector3 r)
    {
        return r * (float) -Math.Pow(r.magnitude, 3.0);
    }

    void FixedUpdate()
    {
        Sphere curr_body = bodies[0];
        for (int i = 0; i < cs.GetLength(0); i++) {
            Vector3 a = compute_accel(curr_body.r);
            curr_body.v += a * (float) (ds[i] * dt);
            curr_body.r += curr_body.v * (float) (cs[i] * dt);
        }
        upd_cnt += 1;
    }
}
