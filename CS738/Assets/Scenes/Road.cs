using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public int src, dest, speedLimit;
    public Intersection source, destination;
    public float distance;
    public LineRenderer LineRenderer;
    // Start is called before the first frame update

    public void set(Intersection _src, Intersection _dest)
    {
        source = _src;
        destination = _dest;
        distance = Vector2.Distance(source.transform.position, destination.transform.position);
        //LineRenderer = new LineRenderer();
        //LineRenderer = gameObject.AddComponent<LineRenderer>();
        LineRenderer = gameObject.GetComponent<LineRenderer>();
        LineRenderer.SetPosition(0, source.transform.position);
        LineRenderer.SetPosition(1, destination.transform.position);
    }


}
