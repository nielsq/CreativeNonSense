using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gate : MonoBehaviour {
    public GameObject Player;

    private static int currHP;
    private static int currATk;
    private static int currAr;

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
            currAr = Player.GetComponent<PlayerStats>().currArmor();
            currATk = Player.GetComponent<PlayerStats>().currAttack();
            currHP = Player.GetComponent<PlayerStats>().currHP();

            Player.GetComponent<PlayerStats>().newStats(currAr, currATk, currHP);




        }
    }
}
