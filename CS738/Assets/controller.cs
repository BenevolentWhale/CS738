using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controller : MonoBehaviour
{
    Vector3 movementInput;
    public float movementSpeed, zoomInput, zoomSpeed;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += movementInput * movementSpeed * Time.deltaTime;

        zoomInput = Input.GetAxis("Zoom");
        if (zoomInput != 0)
        {
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView += zoomInput * zoomSpeed * Time.deltaTime, 30, 90);
        }
    }
}
