using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    //Initialisierungen
    public GameObject enemy;
    public GameObject tree;
    public GameObject rock;
    public GameObject wall;
    public float posYTree = 7.94f;
    public float posYRock = 3.8f;
    public float posYWall = 7.77f;
    public int enemyCounter = 0;

    // Use this for initialization
    void Start () {
        //1-3 Baume spawnen (Random Number)
        int randomTree = Random.Range(1, 3);
        for (int i = 0; i <= randomTree; i++)
        {
            spawnTree();
        }
        
        //2-5 Steine spawnen (Random Number)
        int randomRock = Random.Range(2, 5);
        for (int i = 0; i <= randomRock; i++)
        {
            spawnRock();
        }

        //0-2 Waende spawnen (Random Number)
        int randomWall = Random.Range(0, 2);
        for (int i = 0; i <= randomWall; i++)
        {
            spawnWall();
        }

        spawnEnemy();
        enemy.tag = "Gegner";

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        Vector3 pos = new Vector3(-3, 7.55f, 23.4f);
        enemy = (GameObject)Instantiate(enemy, pos, Quaternion.identity);
        enemyCounter++;
    }

    //Baeume an einer Random Position (auf der Flaeche) spawnen
    void spawnTree()
    {
        Vector3 pos = new Vector3(Random.Range(-30, 30), posYTree, Random.Range(-30, 30));
        Instantiate(tree, pos, Quaternion.identity);
    }
    //Steine an einer Random Position (auf der Flaeche) spawnen
    void spawnRock()
    {
        Vector3 pos = new Vector3(Random.Range(-30, 30), posYRock, Random.Range(-30, 30));
        Instantiate(rock, pos, Quaternion.identity);
    }
    
    //Waende an einer Random Position (auf der Flaeche) spawnen
    void spawnWall()
    {
        Vector3 pos = new Vector3(Random.Range(-30, 30), posYWall, Random.Range(-30, 30));
        Instantiate(wall, pos, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
     
    }
}
