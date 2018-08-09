using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KI : MonoBehaviour {


    public GameObject spieler;
    public int abstand = 5;
    public bool follow = true;
    public float speed = 1.1f;

    float stuckX1 = 0.0f;
    float stuckX2 = 0.0f;
    float stuckZ1 = 0.0f;
    float stuckZ2 = 0.0f;

    bool bolStockX = true;
    bool bolStockZ = true;


    bool notStuckX = true;
    bool notStuckZ = true;

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
                if (follow) { MoveToPlayer(); }

                
            }


        }
        else
        {
            if (follow) { MoveToPlayer(); }
        }


    }

    void MoveToPlayer() {



        if (Mathf.Round(spieler.transform.position.x * 10) / 10 > Mathf.Round(this.transform.position.x * 10) / 10 && notStuckZ)
        {
          
       
            this.transform.Translate(0.1f* speed, 0.0f, 0.0f);

            float temp = (Mathf.Round(this.transform.position.x * 10) / 10);

            if (stuckX1 == temp)
            {


                WeStockBoisX();
                notStuckX = false;

            }
            else
            {
                Debug.Log("NOT Z");
                stuckX1 = Mathf.Round(this.transform.position.x * 10) / 10;
                notStuckX = true;

            }




        }
        else if (Mathf.Round(spieler.transform.position.x *10) /10 < Mathf.Round(this.transform.position.x * 10) / 10 && notStuckZ) {


            this.transform.Translate(-0.1f * speed, 0.0f, 0.0f);


            float temp = (Mathf.Round(this.transform.position.x * 10) / 10);

            if (stuckX2 ==temp)
            {

                
                WeStockBoisX();
                notStuckX = false;

            }
            else {
                Debug.Log("NOT Z");
                stuckX2 = Mathf.Round(this.transform.position.x * 10) / 10;
                notStuckX = true;

            }

           

        }




        if (Mathf.Round(spieler.transform.position.z * 10) / 10 > Mathf.Round(this.transform.position.z * 10) / 10 && notStuckX)
        {
            this.transform.Translate(0.0f, 0.0f, 0.1f * speed);

            float temp = (Mathf.Round(this.transform.position.z* 10) / 10);

            if (stuckZ1 == temp)
            {

                
                WeStockBoisZ();
                notStuckZ = false;

            }
            else
            {
                Debug.Log("NOT Z");
                stuckZ1 = Mathf.Round(this.transform.position.z * 10) / 10;
                notStuckZ = true;

            }

        }
        else if (Mathf.Round(spieler.transform.position.z * 10) / 10 < Mathf.Round(this.transform.position.z * 10) / 10 && notStuckX)
        {

            this.transform.Translate(0.0f, 0.0f, -0.1f * speed);

            float temp = (Mathf.Round(this.transform.position.z * 10) / 10);

            if (stuckZ2 == temp)
            {


                WeStockBoisZ();
                notStuckZ = false;

            }
            else
            {

                Debug.Log("NOT Z");
                stuckZ2 = Mathf.Round(this.transform.position.z * 10) / 10;
                notStuckZ = true;

            }

        }



    }

    void WeStockBoisX() {
        Debug.Log("X");

        this.transform.Translate(0.0f, 0.0f, -0.1f * speed);

    }

    void WeStockBoisZ()
    {
        Debug.Log("Z");
        if (notStuckX) {
            this.transform.Translate(0.1f * speed, 0.0f, 0.0f);
        }
        

    }



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Wall") {
           
        }

        if (other.tag == "Player")
        {
            Debug.Log("player trigger");
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collions");
    }
}
