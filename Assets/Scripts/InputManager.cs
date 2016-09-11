using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{

    bool running = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKeyDown)
            if (!running)
            {
                this.BroadcastMessage("OnDrop");
                this.BroadcastMessage("OnTrack");
                this.BroadcastMessage("OnTrajectory");
                running = true;
            }
            else
            {
                this.BroadcastMessage("OnReset");
                running = false;
            }
	
	}
}
