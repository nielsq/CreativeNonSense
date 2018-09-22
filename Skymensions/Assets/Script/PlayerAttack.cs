using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public float swordSpeed = 2f;
    bool attack = false;
    bool swordback = false;
    bool justAttacking = false;
    public PlayerStats ps;
	// Use this for initialization
	void Start () {
        ps = GetComponent<PlayerStats>();
		
	}
	
	// Update is called once per frame
	void Update () {

       if (attack)
        {
            var strike = new Vector2(0, 1);
            transform.Translate(strike * Time.deltaTime * swordSpeed, Space.Self);
        }

        if (swordback)
        {
            var strike = new Vector2(0, -1);
            transform.Translate(strike * Time.deltaTime * swordSpeed, Space.Self);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (attack == false && swordback == false) StartCoroutine(SomeCoroutine());
        }
		
	}

    void OnTriggerEnter (Collider coll)
    {
        if (coll.gameObject.tag == "Gegner")
        {
            if ((attack == true || swordback == true) && justAttacking == true)
            {
                justAttacking = false;
                Debug.Log("ENEMY HIT!");
                ps.playerAttack();
            }
        }
    }

    private IEnumerator SomeCoroutine()
    {
        justAttacking = true;
        Debug.Log("SomeCoroutine");
        attack = true;
        yield return new WaitForSeconds(0.5f);
        swordback = true;
        attack = false;
        yield return new WaitForSeconds(0.5f);
        swordback = false;
        justAttacking = false;
    }
}
