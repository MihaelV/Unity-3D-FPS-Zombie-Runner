using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGame : MonoBehaviour {

    public Text proba;

    private void Start()
    {
        
    }


    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            proba.text = "You Win";
            print("B");
        }
        print("B");
    }
}
