using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{

    int healthVal;
    int maxHealth;

    public Image[] hearts;



    // Update is called once per frame
    void Update()
    {

        healthVal = health.Instance.playerHealth;
        maxHealth = health.Instance.maxHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < healthVal)
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
