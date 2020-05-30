using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerEffect : MonoBehaviour
{
    public float idleSpeed, runningSpeed;
    public float transitionSpeed;
    public enum SpinAxis { X, Y, Z }
    public SpinAxis axis;
    public enum SpinState { Stopped, Idle, Running }
    public SpinState currentState;
    public GameObject propObj;

    private PlaneControl planeControl;
    private float spinRate;
    // Start is called before the first frame update
    void Start()
    {
        spinRate = 0f;
        planeControl = GetComponent<PlaneControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Spinner();
        SpinStateHandler();
        SpinRateLerp();
    }

    void SpinRateLerp()
    {
        if (currentState == SpinState.Stopped) spinRate = Mathf.Lerp(spinRate, 0f, Time.deltaTime * transitionSpeed);
        else if (currentState == SpinState.Idle) spinRate = Mathf.Lerp(spinRate, idleSpeed, Time.deltaTime * transitionSpeed);
        else spinRate = Mathf.Lerp(spinRate, runningSpeed, Time.deltaTime * transitionSpeed);
    }

    void SpinStateHandler()
    {
        if (planeControl.thrust <= 0.1) currentState = SpinState.Stopped;
        else if (planeControl.thrust > 0.1 && planeControl.thrust < planeControl.takeOffSpeed / 3f) currentState = SpinState.Idle;
        else currentState = SpinState.Running;
    }

    void Spinner()
    {
        if (axis == SpinAxis.X) propObj.transform.Rotate(Vector3.right * spinRate);
        else if (axis == SpinAxis.Y) propObj.transform.Rotate(Vector3.up * spinRate);
        else if (axis == SpinAxis.Z) propObj.transform.Rotate(Vector3.forward * spinRate);
    }
}
