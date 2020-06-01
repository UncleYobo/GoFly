using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneCrashHandler : MonoBehaviour
{
    public Rigidbody planeRB;
    public float crashThreshold;
    public float velocity;
    public GameObject crashObj;
    public GameObject cameraObj;

    // Start is called before the first frame update
    void Start()
    {
        planeRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        velocity = planeRB.velocity.magnitude;
    }

    void OnCollisionEnter(Collision col)
    {
        if (planeRB.velocity.magnitude >= crashThreshold) KillPlane();
    }

    void KillPlane()
    {
        Debug.Log("Plane Crashed");
        Instantiate(crashObj, transform.position, Quaternion.identity);
        Destroy(cameraObj);
        Destroy(this.gameObject);
    }
}
