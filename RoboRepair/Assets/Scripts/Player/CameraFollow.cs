using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float dampening = 0.8f;
    public Transform target;


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = (transform.position * dampening) + (1 - dampening) * target.position;
        transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
    }
}
