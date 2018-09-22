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

    private static int currHP = 10;
    private static int currATk = 2;
    private static int currAr = 0;
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
        if (enemy != null)
        {
            enemy.GetComponent<KI>().speed = 1.1f;
            Debug.Log(enemy.GetComponent<KI>().speed);
        }
        Player.GetComponent<Movement>().speed = 0.3f;
        escMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        enemy = GameObject.Find("Gegner");
        //Player = GameObject.Find("Player");
        if(enemy != null) { 
        enemy.GetComponent<KI>().speed = 0.0f;
        Debug.Log(enemy.GetComponent<KI>().speed);
        }
        Player.GetComponent<Movement>().speed = 0.0f;
        escMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
       
    }

    public void LoadMenu()
    {
        enemy = GameObject.Find("Gegner");
        if (enemy != null)
        {
            enemy.GetComponent<KI>().speed = 1.1f;
        }
        Player.GetComponent<Movement>().speed = 0.3f;
        Player.GetComponent<PlayerStats>().resetStats(currAr, currATk, currHP);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
       
    }

    public void QuitGame()
    {
        enemy = GameObject.Find("Gegner");
        enemy.GetComponent<KI>().speed = 1.1f;
    
    Player.GetComponent<Movement>().speed = 0.3f;
        Player.GetComponent<PlayerStats>().resetStats(currAr, currATk, currHP);
        Debug.Log("Quit Game");
        Application.Quit();
     
    }
}
