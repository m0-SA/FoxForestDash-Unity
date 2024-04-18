using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dashUnlock : MonoBehaviour
{

    public PlayerController playerController;
    public TextMeshProUGUI dashText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.dashUnlocked = true;
            dashText.text = "Dash Available";
            dashText.color = Color.green;
            Destroy(gameObject);
        }
    }
}
