using UnityEngine;
using System.Collections;

public class VisualizationCommands : MonoBehaviour
{
    public GameObject highlight;

    // Called by SpeechManager when the user says "Highlight Target"
    void OnTrack()
    {
        highlight.SetActive(true);
    }
}
