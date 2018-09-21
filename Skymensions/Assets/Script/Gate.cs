using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gate : MonoBehaviour {
    public GameObject Player;

    private int playerCurrentHP;
    private int playerCurrentATK;
    private int playerCurrentArmor;



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

            Player.GetComponent<NewLvlStats>().NewLvl(playerCurrentArmor, playerCurrentATK, playerCurrentHP);




        }
    }
}
