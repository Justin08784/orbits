using Unity.VisualScripting;
using System.Collections.Generic;
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

    private List<Vector3> position_history;

    private int upd_cnt = 0;

    private MeshRenderer meshRenderer;
    private Renderer sphere_renderer;
    // private LineRenderer line_renderer;

    public bool stationary = false;

    public void set_color(Color newColor)
    {
        GetComponent<Renderer>().material.color = newColor;
    }

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        sphere_renderer = GetComponent<Renderer>();
        // line_renderer = gameObject.AddComponent<LineRenderer>();
        // line_renderer.startWidth = 1f;
        // line_renderer.endWidth = 1f;
        // line_renderer.useWorldSpace = true;


        v = Vector3.zero;
        r = transform.position;
        tmp_v = v;
        tmp_r = r;

        position_history = new List<Vector3>();
        body_idx = num_bodies++;
    }

    public void set_v(Vector3 new_v)
    {
        v = new_v;
        tmp_v = new_v;
    }

    public void set_stationary(bool state)
    {
        stationary = state;
    }

    public void set_m(double new_m)
    {
        m = new_m;
    }

    void FixedUpdate()
    {
        // position_history.Add(new Vector3(0.01f * (float) upd_cnt, 0, 0));
        // if (position_history.Count >= 50) {
        //     position_history.RemoveAt(0);
        // }

        // position_history.Add(r);
        // if (position_history.Count == 100) {
        //     for (int i = 0; i < position_history.Count; i++)
        //         Debug.Log(string.Format("{0}, ", position_history[i]));
        // }

        // List<Vector3> pos = new List<Vector3>();
        // pos.Add(new Vector3(0, 0, 0));
        // pos.Add(new Vector3(10, 10, 10));
        // line_renderer.SetPositions(pos.ToArray());

        // line_renderer.SetPositions(position_history.ToArray());
        
        Debug.Log(string.Format("<{2}> r: {0} // v: {1}", r, v, body_idx));
        transform.position = r;
        upd_cnt++;
    }
}
