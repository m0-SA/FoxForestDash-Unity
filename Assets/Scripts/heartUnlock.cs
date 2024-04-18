using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class heartUnlock : MonoBehaviour
{
    public health health;
    public TextMeshProUGUI unlockUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health.maxHealth += 1;
            health.playerHealth += 1;
            unlockUI.text = "You've gained a heart!";
            Destroy(gameObject);
        }
    }
}
