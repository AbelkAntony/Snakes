using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float leftConstraint;
    float rightConstraint;
    float topConstraint;
    float bottomConstraint;
    float buffer = 1.0f;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f)).x;
        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).y;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, 0.0f)).y;
    }

    private void FixedUpdate()
    {
        if (transform.position.x < leftConstraint) 
        {
            transform.position = new Vector3(rightConstraint - 2f, transform.position.y , 0.0f);

        }
        if (transform.position.x > rightConstraint )
        {
            transform.position = new Vector3(leftConstraint  + 2f, transform.position.y , 0.0f);

        }

        if (transform.position.y < bottomConstraint - buffer)
        {
            transform.position = new Vector3(transform.position.x, topConstraint , 0.0f);

        }

        if (transform.position.y > topConstraint + buffer)
        {
            transform.position = new Vector3(transform.position.x, bottomConstraint , 0.0f);

        }

    }
}
