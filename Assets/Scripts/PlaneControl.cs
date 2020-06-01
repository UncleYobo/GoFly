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
    public float stallSpeed;

    float angleOfAttack;
    float diveMultiplier;
    float maxDiveMultiplier = 1.5f;
    float minDiveMultiplier = 0.5f;

    Rigidbody planeRb;
    Vector3 forwardDir;

    void Start()
    {
        planeRb = GetComponent<Rigidbody>();

        planeRb.maxAngularVelocity = maxTurnSpeed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && thrust < maxThrust) thrust += Time.deltaTime * acceleration;
        else if (Input.GetKey(KeyCode.S) && thrust > 0f) thrust -= Time.deltaTime * acceleration;
    }

    void FixedUpdate()
    {
        DiveCalculator();
        ApplyThrust();

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Yaw");
        Movement(h, v, y);
    }

    void ApplyThrust()
    {
        forwardDir = transform.TransformDirection(Vector3.forward);
        planeRb.AddForce(forwardDir * thrust * diveMultiplier, ForceMode.Acceleration);
        if (planeRb.velocity.magnitude >= takeOffSpeed) planeRb.useGravity = false;
        else planeRb.useGravity = true;
    }

    void Movement(float h, float v, float y)
    {
        if (planeRb.velocity.magnitude >= stallSpeed)
        {
            planeRb.AddRelativeTorque(Vector3.back * turnSpeed * h, ForceMode.Force);
            planeRb.AddRelativeTorque(Vector3.right * climbSpeed * v, ForceMode.Force);
        }
        planeRb.AddRelativeTorque(Vector3.up * yawSpeed * y, ForceMode.Force);
    }

    void DiveCalculator()
    {
        angleOfAttack = transform.eulerAngles.x;
        if(angleOfAttack >= 10f && angleOfAttack <= 170f)
        {
            diveMultiplier = Mathf.MoveTowards(diveMultiplier, maxDiveMultiplier, Time.deltaTime);
        } else if(angleOfAttack >= 225f && angleOfAttack <= 315f)
        {
            diveMultiplier = Mathf.MoveTowards(diveMultiplier, minDiveMultiplier, Time.deltaTime);
        } else
        {
            diveMultiplier = Mathf.MoveTowards(diveMultiplier, 1f, Time.deltaTime);
        }
    }
}
