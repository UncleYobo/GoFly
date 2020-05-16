using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotView : MonoBehaviour
{
    public Transform pilotSeat;
    public Transform forwardPoint;
    public float sensitivity;
    public Vector3 lookVec;
    public float resetWaitTime;
    public float resetSmooth;

    private float timer = 0f;
    private float maxUpperLimit = -75f;
    private float maxLowerLimit = 75f;
    private bool isLooking = false;
    private bool viewReset = true;

    void Update()
    {
        transform.position = pilotSeat.position;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            lookVec = transform.localEulerAngles;
            timer = 0f;
            isLooking = true;
            viewReset = false;
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            TurnHead(x, y);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && isLooking)
        {
            Cursor.lockState = CursorLockMode.Locked;
            isLooking = false;
        }
            
        if (!isLooking && !viewReset)
        {
            timer += Time.deltaTime;
            if (timer >= resetWaitTime)
            {
                viewReset = true;
            }
        }

        if (viewReset)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, pilotSeat.rotation, Time.deltaTime * resetSmooth);
        }
    }

    void TurnHead(float x, float y)
    {
        lookVec.x -= y * sensitivity;
        lookVec.y += x * sensitivity;

        transform.localEulerAngles = lookVec;
    }
}
