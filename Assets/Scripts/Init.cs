using System;
using UnityEngine;

public class Init : MonoBehaviour
{
    public GameObject Sphere_Prefab;
    public GameObject Gravity_Manager_Prefab;


    private void preset_orbit_tmp_moon_capture()
    {
        Sphere sphere1 = Instantiate(Sphere_Prefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Sphere>();
        Sphere sphere2 = Instantiate(Sphere_Prefab, new Vector3(-10, 0, 0), Quaternion.identity).GetComponent<Sphere>();
        Sphere sphere3 = Instantiate(Sphere_Prefab, new Vector3(20, 0, 0), Quaternion.identity).GetComponent<Sphere>();

        sphere1.set_v(new Vector3(0, 0, 0));
        sphere2.set_v(new Vector3(0, 0, (float) Math.Pow(10, -0.5)));
        sphere3.set_v(new Vector3(0, 0, (float) -Math.Pow(20, -0.5)));
        
        sphere1.set_m(1.0);
        sphere2.set_m(0.01);
        sphere3.set_m(0.025);

        sphere1.set_color(Color.yellow);
        sphere2.set_color(Color.cyan);
        sphere3.set_color(Color.red);

        sphere1.set_stationary(true);

        GravityManager.register_body(sphere1);
        GravityManager.register_body(sphere2);
        GravityManager.register_body(sphere3);
    }
    private void preset_orbit_destabilize()
    {
        preset_orbit_tmp_moon_capture();

        Sphere sphere4 = Instantiate(Sphere_Prefab, new Vector3(40, 0, 0), Quaternion.identity).GetComponent<Sphere>();
        sphere4.set_v(new Vector3(0, 0, (float) -Math.Pow(40, -0.5)));
        sphere4.set_m(0.01);
        sphere4.set_color(Color.magenta);
        GravityManager.register_body(sphere4);
    }

    void Awake()
    {
        Instantiate(Gravity_Manager_Prefab, Vector3.zero, Quaternion.identity);
        
    }
}


/*
- Make a method that sets a body's velocity to the perfect velocity
required to maintain circular orbit about a planet

- Make bodies trace a path (gradually fading over time); luminescent?

- Add a black panel at the bottom

- Simulate orbital resonance on Jupiter

- Add mass

- Add acceleration/velocity vectors to demonstrate mutual planet interactions

*/