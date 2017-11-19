using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daycycle : MonoBehaviour {

    [Tooltip("Number of minutes pre second that pass, try 60")]
    public float minutesPerSeconds;

  
	
	// Update is called once per frame
	void Update () {
        float angleThisFrame = Time.deltaTime / 360 * minutesPerSeconds;
        transform.RotateAround(transform.position, Vector3.forward, angleThisFrame);
	}
}
