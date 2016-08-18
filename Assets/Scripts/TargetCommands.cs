using UnityEngine;

public class TargetCommands : MonoBehaviour
{
    public GameObject support;
    public GameObject rod;
    public GameObject target;
    
    FixedJoint fixJoint;  
    HingeJoint hinge; 

    Vector3 originalPosition;
    Quaternion originalOrientation;

    // Use this for initialization
    void Start()
    {
        // Grab the original local position and orientation of the target when the app starts.
        originalPosition = this.transform.localPosition;
        originalOrientation = this.transform.localRotation;

        // Initialize hing joint
        hinge = support.GetComponent<HingeJoint>();
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {

        // if the target doesn't have a rigid body, add one for the target and rod
        if (!target.GetComponent<Rigidbody>())
        {
            // add and initialize rigid bodies for swing children
            var rigidRod = initRigidbody(rod);
            var rigidTgt = initRigidbody(target);

            // add fixed joint to rod and connect target
            fixJoint = rod.AddComponent<FixedJoint>();
            fixJoint.connectedBody = rigidTgt;

            // connect rod to support hinge joint
            hinge.connectedBody = rigidRod;
        }
            
    }

    // Called by SpeechManager when the user says the "Reset world" command,
    // or when the pendulum is being placed in the environment.
    void OnReset()
    {
        // If the target has a Rigidbody component, remove it to disable physics.
        if (target.GetComponent<Rigidbody>() != null)
        {
            DestroyImmediate(target.GetComponent<Rigidbody>());
            DestroyImmediate(rod.GetComponent<Rigidbody>());
        }

        // Put the target and rod back in their original local position and orientation.
        this.transform.localPosition = originalPosition;
        this.transform.localRotation = originalOrientation;
    }

    // Called by SpeechManager when the user says the "Drop" command
    void OnDrop()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }

    // Called to initialize rigid bodies for the children objects
    Rigidbody initRigidbody(GameObject gObject)
    {
        var rigidbody = gObject.gameObject.AddComponent<Rigidbody>();

        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.angularDrag = 0;

        return rigidbody;
    }
}