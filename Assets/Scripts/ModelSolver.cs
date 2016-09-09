using UnityEngine;
using System.Collections;

public class ModelSolver : MonoBehaviour
{
    public Vector3 separation;

    Transform[] points;

    // Use this for initialization
    void Start ()
    {
        // Form a transform array of solution points
        points = GetComponentsInChildren<Transform>();

        testSolver(ref points);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
        testSolver(ref points);
        
	}

    void testSolver(ref Transform[] pnt)
    {
        pnt[1].localPosition = TrackManager.Instance.trackPosition;

        for (int i = 2; i < pnt.Length; i++)
            pnt[i].localPosition = pnt[i - 1].localPosition + separation;
    }

    // Fourth order Runge-Kutta solution for a simple, frictionless plane pendulum.
    void rk4_pendulumSim(float theta, float omega, float timeStep)
    {
        // system physical parameters
        float gravity = Physics.gravity.magnitude;

        //float length = 
        //float naturalFreq = Mathf.Sqrt()

        // Set up RK terms
        float k_1a = timeStep * omega;
        //float k_1b = timeStep * 
        //float k_2a = timeStep * (omega + )
    }
}
