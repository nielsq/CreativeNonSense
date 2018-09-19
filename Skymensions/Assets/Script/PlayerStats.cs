using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {



    //Anfangswerte
    private int playerBaseHP = 10;
    private int playerBaseATK = 2;
    private int playerBaseArmor = 0;

    //Aktualisierte Werte
    public int playerCurrentHP;
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
        //TEST -> funktioniert
        if(Input.GetKeyDown(KeyCode.F))
        {
            TakeDMG(1);
        }

        //TEST -> funktioniert
        if (Input.GetKeyDown(KeyCode.Q))
        {
            NewArmor(Random.Range(1,30));
        }

    }

    void TakeDMG (int dmg)
    {
        playerCurrentHP -= dmg;
        //Evtl noch Lifebar Update
        hpText.text = "Hitpoints: " + playerCurrentHP;
    }

    public void NewArmor (int armor)
    {
        playerCurrentArmor = playerBaseArmor + armor;
        armorText.text = "Armor: " + playerCurrentArmor;

    }

    void NewSword(int swordATK)
    {
        playerCurrentATK = playerBaseATK + swordATK;
        atkText.text = "Attack: " + playerCurrentATK;
    }
}
