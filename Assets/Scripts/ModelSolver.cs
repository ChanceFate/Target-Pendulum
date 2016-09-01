using UnityEngine;
using System.Collections;

public class ModelSolver : MonoBehaviour
{
    public Vector3 separation;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Form a transform array of solution points
        Transform[] points = GetComponentsInChildren<Transform>();

        testSolver(ref points);
        
	}

    void testSolver(ref Transform[] pnt)
    {
        pnt[1].position = TrackManager.Instance.trackPosition;

        for (int i = 2; i < pnt.Length; i++)
            pnt[i].position = pnt[i - 1].position + separation;
    }
}
