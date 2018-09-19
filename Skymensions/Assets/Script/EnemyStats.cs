using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    //Anfangswerte
    private int enemyBaseHP = 4;
    private int enemyBaseATK = 1;
    private int enemyBaseArmor = 0;

    public GameObject Armor;
    public GameObject Swoard;

    //playerLevel skaliert mit den Stats der Gegner. Attack = base + playerLevel oder + playerLevel*0.x
    //RNG um Gegener Art zu ermitteln (Random Number 1 = Spinne, 2 = Bär... etc.)

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (enemyBaseHP <= 0) {
            spawnAmor();
            spawnSwoard();
        }
		
	}

    void spawnAmor()
    {
        Vector3 pos = new Vector3(this.transform.position.x -1 , 6.0f, this.transform.position.z -1);
        Instantiate(Armor, pos, Quaternion.identity);
    }

    void spawnSwoard()
    {
        Vector3 pos = new Vector3(this.transform.position.x + 1, 6.0f, this.transform.position.z +1);
        Instantiate(Swoard, pos, Quaternion.identity);
    }
}
