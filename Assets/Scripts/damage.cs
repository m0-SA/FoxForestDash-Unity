using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{

    // Length player is in knockback state and how much force is given to the knockback.
    [SerializeField]
    float totalKnockbackTime = 0.1f,
        knockbackMultiplier = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        knockback(collision);
    }

    public void knockback(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && health.Instance.playerHealth > 0)
        {
            PlayerController.Instance.knockbackCounter = totalKnockbackTime;
            PlayerController.Instance.knockbackMultiplier = knockbackMultiplier;

            // knockback to the left
            if (collision.transform.position.x <= transform.position.x)
            {
                PlayerController.Instance.knockbackDirection = true;

            }

            // knockback to the right
            if (collision.transform.position.x > transform.position.x)
            {
                PlayerController.Instance.knockbackDirection = false;
            }
            health.Instance.damage();

        };
    }
}
