using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

    private Scene scene;
	// Use this for initialization
	void Start () {
        scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Respawnen!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }


}
