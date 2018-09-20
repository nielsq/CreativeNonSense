using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {
    public GameObject ArmorDrop;

    // Use this for initialization
    void Start () {
        this.name = "Armor";
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 2, 0);
    }

    


}
