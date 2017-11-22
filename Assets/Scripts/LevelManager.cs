using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoad;

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }


    public void Exit()
    {
        Application.Quit();
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("NextLevel", autoLoad); // učitava funkciju NextLevel nakon autoLoad sekundi
        }
    }

}
