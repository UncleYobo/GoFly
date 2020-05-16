using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool pilotView;
    public Transform plane;
    public FollowTarget follow;
    public PilotView pilot;

    void Start()
    {
        CycleView();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) CycleView();
    }

    void CycleView()
    {
        pilotView = !pilotView;
        if (pilotView)
        {
            follow.enabled = false;
            pilot.enabled = true;
            transform.SetParent(plane);
        }
        else
        {
            follow.enabled = true;
            pilot.enabled = false;
            transform.parent = null;
        }
    }
}
