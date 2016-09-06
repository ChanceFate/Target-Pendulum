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
	void Update ()
    {
        
        testSolver(ref points);
        
	}

    void testSolver(ref Transform[] pnt)
    {
        pnt[1].position = TrackManager.Instance.trackPosition;

        for (int i = 2; i < pnt.Length; i++)
            pnt[i].position = pnt[i - 1].position + separation;
    }
}
