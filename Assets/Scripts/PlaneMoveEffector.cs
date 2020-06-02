using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMoveEffector : MonoBehaviour
{
    public GameObject[] leftAileron;
    public GameObject[] rightAileron;
    public GameObject[] elevator;
    public GameObject[] rudder;
    public float moveSpeed;

    private float maxAngle = 30f;
    Vector3 targetVecLeft = Vector3.zero;
    Vector3 targetVecRight = Vector3.zero;
    Vector3 targetVecElev = Vector3.zero;
    public Vector3 targetVecRud = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Yaw");
        Turning(h, v, y);
    }

    void Turning(float h, float v, float y)
    {
        targetVecLeft.x = maxAngle * -h;
        targetVecRight.x = maxAngle * h;
        targetVecElev.x = maxAngle * -v;
        targetVecRud.z = maxAngle * -y;

        foreach (GameObject go in leftAileron)
        {
            go.transform.localRotation = Quaternion.Euler(targetVecLeft);
        }
        foreach (GameObject go in rightAileron)
        {
            go.transform.localRotation = Quaternion.Euler(targetVecRight);
        }
        foreach (GameObject go in elevator)
        {
            go.transform.localRotation = Quaternion.Euler(targetVecElev);
        }
        foreach (GameObject go in rudder)
        {
            go.transform.localRotation = Quaternion.Euler(targetVecRud);
        }
    }
}
