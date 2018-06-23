using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {


    //var
    public int speed = 1;
    private Vector3 forward;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {

            this.transform.Translate(0.0f, 0.0f, 0.3f * speed);
        }


        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-(0.3f * speed), 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -(0.3f * speed));
        }

        if (Input.GetKey(KeyCode.D) )
        {
            this.transform.Translate(0.3f * speed, 0.0f, 0.0f);

        }
    }
}
