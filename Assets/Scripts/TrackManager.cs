using UnityEngine;
using System.Collections;

public class TrackManager : MonoBehaviour
{
    public static TrackManager Instance { get; private set; }

    // Vectors for the track state
    public Vector3 trackPosition { get; private set; }
    public Vector3 trackVelocity { get; private set; }

    // State uncertainties
    public Vector3 trackPosSigma { get; private set; }
    public Vector3 trackVelSigma { get; private set; }

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        truthTracker();
    }


    // This method fills the role of tracking the target,
    // merging the track state with the most recent measurement.
    // Here, since the measurement is truth, simply update the state
    // with the measurement alone.
    void truthTracker()
    {
        trackPosition = MeasurementManager.Instance.measPos;
        trackVelocity = MeasurementManager.Instance.measVel;
        trackPosSigma = MeasurementManager.Instance.measPosSigma;
        trackVelSigma = MeasurementManager.Instance.measVelSigma;
    }
}

