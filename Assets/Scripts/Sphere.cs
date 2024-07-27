using UnityEngine;




public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 v;
    public Vector3 r;
    public double m;

    void Start()
    {
        v = Vector3.zero;
        r = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = r;
    }
}
