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

    void Start()
    {
        v = Vector3.zero;
        r = transform.position;
        tmp_v = v;
        tmp_r = r;
    }

    public void set_v(Vector3 new_v)
    {
        v = new_v;
    }

    void FixedUpdate()
    {
        if (upd_cnt == 0) {
            Debug.Log(string.Format("0__{0}: v: {1}", this, v));
        } else if (upd_cnt == 1) {
            Debug.Log(string.Format("1__{0}: v: {1}", this, v));
        }

        transform.position = r;
        upd_cnt++;
    }
}
