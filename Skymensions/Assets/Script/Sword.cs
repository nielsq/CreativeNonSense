﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    // Use this for initialization
    void Start () {
        this.name = "Sword";
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, -2, 0);
    }


}
