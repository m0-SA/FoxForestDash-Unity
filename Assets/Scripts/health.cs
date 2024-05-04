using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public static health Instance { get; private set; }

    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)
            //if not, set instance to this
            Instance = this;
        //If instance already exists and it's not this:
        else if (Instance != this)
            // Then destroy this. This enforces the singleton pattern,
            // meaning there can only ever be one instance of a ScoreManager.
            Destroy(gameObject);
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }


    public int maxHealth = 5;
    public int playerHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

    // Update is called once per frame

    public void damage()
    {
        playerHealth -= 1;

        // send players back to level start checkpoint
        if (playerHealth <= 0) 
        {
            GameObject player = GameObject.FindWithTag("Player");
            GameObject respawnPoint = GameObject.FindWithTag("LevelCheckpoint");
            player.transform.position = respawnPoint.transform.position;
            playerHealth = maxHealth;

        }
    }
}
