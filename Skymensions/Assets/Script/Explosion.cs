using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
   
    public float power = 40.0f;
    public float radius = 5.0f;
    public float upforce = 1.0f;
    // Use this for initialization
    void Start()
    {

    }

    /*void fixedUpdate()
    {
        if (bomb == enabled)
        {
            Invoke("Detonate", 5);
        }
    } */
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
                Invoke("Detonate", 1);
            
        }
    }

    void Detonate()
    {
        Destroy(gameObject);
        Debug.Log("Explosion!!!");
        Vector3 explosionPosition = gameObject.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);
            }
        }
    }
    // Update is called once per frame
  /*  void Update()
    {

        Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);
            }
        }
    } */
}
