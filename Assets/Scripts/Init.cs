using UnityEngine;

public class Init : MonoBehaviour
{
    public GameObject Sphere_Prefab;
    public GameObject Gravity_Manager_Prefab;

    void Awake()
    {
        Instantiate(Gravity_Manager_Prefab, Vector3.zero, Quaternion.identity);
        Sphere sphere1 = Instantiate(Sphere_Prefab, new Vector3(2, 0, 0), Quaternion.identity).GetComponent<Sphere>();
        Sphere sphere2 = Instantiate(Sphere_Prefab, new Vector3(-2, 0, 0), Quaternion.identity).GetComponent<Sphere>();

        // sphere1.v = 10 * Vector3.one;
        // sphere1.set_v(10 * Vector3.one);
        GravityManager.register_body(sphere1);
        GravityManager.register_body(sphere2);
    }
}
