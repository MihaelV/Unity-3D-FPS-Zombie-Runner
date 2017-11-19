using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {


    private bool called = false;
    private Rigidbody rigidbodyy;


	// Use this for initialization
	void Start () {        
        rigidbodyy = GetComponent<Rigidbody>();
	}

    void OnDispatchHelicopter()
    {                    
        rigidbodyy.velocity = new Vector3(0, 0, 50f); //dajemo helikopteru brzinu od 50m po sekudni
        called = true;
    }
}
