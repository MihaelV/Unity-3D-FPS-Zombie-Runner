using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] songs;

    private AudioSource SongPlayer;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        SongPlayer = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        SongPlayer.volume = PlayerPrefsManager.GetMasterVolume();
	}

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update () {
		
	}

    public void ChangeVolume(float volume)
    {
        SongPlayer.volume = volume;
    }


    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMuisc = songs[level];
        if (thisLevelMuisc)
        {
            SongPlayer.clip = thisLevelMuisc;
            SongPlayer.loop = true;
            SongPlayer.Play();
        }
    }
}
