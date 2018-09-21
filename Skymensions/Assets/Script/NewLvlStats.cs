using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLvlStats : MonoBehaviour {
    private Scene scene;

    public GameObject Player;

   
    // Use this for initialization
    public void NewLvl (int playerCurrentArmor, int playerCurrentATK ,int playerCurrentHP) {
        scene = SceneManager.GetActiveScene();

        int currAr = playerCurrentArmor;
        int currATk = playerCurrentATK;
        int currHP = playerCurrentHP;
        Application.LoadLevel(scene.name);
        Debug.Log("Jetzt die Stats anpassen");
        Player = GameObject.Find("spieler");
        Debug.Log("Jetzt die Stats anpassen:" + currAr + currATk + currHP);
        Debug.Log(Player.GetComponent<PlayerStats>().abstand);
        Player.GetComponent<PlayerStats>().newStats(currAr, currATk, currHP);
        

    }

    // Update is called once per frame

}
