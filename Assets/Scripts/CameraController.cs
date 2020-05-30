using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public bool pilotView;
    public Transform plane;
    public FollowTarget follow;
    public PilotView pilot;
    public GameObject followUI, pilotUI;

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
            followUI.SetActive(false);
            pilotUI.SetActive(true);
        }
        else
        {
            follow.enabled = true;
            pilot.enabled = false;
            transform.parent = null;
            followUI.SetActive(true);
            pilotUI.SetActive(false);
        }
    }
}
