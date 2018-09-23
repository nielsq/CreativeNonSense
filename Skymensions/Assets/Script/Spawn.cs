using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    
    //Initialisierungen
    public GameObject tree;
    public GameObject rock;
    public GameObject wall;
    public GameObject shroom;
    public float posYTree = 7.94f;
    public float posYRock = 3.8f;
    public float posYWall = 7.77f;
    public float posYShroom = 3.09f;

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

        //0-3 Pilze spawnen (Random Number)
        int randomShroom = Random.Range(0, 3);
        for (int i = 0; i <= randomWall; i++)
        {
            spawnShroom();
        }

    }
	
	// Update is called once per frame
	void Update () {

	}

    //Baeume an einer Random Position (auf der Flaeche) spawnen
    void spawnTree()
    {
        Vector3 pos = new Vector3(Random.Range(-30, 30), posYTree, Random.Range(-30, 30));
        //CheckSphere pos, Radius, ignored Layer -> Ground auf Layer 9 gesetzt, sonst Endlosschleife
        while (Physics.CheckSphere(pos, 2, 9)) {
            pos = new Vector3(Random.Range(-30, 30), posYTree, Random.Range(-30, 30));
        }
        Instantiate(tree, pos, Quaternion.identity);
    }
    //Steine an einer Random Position (auf der Flaeche) spawnen
    void spawnRock()
    {
        Vector3 pos = new Vector3(Random.Range(-30, 30), posYRock, Random.Range(-30, 30));
        while (Physics.CheckSphere(pos, 2, 9))
        {
            pos = new Vector3(Random.Range(-30, 30), posYRock, Random.Range(-30, 30));
        }
        Instantiate(rock, pos, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
    }
    //Waende an einer Random Position (auf der Flaeche) spawnen
    void spawnWall()
    {
        Vector3 pos = new Vector3(Random.Range(-30, 30), posYWall, Random.Range(-30, 30));
        while (Physics.CheckSphere(pos, 2, 9))
        {
            pos = new Vector3(Random.Range(-30, 30), posYWall, Random.Range(-30, 30));
        }
        Instantiate(wall, pos, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
    }
    //Pilze an einer Random Position (auf der Flaeche) spawnen
    void spawnShroom()
    {
        Vector3 pos = new Vector3(Random.Range(-30, 30), posYShroom, Random.Range(-30, 30));
        while (Physics.CheckSphere(pos, 2, 9))
        {
            pos = new Vector3(Random.Range(-30, 30), posYShroom, Random.Range(-30, 30));
        }
        Instantiate(shroom, pos, Quaternion.identity);

    }
}
