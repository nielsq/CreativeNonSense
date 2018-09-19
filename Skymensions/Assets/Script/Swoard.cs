using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swoard : MonoBehaviour {

    public GameObject spieler;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, -2, 0);
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "spieler")
        {
            Destroy(this.gameObject);
        }
    }


}
