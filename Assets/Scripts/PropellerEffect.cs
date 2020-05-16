using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerEffect : MonoBehaviour
{
    public float spinRate;
    public float maxSpinRate;
    public enum SpinAxis { X, Y, Z }
    public SpinAxis axis;
    public GameObject propObj;
    // Start is called before the first frame update
    void Start()
    {
        spinRate = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (axis == SpinAxis.X) propObj.transform.Rotate(Vector3.right * spinRate);
        else if (axis == SpinAxis.Y) propObj.transform.Rotate(Vector3.up * spinRate);
        else if (axis == SpinAxis.Z) propObj.transform.Rotate(Vector3.forward);

        if (Input.GetKey(KeyCode.W) && spinRate < maxSpinRate) spinRate += Time.deltaTime * 1.5f;
        else if (Input.GetKey(KeyCode.S) && spinRate > 0f) spinRate -= Time.deltaTime * 1.5f;
    }
}
