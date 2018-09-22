﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    private Scene scene;
    public GameObject enemy;
    public GameObject Gate;
    private GameObject spieler;
    private GameObject spike;
    public int abstand = 4;
    public EnemyStats es;

    bool attack = false;
    //Anfangswerte
    private int playerBaseHP = 10;
    private int playerBaseATK = 2;
    private int playerBaseArmor = 0;
    //Aktualisierte Werte
    private int playerCurrentHP;
    private int playerMaxHP;
    public int playerCurrentATK;
    private int playerCurrentArmor;
    //Fuer das UI
    public Text hpText;
    public Text atkText;
    public Text armorText;

    private float posYGate = 7.94f;


    // Use this for initialization
    void Start () {

        scene = SceneManager.GetActiveScene();

        playerCurrentHP = playerBaseHP;
        playerMaxHP = playerBaseHP;
        playerCurrentATK = playerBaseATK;
        playerCurrentArmor = playerBaseArmor;

        hpText.text = "Hitpoints: " + playerBaseHP;
        atkText.text = "Attack: " + playerBaseATK;
        armorText.text = "Armor: " + playerBaseArmor;

        enemy = GameObject.Find("Gegner");
        spieler = GameObject.Find("Player");
        spike = GameObject.Find("spike");
        es = GetComponent<EnemyStats>();

    }

    // Update is called once per frame
    void Update () {
        if(enemy != null && spieler != null) { 
        if (enemy.transform.position.x - spieler.transform.position.x >= -abstand && enemy.transform.position.x - spieler.transform.position.x <= abstand)
        {

            if (enemy.transform.position.z - spieler.transform.position.z >= -abstand && enemy.transform.position.z - spieler.transform.position.z <= abstand)
            {
                TakeDMG(1);
            }
        }

                //TEST -> funktioniert
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDMG(1);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            es.EnemyTakeDMG(playerCurrentATK);
            Debug.Log("ENEMY DMG");
        }

        //TEST 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            es.spawnArmor();
            //NewArmor(Random.Range(1,30));
        }
        }
    }

    void TakeDMG (int dmg)
    {
        playerCurrentHP -= dmg;
        //Evtl noch Lifebar Update
        hpText.text = "Hitpoints: " + playerCurrentHP;
        //Knockback
        Vector3 direction = (spieler.transform.position - enemy.transform.position).normalized;
        spieler.GetComponent<Rigidbody>().AddForce(direction * 50, ForceMode.Impulse);
        //Neustart wenn weniger als Null HP
        if (playerCurrentHP <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); ;
    }

    public void NewArmor (int armor)
    {
        playerCurrentArmor = playerBaseArmor + armor;
        armorText.text = "Armor: " + playerCurrentArmor;

    }

   public void NewSword(int swordATK)
    {
        playerCurrentATK = playerBaseATK + swordATK;
        atkText.text = "Attack: " + playerCurrentATK;
    }

    public void NewHP(int playerHP)
    {
        playerCurrentHP = playerHP;
        hpText.text = "Hitpoints: " + playerCurrentHP;
    }

    void spawnGate()
    {
        Vector3 pos = new Vector3(enemy.transform.position.x + 1, 6.0f, enemy.transform.position.z - 1);
        Instantiate(Gate, pos, Quaternion.identity);
    }

    void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.name == "ArmorDrop")
        {
            Debug.Log("ArmorDrop");
            Destroy(GameObject.Find("ArmorDrop"));
            NewArmor(Random.Range(1, 30));
        }
        else if (col.gameObject.name == "Sword")
        {

            Debug.Log("Schwert");
            Destroy(GameObject.Find("Sword"));

            NewSword(1);


            NewSword(Random.Range(1, 10));

        }
        else if (col.gameObject.name == "GateKey")
        {

            Debug.Log("GateKey");
            Destroy(GameObject.Find("GateKey"));

            Vector3 pos = new Vector3(Random.Range(-30, 30), posYGate, Random.Range(-30, 30));
            Instantiate(Gate, pos, Quaternion.identity);



        }
    }

    public int currArmor()
    {

        return playerCurrentArmor;
    }


    public int currHP()
    {

        return playerCurrentHP;
    }


    public int currAttack()
    {

        return playerCurrentATK;
    }
}
