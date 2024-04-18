using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{

    int health;
    int maxHealth;

    public Image[] hearts;

    public health playerHealth;

    // Update is called once per frame
    void Update()
    {

        health = playerHealth.playerHealth;
        maxHealth = playerHealth.maxHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.white;

            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
             else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
