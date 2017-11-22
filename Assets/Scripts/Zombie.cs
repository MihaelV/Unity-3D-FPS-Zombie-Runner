using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public GameObject[] zombi;

    // Use this for initialization
    void Start() {
        if (PlayerPrefsManager.GetDifficulty() == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                zombi[i].SetActive(true);
            }
        } else if (PlayerPrefsManager.GetDifficulty() == 3)
        {
            for (int i = 0; i < 4; i++)
            {
                zombi[i].SetActive(true);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
