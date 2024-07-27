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

    public void set_v(Vector3 new_v)
    {
        v = new_v;
    }

    void FixedUpdate()
    {
        transform.position = r;
    }
}
