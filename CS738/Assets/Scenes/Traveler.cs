using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveler : MonoBehaviour
{
    public float startTime, tripLength, timeElapsed;
    public List<IntersectionSO> path;
    public float p;
    public bool go;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(go)
        {
            float progress = (Time.time - startTime) * 1f;
            p = progress;
            Vector3.MoveTowards(path[0].pos, path[1].pos, Time.deltaTime * speed);

        }
    }
}
