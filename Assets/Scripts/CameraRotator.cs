using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float orbitSpeed;
    public GameObject lookTarget;

    void Update()
    {
        transform.RotateAround(lookTarget.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
        transform.LookAt(lookTarget.transform);
    }
}
