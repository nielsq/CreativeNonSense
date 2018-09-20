﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public bool firstStart = true;
    
    //Anfangswerte
    private int enemyBaseHP = 4;
    private int enemyBaseATK = 1;
    private int enemyBaseArmor = 0;

    private int enemyCurrentHP;
    private int enemyCurrentATK;
    private int enemyCurrentArmor;

    public GameObject Armor;
    public GameObject Swoard;

    //playerLevel skaliert mit den Stats der Gegner. Attack = base + playerLevel oder + playerLevel*0.x
    //RNG um Gegener Art zu ermitteln (Random Number 1 = Spinne, 2 = Bär... etc.)

    // Use this for initialization
    void Start () {
        enemyCurrentHP = enemyBaseHP;
        enemy = GameObject.Find("Gegner");
        
    }
	
	// Update is called once per frame
	void Update () {

       
        //TEST -> klappt
        if (Input.GetKeyDown(KeyCode.G))
        {
            EnemyTakeDMG(1);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SpawnEnemy();
        }

    }

    public void spawnArmor()
    {
        Vector3 pos = new Vector3(enemy.transform.position.x - 1, 6.0f, enemy.transform.position.z - 1);
        Instantiate(Armor, pos, Quaternion.identity);
    }

    public void spawnSwoard()
    {
        Vector3 pos = new Vector3(enemy.transform.position.x + 1, 6.0f, enemy.transform.position.z +1);
        Instantiate(Swoard, pos, Quaternion.identity);
    }

    public void EnemyTakeDMG(int dmg)
    {
        enemyCurrentHP -= dmg;
        //Evtl noch Lifebar Update
        //Knockback
        Vector3 direction = (enemy.transform.position - player.transform.position).normalized;
        enemy.GetComponent<Rigidbody>().AddForce(direction * 50, ForceMode.Impulse);
        if (enemyCurrentHP <= 0)
        {
            spawnArmor();
            spawnSwoard();
            Destroy(enemy);
        }
    }

    void SpawnEnemy()
    {
        Vector3 pos = new Vector3(-3, 7.55f, 23.4f);
        enemy = (GameObject)Instantiate(enemy, pos, Quaternion.identity);
    }




}
