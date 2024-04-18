using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

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
        if (playerHealth <= 0) 
        {
            GameObject player = GameObject.FindWithTag("Player");
            GameObject respawnPoint = GameObject.FindWithTag("LevelCheckpoint");
            player.transform.position = respawnPoint.transform.position;
            playerHealth = maxHealth;

        }
    }

    void Update()
    {
        
    }
}
