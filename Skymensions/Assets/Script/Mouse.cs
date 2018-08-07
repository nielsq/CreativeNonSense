using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

    public GameObject target;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }



    void Update()
    {
        transform.position = target.transform.position -  offset;
       //transform.LookAt(target.transform);
    }
}
