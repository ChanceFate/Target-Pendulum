using UnityEngine;
using System.Collections;

public class HighlightBehavior : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // place highlight at tracked target location
        this.transform.position = TrackManager.Instance.trackPosition;

        // take the dot product of the target velocity and user gaze to determine range rate
        var targetVelocity = TrackManager.Instance.trackVelocity.normalized;
        var gazeDirection = Camera.main.transform.forward;
        var align = Vector3.Dot(targetVelocity, gazeDirection);

        // choose the highlight color based on the range rate
        Color color = Color.black;
        color.r = 1 - ((align >= 0) ? align : 0);
        color.g = 1 - ((align >= 0) ? align / 2 : -align);
        color.b = 0 + ((align >= 0) ? align : 0);

        // Change light to match chosen color
        Light light = this.gameObject.GetComponent<Light>();
        light.color = color;
    }
}
