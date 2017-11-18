using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    public AudioClip zvuk;
    private AudioSource izvor;
    private bool called = false;

	// Use this for initialization
	void Start () {
        izvor = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("CallHeli") && !called)
        {
            called = true;
            izvor.clip = zvuk;
            izvor.Play();

        }

        
	}
}
