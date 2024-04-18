using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class doubleJumpUnlock : MonoBehaviour
{

    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.doubleJumpUnlocked = true;
            Destroy(gameObject);
        }
    }
}
