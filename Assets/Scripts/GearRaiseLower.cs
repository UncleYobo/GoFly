using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRaiseLower : MonoBehaviour
{
    public Vector3 upRot, downRot;
    public bool isDown;
    public GameObject gearObj;
    public float moveSpeed;

    Vector3 targetVec;
    Vector3 currentVec;

    // Start is called before the first frame update
    void Start()
    {
        gearObj = this.gameObject;
        isDown = true;
        targetVec = downRot;
        currentVec = targetVec;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G)) GearSwitch();

        GearHandler();
    }

    void GearHandler()
    {
        currentVec = Vector3.MoveTowards(currentVec, targetVec, Time.deltaTime * moveSpeed);

        gearObj.transform.localRotation = Quaternion.Euler(currentVec);
    }

    void GearSwitch()
    {
        isDown = !isDown;

        if (isDown) targetVec = downRot;
        else targetVec = upRot;
    }
}
