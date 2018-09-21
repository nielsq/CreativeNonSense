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
    public int abstand = 4;
    EnemyStats es;
    //Anfangswerte
    private int playerBaseHP = 10;
    private int playerBaseATK = 2;
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

    private float posYGate = 7.94f;


    // Use this for initialization
    void Start () {

        scene = SceneManager.GetActiveScene();

        
        playerCurrentHP = playerBaseHP;
        playerMaxHP = playerBaseHP;
        playerCurrentATK = playerBaseATK;
        playerCurrentArmor = playerBaseArmor;

        changeText();

        

        enemy = GameObject.Find("Gegner");
        spieler = GameObject.FindGameObjectWithTag("Player");
        es = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update () {

        
        
        //Debug.Log(armorText.text);

        if (enemy != null) { 
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
        spieler.GetComponent<Rigidbody>().AddForce(direction * 10, ForceMode.Impulse);
        //Neustart wenn weniger als Null HP
        if (playerCurrentHP <= 0) Application.LoadLevel(scene.name);
        }
    

    public void NewArmor (int armor)
    {
        Debug.Log("Current Armor:" + playerCurrentArmor);
        playerCurrentArmor = playerBaseArmor + armor;

        changeText();

        Debug.Log(armorText.text);
    }

   public void NewSword(int swordATK)
    {
        playerCurrentATK = playerBaseATK + swordATK;
        changeText();


    }

    public void NewHP(int playerHP)
    {
        Debug.Log("Das ist das Player HP:" + playerHP);
        playerCurrentHP = playerHP;
        changeText();

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

            //NewSword(1);


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

    public void newStats(int playerCurrentArmor, int playerCurrentATK, int playerCurrentHP)
    {
        Debug.Log("New Stats:" + playerCurrentHP + playerCurrentATK + playerCurrentArmor);
        setNewStats(playerCurrentArmor, playerCurrentATK, playerCurrentHP);
    }


    private void setNewStats(int armor, int swordATK, int playerHP)
    {
        playerCurrentHP = playerHP;
        playerCurrentATK = playerBaseATK + swordATK;
        playerCurrentArmor = playerBaseArmor + armor;
        Debug.Log("New Stats sind:" + playerCurrentHP + playerCurrentATK + playerCurrentArmor);
        changeText();
    }

    void changeText()
    {
       
        hpText.text = "Hitpoints: " + playerCurrentHP;
        atkText.text = "Attack: " + playerCurrentATK;
        armorText.text = "Armor: " + playerCurrentArmor;
        Debug.Log("Change:" + hpText.text + atkText.text + armorText.text);
    }
}
