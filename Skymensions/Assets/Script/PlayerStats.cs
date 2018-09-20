using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public GameObject enemy;
    public int abstand = 4;
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



    // Use this for initialization
    void Start () {
        playerCurrentHP = playerBaseHP;
        playerMaxHP = playerBaseHP;
        playerCurrentATK = playerBaseATK;
        playerCurrentArmor = playerBaseArmor;

        hpText.text = "Hitpoints: " + playerBaseHP;
        atkText.text = "Attack: " + playerBaseATK;
        armorText.text = "Armor: " + playerBaseArmor;

    }

    // Update is called once per frame
    void Update () {
        if (enemy.transform.position.x - this.transform.position.x >= -abstand && enemy.transform.position.x - this.transform.position.x <= abstand)
        {

            if (enemy.transform.position.z - this.transform.position.z >= -abstand && enemy.transform.position.z - this.transform.position.z <= abstand)
            {
                TakeDMG(1);
            }
        }

                //TEST -> funktioniert
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDMG(1);
        }

        //TEST -> funktioniert
        if (Input.GetKeyDown(KeyCode.Q))
        {
            NewArmor(Random.Range(1,30));
        }

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gegner")
        {
            
        }
    }*/

    void TakeDMG (int dmg)
    {
        playerCurrentHP -= dmg;
        //Evtl noch Lifebar Update
        hpText.text = "Hitpoints: " + playerCurrentHP;
        //Knockback
        Vector3 direction = (this.transform.position - enemy.transform.position).normalized;
        this.GetComponent<Rigidbody>().AddForce(direction * 50, ForceMode.Impulse);
    }

    void NewArmor (int armor)
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


        if (col.gameObject.name == "Armor")
        {
            Debug.Log("Armor");
            Destroy(GameObject.Find("Armor"));
            NewArmor(1);
        }
        else if(col.gameObject.name == "Sword"){

            Debug.Log("Schwert");
            Destroy(GameObject.Find("Sword"));
            NewSword(1);

        }



    }
}
