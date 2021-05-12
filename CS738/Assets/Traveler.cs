using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveler : MonoBehaviour
{
    public float startTime, tripLength, timeElapsed;
    public List<IntersectionSO> path;
    public float p;
    public bool go;
    public float speed = .05f;
    int i = 0; int j = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(go)
        {
            if (transform.position == path[j].pos)
            {
                i++; j++; p = 0;
            }

            
            //float progress = (Time.time - startTime) * speed;
            p += speed;
            //move towards target
            transform.position = Vector3.MoveTowards(path[i].pos, path[j].pos, (p/Vector3.Distance(path[i].pos, path[j].pos)));

            //Rotate towards target
            Vector3 targetDirection = path[j].pos - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + 5));
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5 * Time.deltaTime);
            print(path[i].pos + " > " + path[j].pos);
            print(i + " > " + j);
        }
    }
}
