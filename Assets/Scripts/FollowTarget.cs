using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float smoothTime;
    public float distance, height;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 targetPos = target.TransformPoint(new Vector3(0f, height, distance));
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothTime);
        transform.LookAt(target);
    }
}
