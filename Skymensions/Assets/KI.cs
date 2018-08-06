using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KI : MonoBehaviour {


    public GameObject spieler;


    // Use this for initialization
    void Start () {
    
		
	}
	
	// Update is called once per frame
	void Update () {

        if (spieler.transform.position.x <= this.transform.position.x || spieler.transform.position.x >= this.transform.position.x ) {

        }
		
	}
}
