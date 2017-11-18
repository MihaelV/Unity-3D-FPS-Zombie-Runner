using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform playerSpawnPoints; // roditelj spawn pointova
    public bool reSpawn = false;

    private Transform[] spawnPoints;
    private bool lastToggle = false;

	// Use this for initialization
	void Start () {
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
        print(spawnPoints.Length);
	}
	
	// Update is called once per frame
	void Update () {
		if(lastToggle != reSpawn) // obadvoje false na početku
        {
            ReSpawn();
            reSpawn = false;
        }
        else
        {
            lastToggle = reSpawn;
        }
	}



    private void ReSpawn()
    {
        int i = Random.Range(1, spawnPoints.Length); // počinjemo od 1 zato jer je element u arrayu na indexu 0 parent, childreni pocinju od 1 
        transform.position = spawnPoints[i].transform.position;  // postavljamo trenutni game object a to je Player na random poziciju tj jednu od 3 random izabranih spawn pointova
    }
}
