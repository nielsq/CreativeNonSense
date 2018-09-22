using System.Collections;
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

    public int enemyCurrentHP;
    public int enemyCurrentATK;
    private int enemyCurrentArmor;

    private bool dead = false;

    public GameObject Armor;
    public GameObject Swoard;
    public GameObject GateKey;

    //playerLevel skaliert mit den Stats der Gegner. Attack = base + playerLevel oder + playerLevel*0.x
    //RNG um Gegener Art zu ermitteln (Random Number 1 = Spinne, 2 = Bär... etc.)

    // Use this for initialization
    void Start () {
        enemyCurrentHP = enemyBaseHP;
        enemyCurrentATK = enemyBaseATK;
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

    public void spawnGateKey()
    {
        Vector3 pos = new Vector3(enemy.transform.position.x + 1, 6.0f, enemy.transform.position.z -1);
        Instantiate(GateKey, pos, Quaternion.identity);
    }

    public void EnemyTakeDMG(int dmg)
    {
        Debug.Log("Enemy Take DMG Function");
        enemyCurrentHP -= dmg;
        //Evtl noch Lifebar Update
        //Knockback
        if(enemy != null) {
            Vector3 direction = (enemy.transform.position - player.transform.position).normalized;
            enemy.GetComponent<Rigidbody>().AddForce(direction * 50, ForceMode.Impulse);
            if (enemyCurrentHP <= 0)
            {
                spawnArmor();
                spawnSwoard();
                spawnGateKey();
                Destroy(enemy);
            }
        }
    }

    void SpawnEnemy()
    {
        Vector3 pos = new Vector3(-3, 7.55f, 23.4f);
        enemy = (GameObject)Instantiate(enemy, pos, Quaternion.identity);
    }

    void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.name == "spike")
        {
            Debug.Log("HIT");
        }
    }




 }
