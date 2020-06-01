using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text speedIndicator_Text;
    public Image speedIndicator_Image;
    public Text thrustIndicator_Text;
    public Image thrustIndicator_Image;
    public GameObject compass;

    public PlaneControl planeControl;
    public Rigidbody planeRB;
    public Transform planeObj;
    public float xRotCompass;
    float currentHeading;
    RectTransform compassRect;

    void Start()
    {
        if(compass != null)
        {
            compassRect = compass.GetComponent<RectTransform>();
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        SpeedUpdate();
        ThrustUpdate();
        CompassHandler();
    }

    void SpeedUpdate()
    {
        if (speedIndicator_Text != null) speedIndicator_Text.text = planeRB.velocity.magnitude.ToString("f2");
        if (speedIndicator_Image != null) speedIndicator_Image.fillAmount = planeRB.velocity.magnitude / planeControl.maxThrust;
    }

    void ThrustUpdate()
    {
        if (thrustIndicator_Text != null) thrustIndicator_Text.text = planeControl.thrust.ToString("f2");
        if (thrustIndicator_Image != null) thrustIndicator_Image.fillAmount = planeControl.thrust / planeControl.maxThrust;
    }

    void CompassHandler()
    {
        if (compass != null)
        {
            currentHeading = planeObj.eulerAngles.y;
            Vector3 compassRot = new Vector3(xRotCompass, 0f, currentHeading);
            compassRect.transform.eulerAngles = compassRot;
        }
    }
}
