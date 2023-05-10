using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float topConstraint = Screen.height;
    float bottomConstraint = Screen.height;
    float bufffer = 1.0f;
    Camera cam;
    float distanceZ;

    private void Start()
    {
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);
        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;
    }

    private void FixedUpdate()
    {
        if(transform.position.x < leftConstraint - bufffer)
        {
            transform.position = new Vector3(rightConstraint - 0.10f, transform.position.y, transform.position.z);

        }
        if (transform.position.x > rightConstraint - bufffer)
        {
            transform.position = new Vector3(rightConstraint , transform.position.y, transform.position.z);

        }

        if (transform.position.y < bottomConstraint - bufffer)
        {
            transform.position = new Vector3(transform.position.x, topConstraint + bufffer, transform.position.z);

        }

        if (transform.position.y > topConstraint + bufffer)
        {
            transform.position = new Vector3(transform.position.x, bottomConstraint - bufffer, transform.position.z);

        }

    }
}
