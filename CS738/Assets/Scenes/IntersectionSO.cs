using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntersectionSO : ScriptableObject
{
    public float x, y;
    public int num;
    public bool active;

    public float igCost, ihCost = 0;
    public float fCost = 0;
    //public float fCost { get { return igCost + ihCost; } };

    public IntersectionSO parent;
    public Vector3 pos;
}
