using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string MASTER_DIFF_KEY = "difficulty";


    public static void SetMasterVolume(float volume)
    {
        if(volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }else
        {
            Debug.LogError("Master volume out of Range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float diff)
    {
        if (diff >= 0f && diff <= 3f)
        {
            PlayerPrefs.SetFloat(MASTER_DIFF_KEY, diff);
        }
        else
        {
            Debug.LogError("Difficulty out of Range");
        }
    }


    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(MASTER_DIFF_KEY);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
