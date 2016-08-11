using UnityEngine;


class Measurement : MonoBehaviour
{
    public GameObject target { get; private set; }
    private Rigidbody rb;

    public Vector3 position;
    public Vector3 velocity;

    public Vector3 posSigma;
    public Vector3 velSigma;

    void Start()
    {
        rb = target.GetComponent<Rigidbody>();
    }

    void Update()
    {
        pseudoMeasurement();
    }

    // This method fills the role of getting the target measuremnt.
    // In the actual implementation, this will read measurements from the sensors.
    // Here, simply query the measuremetns of the target GameObject.
    void pseudoMeasurement()
    {
        // Measured position is the targets global position
        position = target.transform.position;

        // Pull the target's rigidbody to find velocity
        velocity = rb.velocity;

        // Since this measurement is essentially truth, set the uncertainties to zero.
        posSigma = Vector3.zero;
        velSigma = Vector3.zero;
    }
}

