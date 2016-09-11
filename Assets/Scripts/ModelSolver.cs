using UnityEngine;
using System.Collections;

public class ModelSolver : MonoBehaviour
{
    public GameObject target;
    public float timeStep;

    Transform[] points;
    float length;
    float naturalFreq;

    // Use this for initialization
    void Start ()
    {
        // Form a transform array of solution points
        points = GetComponentsInChildren<Transform>();

        // To find the natural frequency of the pendulum, we need the length
        // of the rod and the acceleration due to gravity.
        // Determine the length of the rod by finding the distance to the
        // center of the target.
        length = target.transform.localPosition.magnitude;

        // Gravity is found from the physics engine
        float gravity = Physics.gravity.magnitude;

        // Combine to determine the natural frequency
        naturalFreq = Mathf.Sqrt(gravity / length);

        // Initialize z position of points to that of the target.
        for(int hh = 1; hh < points.Length; hh++)
           points[hh].localPosition = new Vector3(0,0,target.transform.localPosition.z);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        // To begin with, set the first element of the position array
        // to the position of the target.
        points[1].localPosition = target.transform.localPosition;

        // For the remaining points, determine the local position by solving
        // the equation of motion. First, build an array to store the extrapolated angles.
        float[] angles;
        angles = new float[points.Length - 2];

        // Use the MeasurementManager to pull in the the current target position and velocity
        Vector3 pos = MeasurementManager.Instance.measPos;
        Vector3 vel = MeasurementManager.Instance.measVel;

        // Determine the angular deflection and velocity from these values.
        float theta_0 = Mathf.Atan(pos.x / Mathf.Abs(pos.y));
        float omega_0 = Mathf.Sign(vel.x) * vel.magnitude / length;

        // Now, solve for each extrapolated omega at a slightly further time step.
        for (int ii = 0; ii < angles.Length; ii++)
            angles[ii] = rk4_pendulumSim(theta_0, omega_0, (ii+1) * timeStep);
        

        // Finally, convert each angle back to cartesian coordinates and assign to the
        // as the local position of points[]
        for (int jj = 0; jj < angles.Length; jj++)
        {
            float x_jj = length * Mathf.Sin(angles[jj]);
            float y_jj = -length * Mathf.Cos(angles[jj]);
            points[jj + 2].localPosition = new Vector3(x_jj, y_jj, target.transform.localPosition.z);
        }      
	}

    // Fourth order Runge-Kutta solution for a simple, frictionless plane pendulum.
    // Only returns the value of the angular deflection, since this is all we are 
    // interested in.
    float rk4_pendulumSim(float theta, float omega, float timeStep)
    {
        // Set up RK terms
        float k_1a = timeStep * omega;
        float k_1b = timeStep * motionEq_pendulum(theta);

        float k_2a = timeStep * (omega + k_1b / 2);
        float k_2b = timeStep * motionEq_pendulum(theta + k_1a / 2);

        float k_3a = timeStep * (omega + k_2b / 2);
        float k_3b = timeStep * motionEq_pendulum(theta + k_2a / 2);

        float k_4a = timeStep * (omega + k_3b);
        float k_4b = timeStep * motionEq_pendulum(theta + k_3a);

        // now compute return values of theta and omega
        return (theta + (k_1a + 2 * k_2a + 2 * k_3a + k_4a) / 6);      
    }

    float motionEq_pendulum(float theta)
    {
        return -Mathf.Pow(naturalFreq,2)*Mathf.Sin(theta);
    }
}
