using UnityEngine;




public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 v;
    public Vector3 tmp_v;
    public Vector3 r;
    public Vector3 tmp_r;
    public double m;

    private int upd_cnt = 0;

    void Awake()
    {
        v = Vector3.zero;
        r = transform.position;
        tmp_v = v;
        tmp_r = r;
    }

    public void set_v(Vector3 new_v)
    {
        v = new_v;
        tmp_v = new_v;
    }

    public void set_m(double new_m)
    {
        m = new_m;
    }

    void FixedUpdate()
    {
        // Debug.Log(string.Format("r: {0} |||| v: {1}", r, v));
        transform.position = r;
        upd_cnt++;
    }
}
