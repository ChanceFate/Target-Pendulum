using UnityEngine;
using System.Collections;

public class TrailBehavior : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        this.transform.position = TrackManager.Instance.trackPosition;
    }
}