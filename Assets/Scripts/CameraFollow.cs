using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The object the camera is following.
    public Transform target;
    // Determines how long it takes to dampen.
    public float smoothTime;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame.
    void Update()
    {
        // Target position should retain the cameras y and z positions.
        var targetPosition = new Vector3(target.position.x, 
            transform.position.y, 
            transform.position.z);

        // Smoothly move to targetPosition.
        transform.position = Vector3.SmoothDamp(transform.position,
            targetPosition,
            ref velocity,
            smoothTime);
    }
}