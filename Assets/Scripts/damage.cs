using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{

    public health health;
    public PlayerController playerController;

    [SerializeField]
    float totalKnockbackTime,
        knockbackMultiplier;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && health.playerHealth > 0) {
            playerController.knockbackCounter = totalKnockbackTime;
            playerController.knockbackMultiplier = knockbackMultiplier;

            if (collision.transform.position.x <= transform.position.x)
            {
                playerController.knockbackDirection = true;

            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerController.knockbackDirection = false;
            }
            health.damage();
            
        };
    }
}
