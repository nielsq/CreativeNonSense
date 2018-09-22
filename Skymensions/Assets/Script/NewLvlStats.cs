using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLvlStats : MonoBehaviour {
    private Scene scene;

    public GameObject Player;
    private static int currAr;
    private static int currATk;
    private static int currHP;

    // Use this for initialization
    public void NewLvl (int playerCurrentArmor, int playerCurrentATK ,int playerCurrentHP) {
        scene = SceneManager.GetActiveScene();
        currAr = playerCurrentArmor;
        currATk = playerCurrentATK;
        currHP = playerCurrentHP;
        Application.LoadLevel(scene.name);
        Debug.Log("Jetzt die Stats anpassen");
        Player = GameObject.Find("spieler");
        Player.GetComponent<PlayerStats>().newStats(currAr, currATk, currHP);
        

    }

    // Update is called once per frame

}
