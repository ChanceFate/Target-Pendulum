using UnityEngine;
using System.Collections;

public class VisualizationCommands : MonoBehaviour
{
    public GameObject highlight;
    public GameObject trajectory;

    // Called by SpeechManager when the user says "Track Target"
    void OnTrack()
    {
        highlight.SetActive(true);
    }

    // Called by SpeechManager when the user says "Trajectory On"
    void OnTrajectory()
    {
        trajectory.SetActive(true);
    }
}
