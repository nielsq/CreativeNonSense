using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour {

    // Use this for initialization
    public static bool GameIsPaused = false;

    public GameObject escMenuUI;

    public GameObject enemy;
    public GameObject Player;
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
	}

   public void Resume()
    {
        enemy = GameObject.Find("Gegner");
        //Player = GameObject.Find("Player");
        enemy.GetComponent<KI>().speed = 1.1f;
        Debug.Log(enemy.GetComponent<KI>().speed);

        Player.GetComponent<Movement>().speed = 0.3f;
        escMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        enemy = GameObject.Find("Gegner");
        //Player = GameObject.Find("Player");
        enemy.GetComponent<KI>().speed = 0.0f;
        Debug.Log(enemy.GetComponent<KI>().speed);

        Player.GetComponent<Movement>().speed = 0.0f;
        escMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        enemy = GameObject.Find("Gegner");
        enemy.GetComponent<KI>().speed = 1.1f;
        Player.GetComponent<Movement>().speed = 0.3f;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        enemy = GameObject.Find("Gegner");
        enemy.GetComponent<KI>().speed = 1.1f;
        Player.GetComponent<Movement>().speed = 0.3f;
        Debug.Log("Quit Game");
        Application.Quit();
     
    }
}
