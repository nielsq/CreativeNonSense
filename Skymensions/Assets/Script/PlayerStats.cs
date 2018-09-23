using System.Collections;
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
    private static int playerBaseHP = 10;
    private static int playerBaseATK = 2;
    private static int playerBaseArmor = 0;
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

        es.playerLevel = playerCurrentATK + playerCurrentArmor; //Mathf.RoundToInt((playerCurrentArmor + playerCurrentATK)/2);

    }

    // Update is called once per frame
    void Update () {
        if(enemy != null && spieler != null) { 
            if (enemy.transform.position.x - spieler.transform.position.x >= -abstand && enemy.transform.position.x - spieler.transform.position.x <= abstand)
            {

                if (enemy.transform.position.z - spieler.transform.position.z >= -abstand && enemy.transform.position.z - spieler.transform.position.z <= abstand)
                {
                    TakeDMG(es.enemyCurrentATK);
                }
            }

                    //TEST -> funktioniert
            if (Input.GetKeyDown(KeyCode.F))
            {
                TakeDMG(1);
            }
            // TEST -> funktioniert
            if (Input.GetKeyDown(KeyCode.X))
            {
                es.EnemyTakeDMG(playerCurrentATK);
                Debug.Log("ENEMY DMG");
            }

            //TEST 
            if (Input.GetKeyDown(KeyCode.Q))
            {
                es.spawnArmor();
            }

            es.playerLevel = playerCurrentATK + playerCurrentArmor; //Mathf.RoundToInt((playerCurrentArmor + playerCurrentATK)/2);
        }
    }

    void TakeDMG (int dmg)
    {
        if (dmg > playerCurrentArmor) playerCurrentHP -= (dmg - playerCurrentArmor);
        //Evtl noch Lifebar Update
        hpText.text = "Hitpoints: " + playerCurrentHP;
        //Knockback
        Vector3 direction = (spieler.transform.position - enemy.transform.position).normalized;
        spieler.GetComponent<Rigidbody>().AddForce(direction * 20, ForceMode.Impulse);
        //Neustart wenn weniger als Null HP
        if (playerCurrentHP <= 0)
        {
            playerBaseHP = 10;
            playerBaseATK = 2;
            playerBaseArmor = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); ;

        }
    }

    public void playerAttack()
    {
        Debug.Log("PlayerStats - Attack");
        es.EnemyTakeDMG(playerCurrentATK);
    }

    public void NewArmor (int armor)
    {
        playerCurrentArmor = playerBaseArmor + armor;
        armorText.text = "Armor: " + playerCurrentArmor;
        Debug.Log("New Armor: " + playerCurrentArmor);

    }

   public void NewSword(int swordATK)
    {
        playerCurrentATK = playerBaseATK + swordATK;
        atkText.text = "Attack: " + playerCurrentATK;
        Debug.Log("New Sword: " + playerCurrentATK);
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
            if (Mathf.RoundToInt(es.playerLevel / 2) < 2) NewArmor(1);
            else NewArmor(Mathf.RoundToInt(es.playerLevel/2));
        }
        else if (col.gameObject.name == "Sword")
        {

            Debug.Log("Schwert");
            Destroy(GameObject.Find("Sword"));
            if (Mathf.RoundToInt(es.playerLevel / 2) < 2) NewSword(1);
            else NewSword(Mathf.RoundToInt(es.playerLevel/2));

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

    public void newStats(int armor, int swordATK, int playerHP)
    {
        playerBaseHP = playerHP;
        playerBaseATK = swordATK;
        playerBaseArmor = armor;
        Debug.Log("Neue Stats: " + playerBaseHP + playerBaseATK + playerBaseArmor);
        Start();
    }

    public void resetStats(int armor, int swordATK, int playerHP)
    {
        playerBaseHP = playerHP;
        playerBaseATK = swordATK;
        playerBaseArmor = armor;
        Debug.Log("Neue Stats: " + playerBaseHP + playerBaseATK + playerBaseArmor);
        Start();
    }

}
