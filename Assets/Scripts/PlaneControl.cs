using UnityEngine.UI;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    public float thrust;
    public float takeOffSpeed;
    public float turnSpeed;
    public float climbSpeed;
    public float yawSpeed;
    public float maxTurnSpeed;
    public float maxThrust;
    public float acceleration;

    Rigidbody planeRb;
    Vector3 forwardDir;
    Text airSpeed;

    void Start()
    {
        planeRb = GetComponent<Rigidbody>();
        airSpeed = GameObject.Find("Speed").GetComponent<Text>();

        planeRb.maxAngularVelocity = maxTurnSpeed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && thrust < maxThrust) thrust += Time.deltaTime * acceleration;
        else if (Input.GetKey(KeyCode.S) && thrust > 0f) thrust -= Time.deltaTime * acceleration;
        UIUpdate();
    }

    void FixedUpdate()
    {
        ApplyThrust();

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Yaw");
        Movement(h, v, y);
    }

    void ApplyThrust()
    {
        forwardDir = transform.TransformDirection(Vector3.forward);
        planeRb.AddForce(forwardDir * thrust, ForceMode.Acceleration);
        if (planeRb.velocity.magnitude >= takeOffSpeed) planeRb.useGravity = false;
        else planeRb.useGravity = true;
    }

    void Movement(float h, float v, float y)
    {
        if (!planeRb.useGravity)
        {
            planeRb.AddRelativeTorque(Vector3.back * turnSpeed * h, ForceMode.Force);
            planeRb.AddRelativeTorque(Vector3.right * climbSpeed * v, ForceMode.Force);
        }
        planeRb.AddRelativeTorque(Vector3.up * yawSpeed * y, ForceMode.Force);
    }

    void UIUpdate()
    {
        airSpeed.text = planeRb.velocity.magnitude.ToString("f2");
    }
}
