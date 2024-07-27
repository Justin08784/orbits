using UnityEngine;

public class Init : MonoBehaviour
{
    public GameObject Sphere_Prefab;
    public GameObject Gravity_Manager_Prefab;

    void Awake()
    {
        Instantiate(Gravity_Manager_Prefab, Vector3.zero, Quaternion.identity);
        Sphere sphere1 = Instantiate(Sphere_Prefab, new Vector3(2, 2, 2), Quaternion.identity).GetComponent<Sphere>();
        // Sphere sphere2 = Instantiate(Sphere_Prefab, new Vector3(-2, 0, 0), Quaternion.identity).GetComponent<Sphere>();

        GravityManager.register_body(sphere1);
        // GravityManager.register_body(sphere2);
    }
}
