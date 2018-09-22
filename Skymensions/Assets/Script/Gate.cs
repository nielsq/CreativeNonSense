using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gate : MonoBehaviour {
    public GameObject Player;

    private int playerCurrentHP;
    private int playerCurrentATK;
    private int playerCurrentArmor;

    private Scene scene;

   


    void Start()
    {
       
    }

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("New Level!!");
            Player = GameObject.FindGameObjectWithTag("Player");
            playerCurrentArmor = Player.GetComponent<PlayerStats>().currArmor();
            playerCurrentATK = Player.GetComponent<PlayerStats>().currAttack();
            playerCurrentHP = Player.GetComponent<PlayerStats>().currHP();

            Player.GetComponent<PlayerStats>().newStats(currAr, currATk, currHP);




        }
    }
}
