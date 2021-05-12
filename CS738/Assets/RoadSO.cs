using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class RoadSO : ScriptableObject
{
    public int src = 0, dest = 0, speedLimit = 0;
    public IntersectionSO srcNode, destNode;
    public float distance;
}
