using UnityEngine;
using System.Collections;


class MeasurementManager : MonoBehaviour
{
    public static MeasurementManager Instance { get; private set; }

    public GameObject target;
    private Rigidbody rb;

    public Vector3 measPos { get; private set; }
    public Vector3 measVel { get; private set; }

    public Vector3 measPosSigma { get; private set; }
    public Vector3 measVelSigma { get; private set; }

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        trueMeasurement();
    }

    // This method fills the role of getting the target measuremnt.
    // In the actual implementation, this will read measurements from the sensors.
    // Here, simply query the measuremetns of the target GameObject.
    void trueMeasurement()
    {
        // Measured position is the targets global position
        measPos = target.transform.position;

        // If the target has a rigid body, use it to find velocity
        if (target.GetComponent<Rigidbody>())
        {
            rb = target.GetComponent<Rigidbody>();
            measVel = rb.velocity;
        }
        else
            measVel = Vector3.zero;

        // Since this measurement is essentially truth, set the uncertainties to zero.
        measPosSigma = Vector3.zero;
        measVelSigma = Vector3.zero;
    }
}

