using Unity.VisualScripting;
using UnityEngine;




public class Sphere : MonoBehaviour
{
    private static int num_bodies = 0;
    
    /* identifiers */
    public int body_idx;
    
    /* physical properties */
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

        body_idx = num_bodies++;
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
        Debug.Log(string.Format("<{2}> r: {0} // v: {1}", r, v, body_idx));
        transform.position = r;
        upd_cnt++;
    }
}
