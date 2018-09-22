using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {
    public GameObject Player;
    private Scene scene;

    private static int currHP = 10;
    private static int currATk = 2;
    private static int currAr = 0;
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
            Player.GetComponent<PlayerStats>().resetStats(currAr, currATk, currHP);
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }


}
