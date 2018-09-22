using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerStats {

    public float swordSpeed = 2f;
    bool attack = false;
    bool swordback = false;
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
            StartCoroutine(SomeCoroutine());
        }
		
	}

    void OnTriggerEnter (Collider coll)
    {
        if (coll.gameObject.tag == "Gegner")
        {
            Debug.Log("ENEMY HIT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            es.EnemyTakeDMG(2);
        }
    }

    private IEnumerator SomeCoroutine()
    {
        Debug.Log("SomeCoroutine");
        attack = true;
        yield return new WaitForSeconds(0.5f);
        attack = false;
        swordback = true;
        yield return new WaitForSeconds(0.5f);
        swordback = false;
    }
}
