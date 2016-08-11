using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public static TrackManager Instance { get; private set; }

    // Represent the object which is being tracked.
    // public GameObject TrackedObject { get; private set; }

    // Vectors for the track state
    public Vector3 trackPosition;
    public Vector3 trackVelocity;

    // State uncertainties
    public Vector3 trackPosSigma;
    public Vector3 trackVelSigma;

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Collect a measurement from the target.
    }
}

