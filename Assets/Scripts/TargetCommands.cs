using UnityEngine;

public class TargetCommands : MonoBehaviour
{
    GameObject support; 
    HingeJoint hinge; 

    Vector3 originalPosition;
    Quaternion originalOrientation;

    // Use this for initialization
    void Start()
    {
        // Grab the original local position and orientation of the target when the app starts.
        originalPosition = this.transform.localPosition;
        originalOrientation = this.transform.localRotation;

        // Initialize support and hinge
        support = GameObject.Find("Support");
        hinge = support.GetComponent<HingeJoint>();
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // If the target has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rigidbody.angularDrag = 0;

            // connect target to hinge.
            hinge.connectedBody = rigidbody;
        }
    }

    // Called by SpeechManager when the user says the "Reset world" command,
    // or when the pendulum is being placed in the environment.
    void OnReset()
    {
        // If the target has a Rigidbody component, remove it to disable physics.
        var rigidbody = this.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            DestroyImmediate(rigidbody);
        }

        // Put the target back into its original local position and orientation.
        this.transform.localPosition = originalPosition;
        this.transform.localRotation = originalOrientation;
    }

    // Called by SpeechManager when the user says the "Drop" command
    void OnDrop()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }
}