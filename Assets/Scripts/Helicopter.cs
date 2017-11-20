using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helicopter : MonoBehaviour {


    private bool called = false;
    private Rigidbody rigidbodyy;
    private Vector3 landingPosition;
    private Player player;

    public Text myText;



	// Use this for initialization
	void Start () {        
        rigidbodyy = GetComponent<Rigidbody>();
        player = GameObject.FindObjectOfType<Player>();
	}

    private void Update()
    {
        if(transform.position.z >= -100f)
        {
            transform.position = player.FlarePosition();
            /*transform.position = landingPosition;*/ // u ovaj vektor moramo prenijeti kordinate kad postavimo flare
        }
    }

    public void Set(Vector3 poss)
    {
        landingPosition = poss;
    }

    void OnDispatchHelicopter()
    {                    
        rigidbodyy.velocity = new Vector3(0, 0, 50f); //dajemo helikopteru brzinu od 50m po sekudni
        called = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            myText.text = "Load new scene!";
        }
    }
}
