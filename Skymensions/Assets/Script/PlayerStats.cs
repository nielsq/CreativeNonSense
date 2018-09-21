using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    private Scene scene;
    public GameObject enemy;
    private GameObject spieler;
    public int abstand = 4;
    EnemyStats es;
    //Anfangswerte
    private int playerBaseHP = 10;
    private int playerBaseATK = 1;
    private int playerBaseArmor = 0;

    //Aktualisierte Werte
    private int playerCurrentHP;
    private int playerMaxHP;
    private int playerCurrentATK;
    private int playerCurrentArmor;

    //Fuer das UI
    public Text hpText;
    public Text atkText;
    public Text armorText;




    // Use this for initialization
    void Start()
    {

        scene = SceneManager.GetActiveScene();

        playerCurrentHP = playerBaseHP;
        playerMaxHP = playerBaseHP;
        playerCurrentATK = playerBaseATK;
        playerCurrentArmor = playerBaseArmor;

        hpText.text = "Hitpoints: " + playerBaseHP;
        atkText.text = "Attack: " + playerBaseATK;
        armorText.text = "Armor: " + playerBaseArmor;

        enemy = GameObject.FindGameObjectWithTag("Gegner");
        spieler = GameObject.FindGameObjectWithTag("Player");
        es = enemy.GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.transform.position.x - spieler.transform.position.x >= -abstand && enemy.transform.position.x - spieler.transform.position.x <= abstand)
        {

            if (enemy.transform.position.z - spieler.transform.position.z >= -abstand && enemy.transform.position.z - spieler.transform.position.z <= abstand)
            {
                TakeDMG(1);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attacking();
        }

        //TEST -> funktioniert
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDMG(1);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Warum 2 mal");
            es.EnemyTakeDMG(playerCurrentATK);
        }

        //TEST 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            es.spawnArmor();
            //NewArmor(Random.Range(1,30));
        }

    }

    void TakeDMG(int dmg)
    {
        Debug.Log("PLAYERDMG");
        playerCurrentHP -= dmg;
        //Evtl noch Lifebar Update
        hpText.text = "Hitpoints: " + playerCurrentHP;
        //Knockback
        Vector3 direction = (spieler.transform.position - enemy.transform.position).normalized;
        spieler.GetComponent<Rigidbody>().AddForce(direction * 30, ForceMode.Impulse);
        //Neustart wenn weniger als Null HP
        if (playerCurrentHP <= 0) Application.LoadLevel(scene.name);
    }

    void NewArmor(int armor)
    {
        playerCurrentArmor = playerBaseArmor + armor;
        armorText.text = "Armor: " + playerCurrentArmor;

    }

    void NewSword(int swordATK)
    {
        playerCurrentATK = playerBaseATK + swordATK;
        atkText.text = "Attack: " + playerCurrentATK;
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
            NewSword(Random.Range(1, 10));
        }
    }

    void Attacking()
    {
        Debug.Log("Geht in Attacking");        
    }
}
