using System;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public GameObject Sphere_Prefab;
    public GameObject Gravity_Manager_Prefab;
    public Camera m_MainCamera;
    private int curr_body_idx; // currently being followed by camera


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

        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;
        //This enables Main Camera
        m_MainCamera.enabled = true;
        
        // sun
        Sphere sphere1 = Instantiate(Sphere_Prefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Sphere>();
        // earth
        Sphere sphere2 = Instantiate(Sphere_Prefab, new Vector3(Distances.earth, 0, 0), Quaternion.identity).GetComponent<Sphere>();
        
        double sun_jupiter = 5.367 * Distances.earth;
        double jupiter_ganymede = 1071600000;
        // jupiter
        Sphere sphere3 = Instantiate(Sphere_Prefab, new Vector3((float) -sun_jupiter, 0, 0), Quaternion.identity).GetComponent<Sphere>();
        // ganymede
        Sphere sphere4 = Instantiate(Sphere_Prefab, new Vector3((float) -(sun_jupiter + jupiter_ganymede), 0, 0), Quaternion.identity).GetComponent<Sphere>();


        sphere1.set_v(new Vector3(0, 0, 0));
        sphere2.set_v(new Vector3(0, 0, 29800f));
        sphere3.set_v(new Vector3(0, 0, -12440f));
        sphere4.set_v(new Vector3(0, 0, -(12440+10880)));
        
        sphere1.set_m(Masses.sun);
        sphere2.set_m(Masses.earth);
        sphere3.set_m(317.83 * Masses.earth);
        sphere4.set_m(0.025 * Masses.earth);

        sphere1.set_color(Color.yellow);
        sphere2.set_color(Color.cyan);
        sphere3.set_color(Color.red);
        sphere4.set_color(Color.green);

        double bruh = 1.0/Distances.earth;
        Debug.Log("bruh" + bruh);
        // double bruh = 1000/Distances.earth;
        float sun = (float) bruh * Radii.sun;
        float earth = (float) bruh * Radii.earth;
        float jupiter = (float) bruh * Radii.jupiter;
        float ganymede = (float) bruh * Radii.ganymede;
        sphere1.scale(sun);
        sphere2.scale(earth);
        sphere3.scale(jupiter);
        sphere4.scale(ganymede);
        sphere1.radius = Radii.sun;
        sphere2.radius = Radii.earth;
        sphere3.radius = Radii.jupiter;
        sphere4.radius = Radii.ganymede;

        sphere1.set_stationary(true);
        // sphere3.set_stationary(true);
        // sphere4.set_stationary(true);

        GravityManager.register_body(sphere1);
        GravityManager.register_body(sphere2);
        GravityManager.register_body(sphere3);
        GravityManager.register_body(sphere4);

        // let camera follow first body
        curr_body_idx = 0;
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {
            curr_body_idx = (curr_body_idx + 1) % GravityManager.bodies.Count;
            Debug.Log("curr_body: " + curr_body_idx);
        }

        Sphere curr_body = GravityManager.bodies[curr_body_idx];
        
        Vector3 body_pos = curr_body.transform.position;
        float offset = 0.1f * (float) (curr_body.radius / Radii.sun);
        m_MainCamera.transform.position = new Vector3(body_pos.x, body_pos.y + offset, body_pos.z);

    }
}


/*
- Make a method that sets a body's velocity to the perfect velocity
required to maintain circular orbit about a planet

- Make bodies trace a path (gradually fading over time); luminescent?

- Add a black panel at the bottom

- Simulate orbital resonance on Jupiter

- Add acceleration/velocity vectors to demonstrate mutual planet interactions

- Scale body sizes with scroll up/down (the bodies should maintain the same ratio of sizes though)

- Add an option to remove 'g' from compute_accel so that the current presets can be used

- Simulate moons (and submoons?)
Trying to represent ganymede and we seem to be encountering floating-point precision issues
(actually im not sure sure about this...)

ok there is SOME FP issues, however it is not overwhelming enough to put ganymede inside jupiter.
In fact the positions seem RELATIVELY accurate.
Then does unity have trouble rendering exact positions at the granularity required?
(e.g. 
jupiter at: 5.367, 0, 0
and 
ganymede at: -5.37416320356, 0, 0)


- **IMPORTANT** Use vector3d for double precision
<compute and store values in double precision; visualize using float precision>


- Simulate everything in the background and... when a certain object is close
enough to be visible, render it (with a new scene)
When objects are too distant, have pointers indicating distances

- Make an infinite-fuel/acceleration spaceship to travel dis shit


- Stationary field -> rename to no_accel
Create a 'no_field' that makes body behave like a point mass (i.e.
does not create a field of its own)

*/