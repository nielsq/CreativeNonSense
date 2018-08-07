using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KI : MonoBehaviour {


    public GameObject spieler;
    public int abstand = 5;
    public bool follow = true;
    public float speed = 1.1f;

    // Use this for initialization
    void Start () {
    
		
	}
	
	// Update is called once per frame
	void Update () {




        if (this.transform.position.x - spieler.transform.position.x >= -abstand &&  this.transform.position.x - spieler.transform.position.x <= abstand) {

            if (this.transform.position.z - spieler.transform.position.z >= -abstand && this.transform.position.z - spieler.transform.position.z <= abstand)
            {


                Debug.Log("ja");


            }
            else
            {
                if (follow) { moveToPlayer(); }

                
            }


        }
        else
        {
            if (follow) { moveToPlayer(); }
        }


    }

    void moveToPlayer() {

        if (spieler.transform.position.x > this.transform.position.x)
        {

            this.transform.Translate(0.1f* speed, 0.0f, 0.0f);
        }
        else if (spieler.transform.position.x < this.transform.position.x) {

            this.transform.Translate(-0.1f * speed, 0.0f, 0.0f);
        }




        if (spieler.transform.position.z > this.transform.position.z)
        {

            this.transform.Translate(0.0f, 0.0f, 0.1f * speed);
        }
        else if (spieler.transform.position.z < this.transform.position.z)
        {

            this.transform.Translate(0.0f, 0.0f, -0.1f * speed);
        }

    }

}
