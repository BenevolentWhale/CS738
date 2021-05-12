using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    // Start is called before the first frame update
    public int num;
    public float xCo, yCo;
    // Start is called before the first frame update

    void Start()
    {
        xCo = this.transform.position.x;
        yCo = this.transform.position.y;
    }

}
