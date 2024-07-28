using UnityEngine;

public class Init : MonoBehaviour
{
    public GameObject Sphere_Prefab;
    public GameObject Gravity_Manager_Prefab;

    void Awake()
    {
        Instantiate(Gravity_Manager_Prefab, Vector3.zero, Quaternion.identity);
        Sphere sphere1 = Instantiate(Sphere_Prefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Sphere>();
        Sphere sphere2 = Instantiate(Sphere_Prefab, new Vector3(-2, 0, 0), Quaternion.identity).GetComponent<Sphere>();

        // sphere1.v = 10 * Vector3.one;
        // sphere1.set_v(new Vector3(0, 0, 20));
        // sphere2.set_v(new Vector3(0, 0, -20));
        sphere1.set_v(new Vector3(0, 0, 0.4f));
        sphere2.set_v(new Vector3(0, 0, -4));

        sphere1.set_m(1.0);
        sphere2.set_m(0.1);
        GravityManager.register_body(sphere1);
        GravityManager.register_body(sphere2);
    }
}


/*
- Make a method that sets a body's velocity to the perfect velocity
required to maintain circular orbit about a planet

- Make bodies trace a path (gradually fading over time); luminescent?

- Add a black panel at the bottom

- Simulate orbital resonance on Jupiter

- Explain substep tmps

- Add mass

*/