using System;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    private static GravityManager Instance; // there should be only 1 manager
    private static List<Sphere> bodies = new();


    /* integrator coeffs */
    private readonly double c = Math.Pow(2.0, 1.0/3.0);
    double[] cs; // displacement update coeffs
    double[] ds; // velocity update coeffs

    private double dt = 0.01;

    private uint upd_cnt = 0;

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
    Vector3 compute_accel(int body_idx)
    {
        Sphere curr_body = bodies[body_idx];
        Vector3 r = curr_body.r;
        Vector3 a = Vector3.zero;

        for (int i = 0; i < bodies.Count; i++) {
            if (i == body_idx) 
                continue;
            
            Sphere other_body = bodies[i];
            Vector3 displacement = other_body.r - r;

            a += (float) other_body.m * displacement * (float) Math.Pow(displacement.magnitude, -3.0);
        }

        return a;
    }

    void FixedUpdate()
    {
        // without substep tmps (has processing order bias)
        // for (int i = 0; i < cs.GetLength(0); i++) {
        //     for (int body_idx = 0; body_idx < bodies.Count; body_idx++) { 
        //         Sphere curr_body = bodies[body_idx];
        //         Vector3 a = compute_accel(body_idx);
        //         curr_body.v += a * (float) (ds[i] * dt);
        //         curr_body.r += curr_body.v * (float) (cs[i] * dt);
        //     }
        // }

        // with substep tmps (solves processing order bias)
        for (int i = 0; i < cs.GetLength(0); i++) {
            // perform one substep

            for (int body_idx = 0; body_idx < bodies.Count; body_idx++) {
                // compute tmp values using last substep's 'architectural' values
                Sphere curr_body = bodies[body_idx];
                if (curr_body.stationary)
                    continue;

                Vector3 a = compute_accel(body_idx);
                curr_body.tmp_v += a * (float) (ds[i] * dt);
                curr_body.tmp_r += curr_body.tmp_v * (float) (cs[i] * dt);
            }

            for (int body_idx = 0; body_idx < bodies.Count; body_idx++) {
                // propagate tmp values to arch. variables
                Sphere curr_body = bodies[body_idx];
                curr_body.v = curr_body.tmp_v;
                curr_body.r = curr_body.tmp_r;
            }
        }
        upd_cnt += 1;
    }
}
