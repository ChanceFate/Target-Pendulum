using UnityEngine;

public class TargetCommands : MonoBehaviour
{
    GameObject support; 
    HingeJoint joint; 

    Vector3 originalPosition;
    Quaternion originalOrientation;

    // Use this for initialization
    void Start()
    {
        // Grab the original local position and orientation of the target when the app starts.
        originalPosition = this.transform.parent.localPosition;
        originalOrientation = this.transform.parent.localRotation;

        // Initialize support and hinge
        support = GameObject.Find("Support");
        joint = support.GetComponent<HingeJoint>();
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {

        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();

            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rigidbody.angularDrag = 0;

            joint.connectedBody = rigidbody;
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

        // Put the target and rod back in their original local position and orientation.
        this.transform.parent.localPosition = originalPosition;
        this.transform.parent.localRotation = originalOrientation;
    }

    // Called by SpeechManager when the user says the "Drop" command
    void OnDrop()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }
}